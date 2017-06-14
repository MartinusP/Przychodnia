using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult> Index()
        {
            var wizyty = db.WIZYTY.Include(w => w.ODDZIAL).Include(w => w.PACJENT).Include(w => w.PRACOWNIK).Include(w => w.SALA);
            return View(await wizyty.ToListAsync());
        }

        // GET: Wizyta/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WIZYTA wizyta = await db.WIZYTY.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "ID_WIZYTA,DATA_WIZYTY,ID_SALA,ID_PRACOWNIK,ID_ODDZIAL,ID_PACJENT,UWAGI")] WIZYTA wizyta)
        {
            if (ModelState.IsValid)
            {
                db.WIZYTY.Add(wizyta);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALY, "ID_ODDZIAL", "NAZWA", wizyta.ID_ODDZIAL);
            ViewBag.ID_PACJENT = new SelectList(db.PACJENCI, "ID_PACJENT", "IMIE", wizyta.ID_PACJENT);
            ViewBag.ID_PRACOWNIK = new SelectList(db.PRACOWNICY, "ID_PRACOWNIK", "IMIE", wizyta.ID_PRACOWNIK);
            ViewBag.ID_SALA = new SelectList(db.SALE, "ID_SALA", "ID_SALA", wizyta.ID_SALA);
            return View(wizyta);
        }

        // GET: Wizyta/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WIZYTA wizyta = await db.WIZYTY.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "ID_WIZYTA,DATA_WIZYTY,ID_SALA,ID_PRACOWNIK,ID_ODDZIAL,ID_PACJENT,UWAGI")] WIZYTA wizyta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wizyta).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALY, "ID_ODDZIAL", "NAZWA", wizyta.ID_ODDZIAL);
            ViewBag.ID_PACJENT = new SelectList(db.PACJENCI, "ID_PACJENT", "IMIE", wizyta.ID_PACJENT);
            ViewBag.ID_PRACOWNIK = new SelectList(db.PRACOWNICY, "ID_PRACOWNIK", "IMIE", wizyta.ID_PRACOWNIK);
            ViewBag.ID_SALA = new SelectList(db.SALE, "ID_SALA", "ID_SALA", wizyta.ID_SALA);
            return View(wizyta);
        }

        // GET: Wizyta/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WIZYTA wizyta = await db.WIZYTY.FindAsync(id);
            if (wizyta == null)
            {
                return HttpNotFound();
            }
            return View(wizyta);
        }

        // POST: Wizyta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            WIZYTA wizyta = await db.WIZYTY.FindAsync(id);
            db.WIZYTY.Remove(wizyta);
            await db.SaveChangesAsync();
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
