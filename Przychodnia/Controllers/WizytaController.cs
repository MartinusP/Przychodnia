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
            var wIZYTAs = db.WIZYTAs.Include(w => w.ODDZIAL).Include(w => w.PACJENT).Include(w => w.PRACOWNIK).Include(w => w.RECEPTA).Include(w => w.SALA);
            return View(await wIZYTAs.ToListAsync());
        }

        // GET: Wizyta/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WIZYTA wIZYTA = await db.WIZYTAs.FindAsync(id);
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
            ViewBag.ID_RECEPTA = new SelectList(db.RECEPTAs, "ID_RECEPTA", "NAZWA_LEKU");
            ViewBag.ID_SALA = new SelectList(db.SALAs, "ID_SALA", "ID_SALA");
            return View();
        }

        // POST: Wizyta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_WIZYTA,DATA_WIZYTY,ID_SALA,ID_PRACOWNIK,ID_ODDZIAL,ID_PACJENT,ID_RECEPTA,UWAGI")] WIZYTA wIZYTA)
        {
            if (ModelState.IsValid)
            {
                db.WIZYTAs.Add(wIZYTA);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALs, "ID_ODDZIAL", "NAZWA", wIZYTA.ID_ODDZIAL);
            ViewBag.ID_PACJENT = new SelectList(db.PACJENTs, "ID_PACJENT", "IMIE", wIZYTA.ID_PACJENT);
            ViewBag.ID_PRACOWNIK = new SelectList(db.PRACOWNIKs, "ID_PRACOWNIK", "IMIE", wIZYTA.ID_PRACOWNIK);
            ViewBag.ID_RECEPTA = new SelectList(db.RECEPTAs, "ID_RECEPTA", "NAZWA_LEKU", wIZYTA.ID_RECEPTA);
            ViewBag.ID_SALA = new SelectList(db.SALAs, "ID_SALA", "ID_SALA", wIZYTA.ID_SALA);
            return View(wIZYTA);
        }

        // GET: Wizyta/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WIZYTA wIZYTA = await db.WIZYTAs.FindAsync(id);
            if (wIZYTA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALs, "ID_ODDZIAL", "NAZWA", wIZYTA.ID_ODDZIAL);
            ViewBag.ID_PACJENT = new SelectList(db.PACJENTs, "ID_PACJENT", "IMIE", wIZYTA.ID_PACJENT);
            ViewBag.ID_PRACOWNIK = new SelectList(db.PRACOWNIKs, "ID_PRACOWNIK", "IMIE", wIZYTA.ID_PRACOWNIK);
            ViewBag.ID_RECEPTA = new SelectList(db.RECEPTAs, "ID_RECEPTA", "NAZWA_LEKU", wIZYTA.ID_RECEPTA);
            ViewBag.ID_SALA = new SelectList(db.SALAs, "ID_SALA", "ID_SALA", wIZYTA.ID_SALA);
            return View(wIZYTA);
        }

        // POST: Wizyta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_WIZYTA,DATA_WIZYTY,ID_SALA,ID_PRACOWNIK,ID_ODDZIAL,ID_PACJENT,ID_RECEPTA,UWAGI")] WIZYTA wIZYTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wIZYTA).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALs, "ID_ODDZIAL", "NAZWA", wIZYTA.ID_ODDZIAL);
            ViewBag.ID_PACJENT = new SelectList(db.PACJENTs, "ID_PACJENT", "IMIE", wIZYTA.ID_PACJENT);
            ViewBag.ID_PRACOWNIK = new SelectList(db.PRACOWNIKs, "ID_PRACOWNIK", "IMIE", wIZYTA.ID_PRACOWNIK);
            ViewBag.ID_RECEPTA = new SelectList(db.RECEPTAs, "ID_RECEPTA", "NAZWA_LEKU", wIZYTA.ID_RECEPTA);
            ViewBag.ID_SALA = new SelectList(db.SALAs, "ID_SALA", "ID_SALA", wIZYTA.ID_SALA);
            return View(wIZYTA);
        }

        // GET: Wizyta/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WIZYTA wIZYTA = await db.WIZYTAs.FindAsync(id);
            if (wIZYTA == null)
            {
                return HttpNotFound();
            }
            return View(wIZYTA);
        }

        // POST: Wizyta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            WIZYTA wIZYTA = await db.WIZYTAs.FindAsync(id);
            db.WIZYTAs.Remove(wIZYTA);
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
