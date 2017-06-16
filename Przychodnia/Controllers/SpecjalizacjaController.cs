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
    public class SpecjalizacjaController : Controller
    {
        private PRZYCHODNIAEntities db = new PRZYCHODNIAEntities();

        // GET: Specjalizacja
        public async Task<ActionResult> Index()
        {
            return View(await db.SPECJALIZACJE.ToListAsync());
        }

        // GET: Specjalizacja/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPECJALIZACJA sPECJALIZACJA = await db.SPECJALIZACJE.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "NAZWA")] SPECJALIZACJA sPECJALIZACJA)
        {
            if (ModelState.IsValid)
            {
                db.SPECJALIZACJE.Add(sPECJALIZACJA);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sPECJALIZACJA);
        }

        // GET: Specjalizacja/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPECJALIZACJA sPECJALIZACJA = await db.SPECJALIZACJE.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "NAZWA")] SPECJALIZACJA sPECJALIZACJA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sPECJALIZACJA).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sPECJALIZACJA);
        }

        // GET: Specjalizacja/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPECJALIZACJA sPECJALIZACJA = await db.SPECJALIZACJE.FindAsync(id);
            if (sPECJALIZACJA == null)
            {
                return HttpNotFound();
            }
            return View(sPECJALIZACJA);
        }

        // POST: Specjalizacja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SPECJALIZACJA sPECJALIZACJA = await db.SPECJALIZACJE.FindAsync(id);
            db.SPECJALIZACJE.Remove(sPECJALIZACJA);
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
