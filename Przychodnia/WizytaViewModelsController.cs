using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Przychodnia.Context;
using Przychodnia.Models;

namespace Przychodnia
{
    public class WizytaViewModelsController : Controller
    {
        private PRZYCHODNIAEntities db = new PRZYCHODNIAEntities();

        // GET: WizytaViewModels
        public async Task<ActionResult> Index()
        {
            var wizytaViewModels = db.WizytaViewModels.Include(w => w.ODDZIAL).Include(w => w.PACJENT).Include(w => w.PRACOWNIK).Include(w => w.SALA);
            return View(await wizytaViewModels.ToListAsync());
        }

        // GET: WizytaViewModels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WizytaViewModel wizytaViewModel = await db.WizytaViewModels.FindAsync(id);
            if (wizytaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(wizytaViewModel);
        }

        // GET: WizytaViewModels/Create
        public ActionResult Create()
        {
            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALY, "ID_ODDZIAL", "NAZWA");
            ViewBag.ID_PACJENT = new SelectList(db.PACJENCI, "ID_PACJENT", "IMIE");
            ViewBag.ID_PRACOWNIK = new SelectList(db.PRACOWNICY, "ID_PRACOWNIK", "IMIE");
            ViewBag.ID_SALA = new SelectList(db.SALE, "ID_SALA", "ID_SALA");
            return View();
        }

        // POST: WizytaViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_WIZYTA,DATA_WIZYTY,ID_SALA,ID_PRACOWNIK,ID_ODDZIAL,ID_PACJENT,UWAGI")] WizytaViewModel wizytaViewModel)
        {
            if (ModelState.IsValid)
            {
                db.WizytaViewModels.Add(wizytaViewModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALY, "ID_ODDZIAL", "NAZWA", wizytaViewModel.ID_ODDZIAL);
            ViewBag.ID_PACJENT = new SelectList(db.PACJENCI, "ID_PACJENT", "IMIE", wizytaViewModel.ID_PACJENT);
            ViewBag.ID_PRACOWNIK = new SelectList(db.PRACOWNICY, "ID_PRACOWNIK", "IMIE", wizytaViewModel.ID_PRACOWNIK);
            ViewBag.ID_SALA = new SelectList(db.SALE, "ID_SALA", "ID_SALA", wizytaViewModel.ID_SALA);
            return View(wizytaViewModel);
        }

        // GET: WizytaViewModels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WizytaViewModel wizytaViewModel = await db.WizytaViewModels.FindAsync(id);
            if (wizytaViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALY, "ID_ODDZIAL", "NAZWA", wizytaViewModel.ID_ODDZIAL);
            ViewBag.ID_PACJENT = new SelectList(db.PACJENCI, "ID_PACJENT", "IMIE", wizytaViewModel.ID_PACJENT);
            ViewBag.ID_PRACOWNIK = new SelectList(db.PRACOWNICY, "ID_PRACOWNIK", "IMIE", wizytaViewModel.ID_PRACOWNIK);
            ViewBag.ID_SALA = new SelectList(db.SALE, "ID_SALA", "ID_SALA", wizytaViewModel.ID_SALA);


            var Results = from b in db.RECEPTY
                          select new
                          {
                              b.ID_RECEPTA,
                              b.DATA_WYKORZYSTANIA,
                              Checked = ((from ab in db.Recepta_Leki
                                          where (ab.ID_RECEPTA == id) & (ab.ID_LEK == b.ID_LEKU)
                                          select ab).Count() > 0)
                          };
            var pracownikViewModel = new WizytaViewModel();


            return View(wizytaViewModel);
        }

        // POST: WizytaViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_WIZYTA,DATA_WIZYTY,ID_SALA,ID_PRACOWNIK,ID_ODDZIAL,ID_PACJENT,UWAGI")] WizytaViewModel wizytaViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wizytaViewModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALY, "ID_ODDZIAL", "NAZWA", wizytaViewModel.ID_ODDZIAL);
            ViewBag.ID_PACJENT = new SelectList(db.PACJENCI, "ID_PACJENT", "IMIE", wizytaViewModel.ID_PACJENT);
            ViewBag.ID_PRACOWNIK = new SelectList(db.PRACOWNICY, "ID_PRACOWNIK", "IMIE", wizytaViewModel.ID_PRACOWNIK);
            ViewBag.ID_SALA = new SelectList(db.SALE, "ID_SALA", "ID_SALA", wizytaViewModel.ID_SALA);
            return View(wizytaViewModel);
        }

        // GET: WizytaViewModels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WizytaViewModel wizytaViewModel = await db.WizytaViewModels.FindAsync(id);
            if (wizytaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(wizytaViewModel);
        }

        // POST: WizytaViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            WizytaViewModel wizytaViewModel = await db.WizytaViewModels.FindAsync(id);
            db.WizytaViewModels.Remove(wizytaViewModel);
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
