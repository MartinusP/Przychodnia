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
    public class PacjentController : Controller
    {
        private PRZYCHODNIAEntities db = new PRZYCHODNIAEntities();

        // GET: Pacjent
        public ActionResult Index()
        {
            return View(db.PACJENCI.ToList());
        }

        // GET: Pacjent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PACJENT pacjent = db.PACJENCI.Find(id);
            if (pacjent == null)
            {
                return HttpNotFound();
            }
            return View(pacjent);
        }

        // GET: Pacjent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pacjent/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PACJENT,IMIE,NAZWISKO,ADRES,PESEL,TELEFON_KONTAKTOWY,EMAIL_KONTAKTOWY")] PACJENT pacjent)
        {
            if (ModelState.IsValid)
            {
                db.PACJENCI.Add(pacjent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pacjent);
        }

        // GET: Pacjent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PACJENT pacjent = db.PACJENCI.Find(id);
            if (pacjent == null)
            {
                return HttpNotFound();
            }
            return View(pacjent);
        }

        // POST: Pacjent/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PACJENT,IMIE,NAZWISKO,ADRES,PESEL,TELEFON_KONTAKTOWY,EMAIL_KONTAKTOWY")] PACJENT pacjent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pacjent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pacjent);
        }

        // GET: Pacjent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PACJENT pacjent = db.PACJENCI.Find(id);
            if (pacjent == null)
            {
                return HttpNotFound();
            }
            return View(pacjent);
        }

        // POST: Pacjent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PACJENT pacjent = db.PACJENCI.Find(id);
            db.PACJENCI.Remove(pacjent);
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
