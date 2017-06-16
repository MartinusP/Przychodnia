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
    public class PlacowkaController : Controller
    {
        private PRZYCHODNIAEntities db = new PRZYCHODNIAEntities();

        // GET: Placowka
        public async Task<ActionResult> Index()
        {
            return View(await db.PLACOWKI.ToListAsync());
        }

        // GET: Placowka/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PLACOWKA pLACOWKA = await db.PLACOWKI.FindAsync(id);
            if (pLACOWKA == null)
            {
                return HttpNotFound();
            }
            return View(pLACOWKA);
        }

        // GET: Placowka/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Placowka/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "NAZWA,MIEJSCOWOSC,ADRES")] PLACOWKA pLACOWKA)
        {
            if (ModelState.IsValid)
            {
                db.PLACOWKI.Add(pLACOWKA);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(pLACOWKA);
        }

        // GET: Placowka/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PLACOWKA pLACOWKA = await db.PLACOWKI.FindAsync(id);
            if (pLACOWKA == null)
            {
                return HttpNotFound();
            }
            return View(pLACOWKA);
        }

        // POST: Placowka/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "NAZWA,MIEJSCOWOSC,ADRES")] PLACOWKA pLACOWKA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pLACOWKA).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pLACOWKA);
        }

        // GET: Placowka/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PLACOWKA pLACOWKA = await db.PLACOWKI.FindAsync(id);
            if (pLACOWKA == null)
            {
                return HttpNotFound();
            }
            return View(pLACOWKA);
        }

        // POST: Placowka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PLACOWKA pLACOWKA = await db.PLACOWKI.FindAsync(id);
            db.PLACOWKI.Remove(pLACOWKA);
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
