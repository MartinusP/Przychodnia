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
    public class OddzialController : Controller
    {
        private PRZYCHODNIAEntities db = new PRZYCHODNIAEntities();

        // GET: Oddzial
        public ActionResult Index()
        {
            return View(db.ODDZIALs.ToList());
        }

        // GET: Oddzial/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ODDZIAL oDDZIAL = db.ODDZIALs.Find(id);
            if (oDDZIAL == null)
            {
                return HttpNotFound();
            }
            return View(oDDZIAL);
        }

        // GET: Oddzial/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Oddzial/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ODDZIAL,NAZWA,MIEJSCOWOSC")] ODDZIAL oDDZIAL)
        {
            if (ModelState.IsValid)
            {
                db.ODDZIALs.Add(oDDZIAL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oDDZIAL);
        }

        // GET: Oddzial/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ODDZIAL oDDZIAL = db.ODDZIALs.Find(id);
            if (oDDZIAL == null)
            {
                return HttpNotFound();
            }
            return View(oDDZIAL);
        }

        // POST: Oddzial/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ODDZIAL,NAZWA,MIEJSCOWOSC")] ODDZIAL oDDZIAL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oDDZIAL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oDDZIAL);
        }

        // GET: Oddzial/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ODDZIAL oDDZIAL = db.ODDZIALs.Find(id);
            if (oDDZIAL == null)
            {
                return HttpNotFound();
            }
            return View(oDDZIAL);
        }

        // POST: Oddzial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ODDZIAL oDDZIAL = db.ODDZIALs.Find(id);
            db.ODDZIALs.Remove(oDDZIAL);
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
