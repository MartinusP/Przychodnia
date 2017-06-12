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
            var wIZYTAs = db.WIZYTAs.Include(w => w.ODDZIAL).Include(w => w.PACJENT).Include(w => w.PRACOWNIK).Include(w => w.SALA);
            return View(wIZYTAs.ToList());
        }

        // GET: Wizyta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WIZYTA wIZYTA = db.WIZYTAs.Find(id);
            if (wIZYTA == null)
            {
                return HttpNotFound();
            }
            return View(wIZYTA);
        }

        // GET: Wizyta/Create
        public ActionResult Create()
        {
            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALs, "ID_ODDZIAL", "NAZWA");
            ViewBag.ID_PACJENT = new SelectList(db.PACJENTs, "ID_PACJENT", "IMIE");
            ViewBag.ID_PRACOWNIK = new SelectList(db.PRACOWNIKs, "ID_PRACOWNIK", "IMIE");
            ViewBag.ID_SALA = new SelectList(db.SALAs, "ID_SALA", "ID_SALA");
            return View();
        }

        // POST: Wizyta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_WIZYTA,DATA_WIZYTY,ID_SALA,ID_PRACOWNIK,ID_ODDZIAL,ID_PACJENT,UWAGI")] WIZYTA wIZYTA)
        {
            if (ModelState.IsValid)
            {
                db.WIZYTAs.Add(wIZYTA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALs, "ID_ODDZIAL", "NAZWA", wIZYTA.ID_ODDZIAL);
            ViewBag.ID_PACJENT = new SelectList(db.PACJENTs, "ID_PACJENT", "IMIE", wIZYTA.ID_PACJENT);
            ViewBag.ID_PRACOWNIK = new SelectList(db.PRACOWNIKs, "ID_PRACOWNIK", "IMIE", wIZYTA.ID_PRACOWNIK);
            ViewBag.ID_SALA = new SelectList(db.SALAs, "ID_SALA", "ID_SALA", wIZYTA.ID_SALA);
            return View(wIZYTA);
        }

        // GET: Wizyta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WIZYTA wIZYTA = db.WIZYTAs.Find(id);
            if (wIZYTA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALs, "ID_ODDZIAL", "NAZWA", wIZYTA.ID_ODDZIAL);
            ViewBag.ID_PACJENT = new SelectList(db.PACJENTs, "ID_PACJENT", "IMIE", wIZYTA.ID_PACJENT);
            ViewBag.ID_PRACOWNIK = new SelectList(db.PRACOWNIKs, "ID_PRACOWNIK", "IMIE", wIZYTA.ID_PRACOWNIK);
            ViewBag.ID_SALA = new SelectList(db.SALAs, "ID_SALA", "ID_SALA", wIZYTA.ID_SALA);
            return View(wIZYTA);
        }

        // POST: Wizyta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_WIZYTA,DATA_WIZYTY,ID_SALA,ID_PRACOWNIK,ID_ODDZIAL,ID_PACJENT,UWAGI")] WIZYTA wIZYTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wIZYTA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALs, "ID_ODDZIAL", "NAZWA", wIZYTA.ID_ODDZIAL);
            ViewBag.ID_PACJENT = new SelectList(db.PACJENTs, "ID_PACJENT", "IMIE", wIZYTA.ID_PACJENT);
            ViewBag.ID_PRACOWNIK = new SelectList(db.PRACOWNIKs, "ID_PRACOWNIK", "IMIE", wIZYTA.ID_PRACOWNIK);
            ViewBag.ID_SALA = new SelectList(db.SALAs, "ID_SALA", "ID_SALA", wIZYTA.ID_SALA);
            return View(wIZYTA);
        }

        // GET: Wizyta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WIZYTA wIZYTA = db.WIZYTAs.Find(id);
            if (wIZYTA == null)
            {
                return HttpNotFound();
            }
            return View(wIZYTA);
        }

        // POST: Wizyta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WIZYTA wIZYTA = db.WIZYTAs.Find(id);
            db.WIZYTAs.Remove(wIZYTA);
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
