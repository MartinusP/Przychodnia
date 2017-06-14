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
    public class OddzialPracownikController : Controller
    {
        private PRZYCHODNIAEntities db = new PRZYCHODNIAEntities();

        // GET: OddzialPracownik
        public async Task<ActionResult> Index()
        {
            var oddzial_pracownik = db.ODDZIAL_PRACOWNIK.Include(o => o.ODDZIAL).Include(o => o.PRACOWNIK);
            return View(await oddzial_pracownik.ToListAsync());
        }

        // GET: OddzialPracownik/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ODDZIAL_PRACOWNIK oddzial_pracownik = await db.ODDZIAL_PRACOWNIK.FindAsync(id);
            if (oddzial_pracownik == null)
            {
                return HttpNotFound();
            }
            return View(oddzial_pracownik);
        }

        // GET: OddzialPracownik/Create
        public ActionResult Create()
        {
            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALY, "ID_ODDZIAL", "NAZWA");
            ViewBag.ID_PRACOWNIK = new SelectList(db.PRACOWNICY, "ID_PRACOWNIK", "IMIE");
            return View();
        }

        // POST: OddzialPracownik/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_ODDZIAL_PRACOWNIK,ID_PRACOWNIK,ID_ODDZIAL")] ODDZIAL_PRACOWNIK oddzial_pracownik)
        {
            if (ModelState.IsValid)
            {
                db.ODDZIAL_PRACOWNIK.Add(oddzial_pracownik);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALY, "ID_ODDZIAL", "NAZWA", oddzial_pracownik.ID_ODDZIAL);
            ViewBag.ID_PRACOWNIK = new SelectList(db.PRACOWNICY, "ID_PRACOWNIK", "IMIE", oddzial_pracownik.ID_PRACOWNIK);
            return View(oddzial_pracownik);
        }

        // GET: OddzialPracownik/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ODDZIAL_PRACOWNIK oddzial_pracownik = await db.ODDZIAL_PRACOWNIK.FindAsync(id);
            if (oddzial_pracownik == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALY, "ID_ODDZIAL", "NAZWA", oddzial_pracownik.ID_ODDZIAL);
            ViewBag.ID_PRACOWNIK = new SelectList(db.PRACOWNICY, "ID_PRACOWNIK", "IMIE", oddzial_pracownik.ID_PRACOWNIK);
            return View(oddzial_pracownik);
        }

        // POST: OddzialPracownik/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_ODDZIAL_PRACOWNIK,ID_PRACOWNIK,ID_ODDZIAL")] ODDZIAL_PRACOWNIK oddzial_pracownik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oddzial_pracownik).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALY, "ID_ODDZIAL", "NAZWA", oddzial_pracownik.ID_ODDZIAL);
            ViewBag.ID_PRACOWNIK = new SelectList(db.PRACOWNICY, "ID_PRACOWNIK", "IMIE", oddzial_pracownik.ID_PRACOWNIK);
            return View(oddzial_pracownik);
        }

        // GET: OddzialPracownik/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ODDZIAL_PRACOWNIK oddzial_pracownik = await db.ODDZIAL_PRACOWNIK.FindAsync(id);
            if (oddzial_pracownik == null)
            {
                return HttpNotFound();
            }
            return View(oddzial_pracownik);
        }

        // POST: OddzialPracownik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ODDZIAL_PRACOWNIK oddzial_pracownik = await db.ODDZIAL_PRACOWNIK.FindAsync(id);
            db.ODDZIAL_PRACOWNIK.Remove(oddzial_pracownik);
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
