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
    public class PracownikController : Controller
    {
        private PRZYCHODNIAEntities db = new PRZYCHODNIAEntities();

        // GET: Pracownik
        public async Task<ActionResult> Index()
        {
            //var pRACOWNICY = db.PRACOWNICY.Include(p => p.ODDZIAL_PRACOWNIK1).Include(p => p.DYZUR).Include(p => p.SPECJALIZACJA);
            //return View(await pRACOWNICY.ToListAsync());
        }

        // GET: Pracownik/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRACOWNIK pRACOWNIK = await db.PRACOWNICY.FindAsync(id);
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
            ViewBag.ID_PRACOWNIK = new SelectList(db.DYZURY, "ID_PRACOWNIK", "ID_PRACOWNIK");
            ViewBag.ID_SPECJALIZACJA = new SelectList(db.SPECJALIZACJE, "ID_SPECJALIZACJA", "NAZWA");
            return View();
        }

        // POST: Pracownik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_PRACOWNIK,IMIE,NAZWISKO,ADRES,EMAIL_KONTAKTOWY,ID_SPECJALIZACJA,ID_ODDZIAL_PRACOWNIK")] PRACOWNIK pRACOWNIK)
        {
            if (ModelState.IsValid)
            {
                db.PRACOWNICY.Add(pRACOWNIK);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            //ViewBag.ID_ODDZIAL_PRACOWNIK = new SelectList(db.ODDZIAL_PRACOWNIK, "ID_ODDZIAL_PRACOWNIK", "ID_ODDZIAL_PRACOWNIK", pRACOWNIK.ID_ODDZIAL_PRACOWNIK);
            ViewBag.ID_PRACOWNIK = new SelectList(db.DYZURY, "ID_PRACOWNIK", "ID_PRACOWNIK", pRACOWNIK.ID_PRACOWNIK);
            ViewBag.ID_SPECJALIZACJA = new SelectList(db.SPECJALIZACJE, "ID_SPECJALIZACJA", "NAZWA", pRACOWNIK.ID_SPECJALIZACJA);
            return View(pRACOWNIK);
        }

        // GET: Pracownik/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRACOWNIK pRACOWNIK = await db.PRACOWNICY.FindAsync(id);
            if (pRACOWNIK == null)
            {
                return HttpNotFound();
            }
            //ViewBag.ID_ODDZIAL_PRACOWNIK = new SelectList(db.ODDZIAL_PRACOWNIK, "ID_ODDZIAL_PRACOWNIK", "ID_ODDZIAL_PRACOWNIK", pRACOWNIK.ID_ODDZIAL_PRACOWNIK);
            ViewBag.ID_PRACOWNIK = new SelectList(db.DYZURY, "ID_PRACOWNIK", "ID_PRACOWNIK", pRACOWNIK.ID_PRACOWNIK);
            ViewBag.ID_SPECJALIZACJA = new SelectList(db.SPECJALIZACJE, "ID_SPECJALIZACJA", "NAZWA", pRACOWNIK.ID_SPECJALIZACJA);
            return View(pRACOWNIK);
        }

        // POST: Pracownik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_PRACOWNIK,IMIE,NAZWISKO,ADRES,EMAIL_KONTAKTOWY,ID_SPECJALIZACJA,ID_ODDZIAL_PRACOWNIK")] PRACOWNIK pRACOWNIK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRACOWNIK).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            //ViewBag.ID_ODDZIAL_PRACOWNIK = new SelectList(db.ODDZIAL_PRACOWNIK, "ID_ODDZIAL_PRACOWNIK", "ID_ODDZIAL_PRACOWNIK", pRACOWNIK.ID_ODDZIAL_PRACOWNIK);
            ViewBag.ID_PRACOWNIK = new SelectList(db.DYZURY, "ID_PRACOWNIK", "ID_PRACOWNIK", pRACOWNIK.ID_PRACOWNIK);
            ViewBag.ID_SPECJALIZACJA = new SelectList(db.SPECJALIZACJE, "ID_SPECJALIZACJA", "NAZWA", pRACOWNIK.ID_SPECJALIZACJA);
            return View(pRACOWNIK);
        }

        // GET: Pracownik/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRACOWNIK pRACOWNIK = await db.PRACOWNICY.FindAsync(id);
            if (pRACOWNIK == null)
            {
                return HttpNotFound();
            }
            return View(pRACOWNIK);
        }

        // POST: Pracownik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PRACOWNIK pRACOWNIK = await db.PRACOWNICY.FindAsync(id);
            db.PRACOWNICY.Remove(pRACOWNIK);
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
