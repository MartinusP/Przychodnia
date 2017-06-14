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
    public class WizytaController : Controller
    {
        private PRZYCHODNIAEntities db = new PRZYCHODNIAEntities();

        // GET: Wizyta
        public ActionResult Index()
        {
            var wizyty = db.WIZYTY.Include(w => w.ODDZIAL).Include(w => w.PACJENT).Include(w => w.PRACOWNIK).Include(w => w.SALA);
            return View(wizyty.ToList());
        }

        // GET: Wizyta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WIZYTA wizyta = db.WIZYTY.Find(id);
            if (wizyta == null)
            {
                return HttpNotFound();
            }
            return View(wizyta);
        }

        // GET: Wizyta/Create
        public ActionResult Create()
        {
            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALY, "ID_ODDZIAL", "NAZWA");
            ViewBag.ID_PACJENT = new SelectList(db.PACJENCI, "ID_PACJENT", "IMIE");
            ViewBag.ID_PRACOWNIK = new SelectList(db.PRACOWNICY, "ID_PRACOWNIK", "IMIE");
            ViewBag.ID_SALA = new SelectList(db.SALE, "ID_SALA", "ID_SALA");
            return View();
        }

        // POST: Wizyta/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_WIZYTA,DATA_WIZYTY,ID_SALA,ID_PRACOWNIK,ID_ODDZIAL,ID_PACJENT,UWAGI")] WIZYTA wizyta)
        {
            if (ModelState.IsValid)
            {
                db.WIZYTY.Add(wizyta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALY, "ID_ODDZIAL", "NAZWA", wizyta.ID_ODDZIAL);
            ViewBag.ID_PACJENT = new SelectList(db.PACJENCI, "ID_PACJENT", "IMIE", wizyta.ID_PACJENT);
            ViewBag.ID_PRACOWNIK = new SelectList(db.PRACOWNICY, "ID_PRACOWNIK", "IMIE", wizyta.ID_PRACOWNIK);
            ViewBag.ID_SALA = new SelectList(db.SALE, "ID_SALA", "ID_SALA", wizyta.ID_SALA);
            return View(wizyta);
        }

        // GET: Wizyta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WIZYTA wizyta = db.WIZYTY.Find(id);
            if (wizyta == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALY, "ID_ODDZIAL", "NAZWA", wizyta.ID_ODDZIAL);
            ViewBag.ID_PACJENT = new SelectList(db.PACJENCI, "ID_PACJENT", "IMIE", wizyta.ID_PACJENT);
            ViewBag.ID_PRACOWNIK = new SelectList(db.PRACOWNICY, "ID_PRACOWNIK", "IMIE", wizyta.ID_PRACOWNIK);
            ViewBag.ID_SALA = new SelectList(db.SALE, "ID_SALA", "ID_SALA", wizyta.ID_SALA);
            return View(wizyta);
        }

        // POST: Wizyta/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_WIZYTA,DATA_WIZYTY,ID_SALA,ID_PRACOWNIK,ID_ODDZIAL,ID_PACJENT,UWAGI")] WIZYTA wizyta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wizyta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALY, "ID_ODDZIAL", "NAZWA", wizyta.ID_ODDZIAL);
            ViewBag.ID_PACJENT = new SelectList(db.PACJENCI, "ID_PACJENT", "IMIE", wizyta.ID_PACJENT);
            ViewBag.ID_PRACOWNIK = new SelectList(db.PRACOWNICY, "ID_PRACOWNIK", "IMIE", wizyta.ID_PRACOWNIK);
            ViewBag.ID_SALA = new SelectList(db.SALE, "ID_SALA", "ID_SALA", wizyta.ID_SALA);
            return View(wizyta);
        }

        // GET: Wizyta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WIZYTA wizyta = db.WIZYTY.Find(id);
            if (wizyta == null)
            {
                return HttpNotFound();
            }
            return View(wizyta);
        }

        // POST: Wizyta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WIZYTA wizyta = db.WIZYTY.Find(id);
            db.WIZYTY.Remove(wizyta);
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
