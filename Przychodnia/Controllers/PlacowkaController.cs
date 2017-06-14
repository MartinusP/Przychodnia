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
    public class PlacowkaController : Controller
    {
        private PRZYCHODNIAEntities db = new PRZYCHODNIAEntities();

        // GET: Placowka
        public async Task<ActionResult> Index()
        {
            var placowki = db.PLACOWKI.Include(p => p.ODDZIAL);
            return View(await placowki.ToListAsync());
        }

        // GET: Placowka/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PLACOWKA placowka = await db.PLACOWKI.FindAsync(id);
            if (placowka == null)
            {
                return HttpNotFound();
            }
            return View(placowka);
        }

        // GET: Placowka/Create
        public ActionResult Create()
        {
            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALY, "ID_ODDZIAL", "NAZWA");
            return View();
        }

        // POST: Placowka/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_PLACOWKA,NAZWA,MIEJSCOWOSC,ADRES,ID_ODDZIAL")] PLACOWKA placowka)
        {
            if (ModelState.IsValid)
            {
                db.PLACOWKI.Add(placowka);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALY, "ID_ODDZIAL", "NAZWA", placowka.ID_ODDZIAL);
            return View(placowka);
        }

        // GET: Placowka/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PLACOWKA placowka = await db.PLACOWKI.FindAsync(id);
            if (placowka == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALY, "ID_ODDZIAL", "NAZWA", placowka.ID_ODDZIAL);
            return View(placowka);
        }

        // POST: Placowka/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_PLACOWKA,NAZWA,MIEJSCOWOSC,ADRES,ID_ODDZIAL")] PLACOWKA placowka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(placowka).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALY, "ID_ODDZIAL", "NAZWA", placowka.ID_ODDZIAL);
            return View(placowka);
        }

        // GET: Placowka/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PLACOWKA placowka = await db.PLACOWKI.FindAsync(id);
            if (placowka == null)
            {
                return HttpNotFound();
            }
            return View(placowka);
        }

        // POST: Placowka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PLACOWKA placowka = await db.PLACOWKI.FindAsync(id);
            db.PLACOWKI.Remove(placowka);
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
