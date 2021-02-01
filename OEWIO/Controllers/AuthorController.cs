using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OEWIO.DAL;
using OEWIO.Models;

namespace OEWIO.Controllers
{
    public class AuthorController : Controller
    {
        private OEWIOContext db = new OEWIOContext();

        // GET: Author
        public ActionResult Index()
        {
            return View(db.OEWIOAuthor.ToList());
        }

        // GET: Author/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OEWIOAuthor oEWIOAuthor = db.OEWIOAuthor.Find(id);
            if (oEWIOAuthor == null)
            {
                return HttpNotFound();
            }
            return View(oEWIOAuthor);
        }

        // GET: Author/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AuthorID,FirstName,LastName,Created,Modified,Active")] OEWIOAuthor oEWIOAuthor)
        {
            if (ModelState.IsValid)
            {
                oEWIOAuthor.ID = Guid.NewGuid();
                db.OEWIOAuthor.Add(oEWIOAuthor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oEWIOAuthor);
        }

        // GET: Author/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OEWIOAuthor oEWIOAuthor = db.OEWIOAuthor.Find(id);
            if (oEWIOAuthor == null)
            {
                return HttpNotFound();
            }
            return View(oEWIOAuthor);
        }

        // POST: Author/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AuthorID,FirstName,LastName,Created,Modified,Active")] OEWIOAuthor oEWIOAuthor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oEWIOAuthor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oEWIOAuthor);
        }

        // GET: Author/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OEWIOAuthor oEWIOAuthor = db.OEWIOAuthor.Find(id);
            if (oEWIOAuthor == null)
            {
                return HttpNotFound();
            }
            return View(oEWIOAuthor);
        }

        // POST: Author/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            OEWIOAuthor oEWIOAuthor = db.OEWIOAuthor.Find(id);
            db.OEWIOAuthor.Remove(oEWIOAuthor);
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
