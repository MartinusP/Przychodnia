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
            return View(db.PACJENTs.ToList());
        }

        // GET: Pacjent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PACJENT pACJENT = db.PACJENTs.Find(id);
            if (pACJENT == null)
            {
                return HttpNotFound();
            }
            return View(pACJENT);
        }

        // GET: Pacjent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pacjent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PACJENT,IMIE,NAZWISKO,ADRES,PESEL,TELEFON_KONTAKTOWY,EMAIL_KONTAKTOWY")] PACJENT pACJENT)
        {
            if (ModelState.IsValid)
            {
                db.PACJENTs.Add(pACJENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pACJENT);
        }

        // GET: Pacjent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PACJENT pACJENT = db.PACJENTs.Find(id);
            if (pACJENT == null)
            {
                return HttpNotFound();
            }
            return View(pACJENT);
        }

        // POST: Pacjent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PACJENT,IMIE,NAZWISKO,ADRES,PESEL,TELEFON_KONTAKTOWY,EMAIL_KONTAKTOWY")] PACJENT pACJENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pACJENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pACJENT);
        }

        // GET: Pacjent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PACJENT pACJENT = db.PACJENTs.Find(id);
            if (pACJENT == null)
            {
                return HttpNotFound();
            }
            return View(pACJENT);
        }

        // POST: Pacjent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PACJENT pACJENT = db.PACJENTs.Find(id);
            db.PACJENTs.Remove(pACJENT);
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
