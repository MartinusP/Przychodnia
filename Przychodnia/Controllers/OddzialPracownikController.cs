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
            var oDDZIAL_PRACOWNIK = db.ODDZIAL_PRACOWNIK.Include(o => o.ODDZIAL).Include(o => o.PRACOWNIK);
            return View(await oDDZIAL_PRACOWNIK.ToListAsync());
        }

        // GET: OddzialPracownik/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ODDZIAL_PRACOWNIK oDDZIAL_PRACOWNIK = await db.ODDZIAL_PRACOWNIK.FindAsync(id);
            if (oDDZIAL_PRACOWNIK == null)
            {
                return HttpNotFound();
            }
            return View(oDDZIAL_PRACOWNIK);
        }

        // GET: OddzialPracownik/Create
        public ActionResult Create()
        {
            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALs, "ID_ODDZIAL", "NAZWA");
            ViewBag.ID_PRACOWNIK = new SelectList(db.PRACOWNIKs, "ID_PRACOWNIK", "IMIE");
            return View();
        }

        // POST: OddzialPracownik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_ODDZIAL_PRACOWNIK,ID_PRACOWNIK,ID_ODDZIAL")] ODDZIAL_PRACOWNIK oDDZIAL_PRACOWNIK)
        {
            if (ModelState.IsValid)
            {
                db.ODDZIAL_PRACOWNIK.Add(oDDZIAL_PRACOWNIK);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALs, "ID_ODDZIAL", "NAZWA", oDDZIAL_PRACOWNIK.ID_ODDZIAL);
            ViewBag.ID_PRACOWNIK = new SelectList(db.PRACOWNIKs, "ID_PRACOWNIK", "IMIE", oDDZIAL_PRACOWNIK.ID_PRACOWNIK);
            return View(oDDZIAL_PRACOWNIK);
        }

        // GET: OddzialPracownik/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ODDZIAL_PRACOWNIK oDDZIAL_PRACOWNIK = await db.ODDZIAL_PRACOWNIK.FindAsync(id);
            if (oDDZIAL_PRACOWNIK == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALs, "ID_ODDZIAL", "NAZWA", oDDZIAL_PRACOWNIK.ID_ODDZIAL);
            ViewBag.ID_PRACOWNIK = new SelectList(db.PRACOWNIKs, "ID_PRACOWNIK", "IMIE", oDDZIAL_PRACOWNIK.ID_PRACOWNIK);
            return View(oDDZIAL_PRACOWNIK);
        }

        // POST: OddzialPracownik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_ODDZIAL_PRACOWNIK,ID_PRACOWNIK,ID_ODDZIAL")] ODDZIAL_PRACOWNIK oDDZIAL_PRACOWNIK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oDDZIAL_PRACOWNIK).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALs, "ID_ODDZIAL", "NAZWA", oDDZIAL_PRACOWNIK.ID_ODDZIAL);
            ViewBag.ID_PRACOWNIK = new SelectList(db.PRACOWNIKs, "ID_PRACOWNIK", "IMIE", oDDZIAL_PRACOWNIK.ID_PRACOWNIK);
            return View(oDDZIAL_PRACOWNIK);
        }

        // GET: OddzialPracownik/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ODDZIAL_PRACOWNIK oDDZIAL_PRACOWNIK = await db.ODDZIAL_PRACOWNIK.FindAsync(id);
            if (oDDZIAL_PRACOWNIK == null)
            {
                return HttpNotFound();
            }
            return View(oDDZIAL_PRACOWNIK);
        }

        // POST: OddzialPracownik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ODDZIAL_PRACOWNIK oDDZIAL_PRACOWNIK = await db.ODDZIAL_PRACOWNIK.FindAsync(id);
            db.ODDZIAL_PRACOWNIK.Remove(oDDZIAL_PRACOWNIK);
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
