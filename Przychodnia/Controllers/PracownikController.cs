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
    public class PracownikController : Controller
    {
        private PRZYCHODNIAEntities db = new PRZYCHODNIAEntities();

        // GET: Pracownik
        public ActionResult Index()
        {
            var pracownicy = db.PRACOWNICY.Include(p => p.ODDZIAL_PRACOWNIK1).Include(p => p.DYZUR).Include(p => p.SPECJALIZACJA);
            return View(pracownicy.ToList());
        }

        // GET: Pracownik/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRACOWNIK pracownik = db.PRACOWNICY.Find(id);
            if (pracownik == null)
            {
                return HttpNotFound();
            }
            return View(pracownik);
        }

        // GET: Pracownik/Create
        public ActionResult Create()
        {
            ViewBag.ID_ODDZIAL_PRACOWNIK = new SelectList(db.ODDZIAL_PRACOWNIK, "ID_ODDZIAL_PRACOWNIK", "ID_ODDZIAL_PRACOWNIK");
            ViewBag.ID_PRACOWNIK = new SelectList(db.DYZURY, "ID_PRACOWNIK", "ID_PRACOWNIK");
            ViewBag.ID_SPECJALIZACJA = new SelectList(db.SPECJALIZACJE, "ID_SPECJALIZACJA", "NAZWA");
            return View();
        }

        // POST: Pracownik/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PRACOWNIK,IMIE,NAZWISKO,ADRES,EMAIL_KONTAKTOWY,ID_SPECJALIZACJA,ID_ODDZIAL_PRACOWNIK")] PRACOWNIK pracownik)
        {
            if (ModelState.IsValid)
            {
                db.PRACOWNICY.Add(pracownik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ODDZIAL_PRACOWNIK = new SelectList(db.ODDZIAL_PRACOWNIK, "ID_ODDZIAL_PRACOWNIK", "ID_ODDZIAL_PRACOWNIK", pracownik.ID_ODDZIAL_PRACOWNIK);
            ViewBag.ID_PRACOWNIK = new SelectList(db.DYZURY, "ID_PRACOWNIK", "ID_PRACOWNIK", pracownik.ID_PRACOWNIK);
            ViewBag.ID_SPECJALIZACJA = new SelectList(db.SPECJALIZACJE, "ID_SPECJALIZACJA", "NAZWA", pracownik.ID_SPECJALIZACJA);
            return View(pracownik);
        }

        // GET: Pracownik/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRACOWNIK pracownik = db.PRACOWNICY.Find(id);
            if (pracownik == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ODDZIAL_PRACOWNIK = new SelectList(db.ODDZIAL_PRACOWNIK, "ID_ODDZIAL_PRACOWNIK", "ID_ODDZIAL_PRACOWNIK", pracownik.ID_ODDZIAL_PRACOWNIK);
            ViewBag.ID_PRACOWNIK = new SelectList(db.DYZURY, "ID_PRACOWNIK", "ID_PRACOWNIK", pracownik.ID_PRACOWNIK);
            ViewBag.ID_SPECJALIZACJA = new SelectList(db.SPECJALIZACJE, "ID_SPECJALIZACJA", "NAZWA", pracownik.ID_SPECJALIZACJA);
            return View(pracownik);
        }

        // POST: Pracownik/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PRACOWNIK,IMIE,NAZWISKO,ADRES,EMAIL_KONTAKTOWY,ID_SPECJALIZACJA,ID_ODDZIAL_PRACOWNIK")] PRACOWNIK pracownik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pracownik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ODDZIAL_PRACOWNIK = new SelectList(db.ODDZIAL_PRACOWNIK, "ID_ODDZIAL_PRACOWNIK", "ID_ODDZIAL_PRACOWNIK", pracownik.ID_ODDZIAL_PRACOWNIK);
            ViewBag.ID_PRACOWNIK = new SelectList(db.DYZURY, "ID_PRACOWNIK", "ID_PRACOWNIK", pracownik.ID_PRACOWNIK);
            ViewBag.ID_SPECJALIZACJA = new SelectList(db.SPECJALIZACJE, "ID_SPECJALIZACJA", "NAZWA", pracownik.ID_SPECJALIZACJA);
            return View(pracownik);
        }

        // GET: Pracownik/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRACOWNIK pracownik = db.PRACOWNICY.Find(id);
            if (pracownik == null)
            {
                return HttpNotFound();
            }
            return View(pracownik);
        }

        // POST: Pracownik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRACOWNIK pracownik = db.PRACOWNICY.Find(id);
            db.PRACOWNICY.Remove(pracownik);
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
