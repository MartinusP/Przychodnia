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
    public class SpecjalizacjaController : Controller
    {
        private PRZYCHODNIAEntities db = new PRZYCHODNIAEntities();

        // GET: Specjalizacja
        public ActionResult Index()
        {
            return View(db.SPECJALIZACJAs.ToList());
        }

        // GET: Specjalizacja/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPECJALIZACJA sPECJALIZACJA = db.SPECJALIZACJAs.Find(id);
            if (sPECJALIZACJA == null)
            {
                return HttpNotFound();
            }
            return View(sPECJALIZACJA);
        }

        // GET: Specjalizacja/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Specjalizacja/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SPECJALIZACJA,NAZWA")] SPECJALIZACJA sPECJALIZACJA)
        {
            if (ModelState.IsValid)
            {
                db.SPECJALIZACJAs.Add(sPECJALIZACJA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sPECJALIZACJA);
        }

        // GET: Specjalizacja/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPECJALIZACJA sPECJALIZACJA = db.SPECJALIZACJAs.Find(id);
            if (sPECJALIZACJA == null)
            {
                return HttpNotFound();
            }
            return View(sPECJALIZACJA);
        }

        // POST: Specjalizacja/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SPECJALIZACJA,NAZWA")] SPECJALIZACJA sPECJALIZACJA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sPECJALIZACJA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sPECJALIZACJA);
        }

        // GET: Specjalizacja/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPECJALIZACJA sPECJALIZACJA = db.SPECJALIZACJAs.Find(id);
            if (sPECJALIZACJA == null)
            {
                return HttpNotFound();
            }
            return View(sPECJALIZACJA);
        }

        // POST: Specjalizacja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SPECJALIZACJA sPECJALIZACJA = db.SPECJALIZACJAs.Find(id);
            db.SPECJALIZACJAs.Remove(sPECJALIZACJA);
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
