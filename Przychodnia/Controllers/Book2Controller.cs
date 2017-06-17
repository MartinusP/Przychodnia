using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Przychodnia.Context;
using Przychodnia.Models;

namespace Przychodnia
{
    public class Book2Controller : Controller
    {
        private PRZYCHODNIAEntities db = new PRZYCHODNIAEntities();

        // GET: Book2
        public ActionResult Index()
        {
            return View(db.Books2.ToList());
        }

        // GET: Book2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book2 book2 = db.Books2.Find(id);
            if (book2 == null)
            {
                return HttpNotFound();
            }
            return View(book2);
        }

        // GET: Book2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SPECJALIZACJA,NAZWA")] Book2 book2)
        {
            if (ModelState.IsValid)
            {
                db.Books2.Add(book2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book2);
        }

        // GET: Book2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book2 book2 = db.Books2.Find(id);
            if (book2 == null)
            {
                return HttpNotFound();
            }
            return View(book2);
        }

        // POST: Book2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SPECJALIZACJA,NAZWA")] Book2 book2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book2);
        }

        // GET: Book2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book2 book2 = db.Books2.Find(id);
            if (book2 == null)
            {
                return HttpNotFound();
            }
            return View(book2);
        }

        // POST: Book2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book2 book2 = db.Books2.Find(id);
            db.Books2.Remove(book2);
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
