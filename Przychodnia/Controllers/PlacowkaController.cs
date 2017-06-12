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
    public class PlacowkaController : Controller
    {
        private PRZYCHODNIAEntities db = new PRZYCHODNIAEntities();

        // GET: Placowka
        public ActionResult Index()
        {
            var pLACOWKAs = db.PLACOWKAs.Include(p => p.ODDZIAL);
            return View(pLACOWKAs.ToList());
        }

        // GET: Placowka/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PLACOWKA pLACOWKA = db.PLACOWKAs.Find(id);
            if (pLACOWKA == null)
            {
                return HttpNotFound();
            }
            return View(pLACOWKA);
        }

        // GET: Placowka/Create
        public ActionResult Create()
        {
            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALs, "ID_ODDZIAL", "NAZWA");
            return View();
        }

        // POST: Placowka/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PLACOWKA,NAZWA,MIEJSCOWOSC,ADRES,ID_ODDZIAL")] PLACOWKA pLACOWKA)
        {
            if (ModelState.IsValid)
            {
                db.PLACOWKAs.Add(pLACOWKA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALs, "ID_ODDZIAL", "NAZWA", pLACOWKA.ID_ODDZIAL);
            return View(pLACOWKA);
        }

        // GET: Placowka/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PLACOWKA pLACOWKA = db.PLACOWKAs.Find(id);
            if (pLACOWKA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALs, "ID_ODDZIAL", "NAZWA", pLACOWKA.ID_ODDZIAL);
            return View(pLACOWKA);
        }

        // POST: Placowka/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PLACOWKA,NAZWA,MIEJSCOWOSC,ADRES,ID_ODDZIAL")] PLACOWKA pLACOWKA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pLACOWKA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALs, "ID_ODDZIAL", "NAZWA", pLACOWKA.ID_ODDZIAL);
            return View(pLACOWKA);
        }

        // GET: Placowka/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PLACOWKA pLACOWKA = db.PLACOWKAs.Find(id);
            if (pLACOWKA == null)
            {
                return HttpNotFound();
            }
            return View(pLACOWKA);
        }

        // POST: Placowka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PLACOWKA pLACOWKA = db.PLACOWKAs.Find(id);
            db.PLACOWKAs.Remove(pLACOWKA);
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
