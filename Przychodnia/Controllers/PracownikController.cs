using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Przychodnia.Models;
using Przychodnia.Context;

namespace Przychodnia
{
    public class PracownikController : Controller
    {
        private PRZYCHODNIAEntities db = new PRZYCHODNIAEntities();

        // GET: Pracownik
        public async Task<ActionResult> Index()
        {
            var pRACOWNIKs = db.PRACOWNICY.Include(p => p.SPECJALIZACJA);
            return View(await pRACOWNIKs.ToListAsync());
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
            ViewBag.ID_SPECJALIZACJA = new SelectList(db.SPECJALIZACJE, "ID_SPECJALIZACJA", "NAZWA");
            return View();
        }

        // POST: Pracownik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IMIE,NAZWISKO,ADRES,EMAIL_KONTAKTOWY,ID_SPECJALIZACJA")] PRACOWNIK pRACOWNIK)
        {
            if (ModelState.IsValid)
            {
                db.PRACOWNICY.Add(pRACOWNIK);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID_SPECJALIZACJA = new SelectList(db.SPECJALIZACJE, "ID_SPECJALIZACJA", "NAZWA", pRACOWNIK.ID_SPECJALIZACJA);
            return View(pRACOWNIK);
        }

        // GET: Pracownik/Edit/5
            public  ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRACOWNIK pRACOWNIK = db.PRACOWNICY.Find(id);
            if (pRACOWNIK == null)
            {
                return HttpNotFound();
            }

            var result = from x in db.ODDZIALY
                         select new
                         {
                             x.ID_ODDZIAL,
                             x.NAZWA,
                             Checked = ((from ab in db.ODDZIAL_PRACOWNIK
                                         where (ab.ID_PRACOWNIK == id) & (ab.ID_ODDZIAL == x.ID_ODDZIAL)
                                         select ab).Count() > 0)
                         };

            var MyViewModel = new PracownikOddzialViewModel();
            MyViewModel.ID_PRACOWNIK = id.Value;
            MyViewModel.Nazwisko = pRACOWNIK.NAZWISKO;
     
            var MyCheckBoxList = new List<CheckBoxViewModel>();

            foreach (var item in result)
            {
                MyCheckBoxList.Add(new Models.CheckBoxViewModel
                {
                    ID_CheckBoxViewModel = item.ID_ODDZIAL,
                    Nazwa = item.NAZWA,
                    Zaznaczenie = item.Checked
                });
            }

            MyViewModel.Oddzialy = MyCheckBoxList;

         //ViewBag.ID_SPECJALIZACJA = new SelectList(db.SPECJALIZACJE, "ID_SPECJALIZACJA", "NAZWA", pRACOWNIK.ID_SPECJALIZACJA);
            return View(MyViewModel);
        }

        // POST: Pracownik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PracownikOddzialViewModel pRACOWNIK)
        {
            if (ModelState.IsValid)
            {
                var Pracownik = db.PRACOWNICY.Find(pRACOWNIK.ID_PRACOWNIK);
                //Pracownik.NAZWISKO = pRACOWNIK.Nazwisko;
                
                foreach (var item in db.ODDZIAL_PRACOWNIK)
                {
                    if(item.ID_PRACOWNIK == pRACOWNIK.ID_PRACOWNIK)
                    {
                        db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    }
                }

                foreach (var item in pRACOWNIK.Oddzialy)
                {
                    if (item.Zaznaczenie)
                    {
                        db.ODDZIAL_PRACOWNIK.Add(new ODDZIAL_PRACOWNIK()
                        {
                            ID_PRACOWNIK = pRACOWNIK.ID_PRACOWNIK,
                            ID_ODDZIAL = item.ID_CheckBoxViewModel
                        });
                    }
                }
                //db.Entry(pRACOWNIK).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            //ViewBag.ID_SPECJALIZACJA = new SelectList(db.SPECJALIZACJE, "ID_SPECJALIZACJA", "NAZWA", pRACOWNIK.ID_SPECJALIZACJA);
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
