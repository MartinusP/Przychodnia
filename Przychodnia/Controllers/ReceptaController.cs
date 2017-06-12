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
    public class ReceptaController : Controller
    {
        private PRZYCHODNIAEntities db = new PRZYCHODNIAEntities();

        // GET: Recepta
        public ActionResult Index()
        {
            return View(db.RECEPTAs.ToList());
        }

        // GET: Recepta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECEPTA rECEPTA = db.RECEPTAs.Find(id);
            if (rECEPTA == null)
            {
                return HttpNotFound();
            }
            return View(rECEPTA);
        }

        // GET: Recepta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recepta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_RECEPTA,DATA_WYKORZYSTANIA,NAZWA_LEKU,UWAGI")] RECEPTA rECEPTA)
        {
            if (ModelState.IsValid)
            {
                db.RECEPTAs.Add(rECEPTA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rECEPTA);
        }

        // GET: Recepta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECEPTA rECEPTA = db.RECEPTAs.Find(id);
            if (rECEPTA == null)
            {
                return HttpNotFound();
            }
            return View(rECEPTA);
        }

        // POST: Recepta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_RECEPTA,DATA_WYKORZYSTANIA,NAZWA_LEKU,UWAGI")] RECEPTA rECEPTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rECEPTA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rECEPTA);
        }

        // GET: Recepta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECEPTA rECEPTA = db.RECEPTAs.Find(id);
            if (rECEPTA == null)
            {
                return HttpNotFound();
            }
            return View(rECEPTA);
        }

        // POST: Recepta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RECEPTA rECEPTA = db.RECEPTAs.Find(id);
            db.RECEPTAs.Remove(rECEPTA);
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
