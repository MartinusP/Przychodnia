using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult> Index()
        {
            return View(await db.ODDZIALY.ToListAsync());
        }

        // GET: Oddzial/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ODDZIAL oddzial = await db.ODDZIALY.FindAsync(id);
            if (oddzial == null)
            {
                return HttpNotFound();
            }
            return View(oddzial);
        }

        // GET: Oddzial/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Oddzial/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_ODDZIAL,NAZWA,MIEJSCOWOSC")] ODDZIAL oddzial)
        {
            if (ModelState.IsValid)
            {
                db.ODDZIALY.Add(oddzial);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(oddzial);
        }

        // GET: Oddzial/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ODDZIAL oddzial = await db.ODDZIALY.FindAsync(id);
            if (oddzial == null)
            {
                return HttpNotFound();
            }
            return View(oddzial);
        }

        // POST: Oddzial/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_ODDZIAL,NAZWA,MIEJSCOWOSC")] ODDZIAL oddzial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oddzial).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(oddzial);
        }

        // GET: Oddzial/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ODDZIAL oddzial = await db.ODDZIALY.FindAsync(id);
            if (oddzial == null)
            {
                return HttpNotFound();
            }
            return View(oddzial);
        }

        // POST: Oddzial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ODDZIAL oddzial = await db.ODDZIALY.FindAsync(id);
            db.ODDZIALY.Remove(oddzial);
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
