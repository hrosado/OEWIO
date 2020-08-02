using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OEWIO.Models;

namespace OEWIO.Controllers
{
    public class ProductsController : Controller
    {
        private OEWIOEntities db = new OEWIOEntities();

        // GET: Products
        public ActionResult Index()
        {
            var oEWIOProducts = db.OEWIOProducts.Include(o => o.OEWIOAuthor);
            return View(oEWIOProducts.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OEWIOProduct oEWIOProduct = db.OEWIOProducts.Find(id);
            if (oEWIOProduct == null)
            {
                return HttpNotFound();
            }
            return View(oEWIOProduct);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.AuthorID = new SelectList(db.OEWIOAuthors, "ID", "FirstName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,ProductDate,AuthorID,Created,Modified")] OEWIOProduct oEWIOProduct)
        {
            if (ModelState.IsValid)
            {
                oEWIOProduct.ID = Guid.NewGuid();
                db.OEWIOProducts.Add(oEWIOProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorID = new SelectList(db.OEWIOAuthors, "ID", "FirstName", oEWIOProduct.AuthorID);
            return View(oEWIOProduct);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OEWIOProduct oEWIOProduct = db.OEWIOProducts.Find(id);
            if (oEWIOProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorID = new SelectList(db.OEWIOAuthors, "ID", "FirstName", oEWIOProduct.AuthorID);
            return View(oEWIOProduct);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ProductDate,AuthorID,Created,Modified")] OEWIOProduct oEWIOProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oEWIOProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorID = new SelectList(db.OEWIOAuthors, "ID", "FirstName", oEWIOProduct.AuthorID);
            return View(oEWIOProduct);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OEWIOProduct oEWIOProduct = db.OEWIOProducts.Find(id);
            if (oEWIOProduct == null)
            {
                return HttpNotFound();
            }
            return View(oEWIOProduct);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            OEWIOProduct oEWIOProduct = db.OEWIOProducts.Find(id);
            db.OEWIOProducts.Remove(oEWIOProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
