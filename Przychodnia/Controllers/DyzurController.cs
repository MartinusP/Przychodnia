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
    public class DyzurController : Controller
    {
        private PRZYCHODNIAEntities db = new PRZYCHODNIAEntities();

        // GET: Dyzur
        public async Task<ActionResult> Index()
        {
            var dyzury = db.DYZURY.Include(d => d.ODDZIAL).Include(d => d.PRACOWNIK);
            return View(await dyzury.ToListAsync());
        }

        // GET: Dyzur/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DYZUR dyzur = await db.DYZURY.FindAsync(id);
            if (dyzur == null)
            {
                return HttpNotFound();
            }
            return View(dyzur);
        }

        // GET: Dyzur/Create
        public ActionResult Create()
        {
            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALY, "ID_ODDZIAL", "NAZWA");
            ViewBag.ID_PRACOWNIK = new SelectList(db.PRACOWNICY, "ID_PRACOWNIK", "IMIE");
            return View();
        }

        // POST: Dyzur/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_PRACOWNIK,DZIEN_DYZURU,OD,DO,ID_ODDZIAL")] DYZUR dyzur)
        {
            if (ModelState.IsValid)
            {
                db.DYZURY.Add(dyzur);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALY, "ID_ODDZIAL", "NAZWA", dyzur.ID_ODDZIAL);
            ViewBag.ID_PRACOWNIK = new SelectList(db.PRACOWNICY, "ID_PRACOWNIK", "IMIE", dyzur.ID_PRACOWNIK);
            return View(dyzur);
        }

        // GET: Dyzur/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DYZUR dyzur = await db.DYZURY.FindAsync(id);
            if (dyzur == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALY, "ID_ODDZIAL", "NAZWA", dyzur.ID_ODDZIAL);
            ViewBag.ID_PRACOWNIK = new SelectList(db.PRACOWNICY, "ID_PRACOWNIK", "IMIE", dyzur.ID_PRACOWNIK);
            return View(dyzur);
        }

        // POST: Dyzur/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_PRACOWNIK,DZIEN_DYZURU,OD,DO,ID_ODDZIAL")] DYZUR dyzur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dyzur).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALY, "ID_ODDZIAL", "NAZWA", dyzur.ID_ODDZIAL);
            ViewBag.ID_PRACOWNIK = new SelectList(db.PRACOWNICY, "ID_PRACOWNIK", "IMIE", dyzur.ID_PRACOWNIK);
            return View(dyzur);
        }

        // GET: Dyzur/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DYZUR dyzur = await db.DYZURY.FindAsync(id);
            if (dyzur == null)
            {
                return HttpNotFound();
            }
            return View(dyzur);
        }

        // POST: Dyzur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DYZUR dyzur = await db.DYZURY.FindAsync(id);
            db.DYZURY.Remove(dyzur);
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
