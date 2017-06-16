using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Przychodnia.Models;
using Przychodnia.Context;

namespace Przychodnia
{
    public class OddzialController : Controller
    {
        private Context.PRZYCHODNIAEntities db = new Context.PRZYCHODNIAEntities();

        // GET: Oddzial
        public async Task<ActionResult> Index()
        {
            var oDDZIALs = db.ODDZIALY.Include(o => o.PLACOWKA);
            return View(await oDDZIALs.ToListAsync());
        }

        // GET: Oddzial/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ODDZIAL oDDZIAL = await db.ODDZIALY.FindAsync(id);
            if (oDDZIAL == null)
            {
                return HttpNotFound();
            }
            return View(oDDZIAL);
        }

        // GET: Oddzial/Create
        public ActionResult Create()
        {
            ViewBag.ID_PLACOWKA = new SelectList(db.PLACOWKI, "ID_PLACOWKA", "NAZWA");
            return View();
        }

        // POST: Oddzial/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "NAZWA,MIEJSCOWOSC,ID_PLACOWKA")] ODDZIAL oDDZIAL)
        {
            if (ModelState.IsValid)
            {
                db.ODDZIALY.Add(oDDZIAL);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PLACOWKA = new SelectList(db.PLACOWKI, "ID_PLACOWKA", "NAZWA", oDDZIAL.ID_PLACOWKA);
            return View(oDDZIAL);
        }

        // GET: Oddzial/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ODDZIAL oDDZIAL = await db.ODDZIALY.FindAsync(id);
            if (oDDZIAL == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PLACOWKA = new SelectList(db.PLACOWKI, "ID_PLACOWKA", "NAZWA", oDDZIAL.ID_PLACOWKA);
            return View(oDDZIAL);
        }

        // POST: Oddzial/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_ODDZIAL,NAZWA,MIEJSCOWOSC,ID_PLACOWKA")] ODDZIAL oDDZIAL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oDDZIAL).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PLACOWKA = new SelectList(db.PLACOWKI, "ID_PLACOWKA", "NAZWA", oDDZIAL.ID_PLACOWKA);
            return View(oDDZIAL);
        }

        // GET: Oddzial/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ODDZIAL oDDZIAL = await db.ODDZIALY.FindAsync(id);
            if (oDDZIAL == null)
            {
                return HttpNotFound();
            }
            return View(oDDZIAL);
        }

        // POST: Oddzial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ODDZIAL oDDZIAL = await db.ODDZIALY.FindAsync(id);
            db.ODDZIALY.Remove(oDDZIAL);
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
