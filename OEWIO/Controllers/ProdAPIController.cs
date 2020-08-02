using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using OEWIO.Models;

namespace OEWIO.Controllers
{
    public class ProdAPIController : ApiController
    {
        private OEWIOEntities db = new OEWIOEntities();

        // GET: api/ProdAPI
        public IQueryable<OEWIOProduct> GetOEWIOProducts()
        {
            return db.OEWIOProducts;
        }

        // GET: api/ProdAPI/5
        [ResponseType(typeof(OEWIOProduct))]
        public IHttpActionResult GetOEWIOProduct(Guid id)
        {
            OEWIOProduct oEWIOProduct = db.OEWIOProducts.Find(id);
            if (oEWIOProduct == null)
            {
                return NotFound();
            }

            return Ok(oEWIOProduct);
        }

        // PUT: api/ProdAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOEWIOProduct(Guid id, OEWIOProduct oEWIOProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != oEWIOProduct.ID)
            {
                return BadRequest();
            }

            db.Entry(oEWIOProduct).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OEWIOProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ProdAPI
        [ResponseType(typeof(OEWIOProduct))]
        public IHttpActionResult PostOEWIOProduct(OEWIOProduct oEWIOProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OEWIOProducts.Add(oEWIOProduct);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OEWIOProductExists(oEWIOProduct.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = oEWIOProduct.ID }, oEWIOProduct);
        }

        // DELETE: api/ProdAPI/5
        [ResponseType(typeof(OEWIOProduct))]
        public IHttpActionResult DeleteOEWIOProduct(Guid id)
        {
            OEWIOProduct oEWIOProduct = db.OEWIOProducts.Find(id);
            if (oEWIOProduct == null)
            {
                return NotFound();
            }

            db.OEWIOProducts.Remove(oEWIOProduct);
            db.SaveChanges();

            return Ok(oEWIOProduct);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OEWIOProductExists(Guid id)
        {
            return db.OEWIOProducts.Count(e => e.ID == id) > 0;
        }
    }
}