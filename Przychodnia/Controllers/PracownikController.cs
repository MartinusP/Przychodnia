using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Przychodnia.Context;
using Przychodnia.Models;

namespace Przychodnia
{
    public class PracownikController : Controller
    {
        private PRZYCHODNIAEntities db = new PRZYCHODNIAEntities();

        // GET: Pracownik
        public ActionResult Index()
        {
            return View(db.PRACOWNICY.ToList());
        }

        // GET: Pracownik/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRACOWNIK pracownik = db.PRACOWNICY.Find(id);
            if (pracownik == null)
            {
                return HttpNotFound();
            }
            return View(pracownik);
        }

        // GET: Pracownik/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pracownik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PRACOWNIK,IMIE,NAZWISKO,ADRES,EMAIL_KONTAKTOWY")] PRACOWNIK pracownik)
        {
            if (ModelState.IsValid)
            {
                db.PRACOWNICY.Add(pracownik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pracownik);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRACOWNIK pracownik = db.PRACOWNICY.Find(id);
            if (pracownik == null)
            {
                return HttpNotFound();
            }

            var Results = from b in db.ODDZIALY
                          select new
                          {
                              b.ID_ODDZIAL,
                              b.NAZWA,
                              Checked = ((from ab in db.ODDZIAL_PRACOWNICY
                                          where (ab.ID_PRACOWNIK == id) & (ab.ID_ODDZIAL == b.ID_ODDZIAL)
                                          select ab).Count() > 0)
                          };

            var Results2 = from b in db.SPECJALIZACJE
                           select new
                           {
                               b.ID_SPECJALIZACJA,
                               b.NAZWA,
                               Checked = ((from ab in db.Pracownik_Specjalizacje
                                           where (ab.ID_PRACOWNIK == id) & (ab.ID_SPECJALIZACJA == b.ID_SPECJALIZACJA)
                                           select ab).Count() > 0)
                           };



            var pracownikViewModel = new PracownikViewModel();

            pracownikViewModel.ID_PRACOWNIK = id.Value;
            pracownikViewModel.IMIE = pracownik.IMIE;
            pracownikViewModel.NAZWISKO = pracownik.NAZWISKO;
            pracownikViewModel.ADRES = pracownik.ADRES;
            pracownikViewModel.EMAIL_KONTAKTOWY = pracownik.EMAIL_KONTAKTOWY;

            var oddzialCheckBoxList = new List<CheckBoxViewModel>();
            var specjalizacjaCheckBoxList = new List<CheckBoxViewModel>();

            foreach (var item in Results)
            {
                oddzialCheckBoxList.Add(new CheckBoxViewModel { ID = item.ID_ODDZIAL, Name = item.NAZWA, Checked = item.Checked });
            }

            foreach (var item in Results2)
            {
                specjalizacjaCheckBoxList.Add(new CheckBoxViewModel { ID = item.ID_SPECJALIZACJA, Name = item.NAZWA, Checked = item.Checked });
            }

            pracownikViewModel.ListaOddzialPracownicy = oddzialCheckBoxList;
            pracownikViewModel.ListaPracownicySpecjalizacje = specjalizacjaCheckBoxList;

            return View(pracownikViewModel);
        }

        // POST: /Authors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PracownikViewModel pracownik)
        {
            if (ModelState.IsValid)
            {
                var osoba = db.PRACOWNICY.Find(pracownik.ID_PRACOWNIK);

                osoba.IMIE = pracownik.IMIE;
                osoba.NAZWISKO = pracownik.NAZWISKO;
                osoba.ADRES = pracownik.ADRES;
                osoba.EMAIL_KONTAKTOWY = pracownik.EMAIL_KONTAKTOWY;

                foreach (var item in db.ODDZIAL_PRACOWNICY)
                {
                    if (item.ID_PRACOWNIK == pracownik.ID_PRACOWNIK)
                    {
                        db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    }
                }

                foreach (var item in db.Pracownik_Specjalizacje)
                {
                    if (item.ID_PRACOWNIK == pracownik.ID_PRACOWNIK)
                    {
                        db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    }
                }

                foreach (var item in pracownik.ListaOddzialPracownicy)
                {
                    if (item.Checked)
                    {
                        db.ODDZIAL_PRACOWNICY.Add(new ODDZIAL_PRACOWNIK() { ID_PRACOWNIK = pracownik.ID_PRACOWNIK, ID_ODDZIAL = item.ID });
                    }
                }

                foreach (var item in pracownik.ListaPracownicySpecjalizacje)
                {
                    if (item.Checked)
                    {
                        db.Pracownik_Specjalizacje.Add(new Pracownik_Specjalizacja() { ID_PRACOWNIK = pracownik.ID_PRACOWNIK, ID_SPECJALIZACJA = item.ID });
                    }
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pracownik);
        }


        // GET: Pracownik/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRACOWNIK pracownik = db.PRACOWNICY.Find(id);
            if (pracownik == null)
            {
                return HttpNotFound();
            }
            return View(pracownik);
        }

        // POST: Pracownik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRACOWNIK pracownik = db.PRACOWNICY.Find(id);
            db.PRACOWNICY.Remove(pracownik);
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
