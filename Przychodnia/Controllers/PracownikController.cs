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
            var pRACOWNIKs = db.PRACOWNIKs.Include(p => p.ODDZIAL_PRACOWNIK1).Include(p => p.DYZUR).Include(p => p.SPECJALIZACJA);
            return View(pRACOWNIKs.ToList());
        }

        // GET: Pracownik/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRACOWNIK pRACOWNIK = db.PRACOWNIKs.Find(id);
            if (pRACOWNIK == null)
            {
                return HttpNotFound();
            }
            return View(pRACOWNIK);
        }

        // GET: Pracownik/Create
        public ActionResult Create()
        {
            ViewBag.ID_ODDZIAL_PRACOWNIK = new SelectList(db.ODDZIAL_PRACOWNIK, "ID_ODDZIAL_PRACOWNIK", "ID_ODDZIAL_PRACOWNIK");
            ViewBag.ID_PRACOWNIK = new SelectList(db.DYZURs, "ID_PRACOWNIK", "ID_PRACOWNIK");
            ViewBag.ID_SPECJALIZACJA = new SelectList(db.SPECJALIZACJAs, "ID_SPECJALIZACJA", "NAZWA");
            return View();
        }

        // POST: Pracownik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PRACOWNIK,IMIE,NAZWISKO,ADRES,EMAIL_KONTAKTOWY,ID_SPECJALIZACJA,ID_ODDZIAL_PRACOWNIK")] PRACOWNIK pRACOWNIK)
        {
            if (ModelState.IsValid)
            {
                db.PRACOWNIKs.Add(pRACOWNIK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ODDZIAL_PRACOWNIK = new SelectList(db.ODDZIAL_PRACOWNIK, "ID_ODDZIAL_PRACOWNIK", "ID_ODDZIAL_PRACOWNIK", pRACOWNIK.ID_ODDZIAL_PRACOWNIK);
            ViewBag.ID_PRACOWNIK = new SelectList(db.DYZURs, "ID_PRACOWNIK", "ID_PRACOWNIK", pRACOWNIK.ID_PRACOWNIK);
            ViewBag.ID_SPECJALIZACJA = new SelectList(db.SPECJALIZACJAs, "ID_SPECJALIZACJA", "NAZWA", pRACOWNIK.ID_SPECJALIZACJA);
            return View(pRACOWNIK);
        }

        // GET: Pracownik/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRACOWNIK pRACOWNIK = db.PRACOWNIKs.Find(id);
            if (pRACOWNIK == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ODDZIAL_PRACOWNIK = new SelectList(db.ODDZIAL_PRACOWNIK, "ID_ODDZIAL_PRACOWNIK", "ID_ODDZIAL_PRACOWNIK", pRACOWNIK.ID_ODDZIAL_PRACOWNIK);
            ViewBag.ID_PRACOWNIK = new SelectList(db.DYZURs, "ID_PRACOWNIK", "ID_PRACOWNIK", pRACOWNIK.ID_PRACOWNIK);
            ViewBag.ID_SPECJALIZACJA = new SelectList(db.SPECJALIZACJAs, "ID_SPECJALIZACJA", "NAZWA", pRACOWNIK.ID_SPECJALIZACJA);
            return View(pRACOWNIK);
        }

        // POST: Pracownik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PRACOWNIK,IMIE,NAZWISKO,ADRES,EMAIL_KONTAKTOWY,ID_SPECJALIZACJA,ID_ODDZIAL_PRACOWNIK")] PRACOWNIK pRACOWNIK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRACOWNIK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ODDZIAL_PRACOWNIK = new SelectList(db.ODDZIAL_PRACOWNIK, "ID_ODDZIAL_PRACOWNIK", "ID_ODDZIAL_PRACOWNIK", pRACOWNIK.ID_ODDZIAL_PRACOWNIK);
            ViewBag.ID_PRACOWNIK = new SelectList(db.DYZURs, "ID_PRACOWNIK", "ID_PRACOWNIK", pRACOWNIK.ID_PRACOWNIK);
            ViewBag.ID_SPECJALIZACJA = new SelectList(db.SPECJALIZACJAs, "ID_SPECJALIZACJA", "NAZWA", pRACOWNIK.ID_SPECJALIZACJA);
            return View(pRACOWNIK);
        }

        // GET: Pracownik/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRACOWNIK pRACOWNIK = db.PRACOWNIKs.Find(id);
            if (pRACOWNIK == null)
            {
                return HttpNotFound();
            }
            return View(pRACOWNIK);
        }

        // POST: Pracownik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRACOWNIK pRACOWNIK = db.PRACOWNIKs.Find(id);
            db.PRACOWNIKs.Remove(pRACOWNIK);
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
