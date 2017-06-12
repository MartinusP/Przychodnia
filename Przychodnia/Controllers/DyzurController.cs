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
            var dYZURs = db.DYZURs.Include(d => d.ODDZIAL).Include(d => d.PRACOWNIK);
            return View(dYZURs.ToList());
        }

        // GET: Dyzur/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DYZUR dYZUR = db.DYZURs.Find(id);
            if (dYZUR == null)
            {
                return HttpNotFound();
            }
            return View(dYZUR);
        }

        // GET: Dyzur/Create
        public ActionResult Create()
        {
            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALs, "ID_ODDZIAL", "NAZWA");
            ViewBag.ID_PRACOWNIK = new SelectList(db.PRACOWNIKs, "ID_PRACOWNIK", "IMIE");
            return View();
        }

        // POST: Dyzur/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PRACOWNIK,DZIEN_DYZURU,OD,DO,ID_ODDZIAL")] DYZUR dYZUR)
        {
            if (ModelState.IsValid)
            {
                db.DYZURs.Add(dYZUR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALs, "ID_ODDZIAL", "NAZWA", dYZUR.ID_ODDZIAL);
            ViewBag.ID_PRACOWNIK = new SelectList(db.PRACOWNIKs, "ID_PRACOWNIK", "IMIE", dYZUR.ID_PRACOWNIK);
            return View(dYZUR);
        }

        // GET: Dyzur/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DYZUR dYZUR = db.DYZURs.Find(id);
            if (dYZUR == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALs, "ID_ODDZIAL", "NAZWA", dYZUR.ID_ODDZIAL);
            ViewBag.ID_PRACOWNIK = new SelectList(db.PRACOWNIKs, "ID_PRACOWNIK", "IMIE", dYZUR.ID_PRACOWNIK);
            return View(dYZUR);
        }

        // POST: Dyzur/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PRACOWNIK,DZIEN_DYZURU,OD,DO,ID_ODDZIAL")] DYZUR dYZUR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dYZUR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ODDZIAL = new SelectList(db.ODDZIALs, "ID_ODDZIAL", "NAZWA", dYZUR.ID_ODDZIAL);
            ViewBag.ID_PRACOWNIK = new SelectList(db.PRACOWNIKs, "ID_PRACOWNIK", "IMIE", dYZUR.ID_PRACOWNIK);
            return View(dYZUR);
        }

        // GET: Dyzur/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DYZUR dYZUR = db.DYZURs.Find(id);
            if (dYZUR == null)
            {
                return HttpNotFound();
            }
            return View(dYZUR);
        }

        // POST: Dyzur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DYZUR dYZUR = db.DYZURs.Find(id);
            db.DYZURs.Remove(dYZUR);
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
