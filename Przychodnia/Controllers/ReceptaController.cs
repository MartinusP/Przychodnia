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
            return View(db.RECEPTY.ToList());
        }

        // GET: Recepta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECEPTA recepta = db.RECEPTY.Find(id);
            if (recepta == null)
            {
                return HttpNotFound();
            }
            return View(recepta);
        }

        // GET: Recepta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recepta/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_RECEPTA,DATA_WYKORZYSTANIA,NAZWA_LEKU,UWAGI")] RECEPTA recepta)
        {
            if (ModelState.IsValid)
            {
                db.RECEPTY.Add(recepta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recepta);
        }

        // GET: Recepta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECEPTA recepta = db.RECEPTY.Find(id);
            if (recepta == null)
            {
                return HttpNotFound();
            }
            return View(recepta);
        }

        // POST: Recepta/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_RECEPTA,DATA_WYKORZYSTANIA,NAZWA_LEKU,UWAGI")] RECEPTA recepta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recepta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recepta);
        }

        // GET: Recepta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECEPTA recepta = db.RECEPTY.Find(id);
            if (recepta == null)
            {
                return HttpNotFound();
            }
            return View(recepta);
        }

        // POST: Recepta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RECEPTA recepta = db.RECEPTY.Find(id);
            db.RECEPTY.Remove(recepta);
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
