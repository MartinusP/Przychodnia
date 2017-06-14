using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Przychodnia.Repository;

namespace Przychodnia
{
    public class SpecjalizacjaController : Controller
    {
        private PRZYCHODNIAEntities db = new PRZYCHODNIAEntities();

        // GET: Specjalizacja
        public ActionResult Index()
        {
            return View(db.SPECJALIZACJE.ToList());
        }

        // GET: Specjalizacja/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPECJALIZACJA specjalizacja = db.SPECJALIZACJE.Find(id);
            if (specjalizacja == null)
            {
                return HttpNotFound();
            }
            return View(specjalizacja);
        }

        // GET: Specjalizacja/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Specjalizacja/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SPECJALIZACJA,NAZWA")] SPECJALIZACJA specjalizacja)
        {
            if (ModelState.IsValid)
            {
                db.SPECJALIZACJE.Add(specjalizacja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(specjalizacja);
        }

        // GET: Specjalizacja/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPECJALIZACJA specjalizacja = db.SPECJALIZACJE.Find(id);
            if (specjalizacja == null)
            {
                return HttpNotFound();
            }
            return View(specjalizacja);
        }

        // POST: Specjalizacja/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SPECJALIZACJA,NAZWA")] SPECJALIZACJA specjalizacja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(specjalizacja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(specjalizacja);
        }

        // GET: Specjalizacja/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPECJALIZACJA specjalizacja = db.SPECJALIZACJE.Find(id);
            if (specjalizacja == null)
            {
                return HttpNotFound();
            }
            return View(specjalizacja);
        }

        // POST: Specjalizacja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SPECJALIZACJA specjalizacja = db.SPECJALIZACJE.Find(id);
            db.SPECJALIZACJE.Remove(specjalizacja);
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
