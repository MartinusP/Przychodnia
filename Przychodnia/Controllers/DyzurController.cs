using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
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
        public ActionResult Index()
        {
            var dyzury = db.DYZURY.Include(d => d.ODDZIAL).Include(d => d.PRACOWNIK);
            return View(dyzury.ToList());
        }

        // GET: Dyzur/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DYZUR dyzur = db.DYZURY.Find(id);
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
            ViewBag.ID_PRACOWNIK = new SelectList(db.PRACOWNICY, "ID_PRACOWNIK", "NazwiskoImie");
            return View();
        }

        // POST: Dyzur/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PRACOWNIK,DZIEN_DYZURU,OD,DO,ID_ODDZIAL")] DYZUR dyzur)
        {
            if (ModelState.IsValid)
            {
                db.DYZURY.Add(dyzur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALY, "ID_ODDZIAL", "NAZWA", dyzur.ID_ODDZIAL);
            ViewBag.ID_PRACOWNIK = new SelectList(db.PRACOWNICY, "ID_PRACOWNIK", "NazwiskoImie", dyzur.ID_PRACOWNIK);
            return View(dyzur);
        }

        // GET: Dyzur/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DYZUR dyzur = db.DYZURY.Find(id);
            if (dyzur == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALY, "ID_ODDZIAL", "NAZWA", dyzur.ID_ODDZIAL);
            ViewBag.ID_PRACOWNIK = new SelectList(db.PRACOWNICY, "ID_PRACOWNIK", "NazwiskoImie", dyzur.ID_PRACOWNIK);
            return View(dyzur);
        }

        // POST: Dyzur/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PRACOWNIK,DZIEN_DYZURU,OD,DO,ID_ODDZIAL")] DYZUR dyzur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dyzur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALY, "ID_ODDZIAL", "NAZWA", dyzur.ID_ODDZIAL);
            ViewBag.ID_PRACOWNIK = new SelectList(db.PRACOWNICY, "ID_PRACOWNIK", "NazwiskoImie", dyzur.ID_PRACOWNIK);
            return View(dyzur);
        }

        // GET: Dyzur/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DYZUR dyzur = db.DYZURY.Find(id);
            if (dyzur == null)
            {
                return HttpNotFound();
            }
            return View(dyzur);
        }

        // POST: Dyzur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DYZUR dyzur = db.DYZURY.Find(id);
            db.DYZURY.Remove(dyzur);
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
