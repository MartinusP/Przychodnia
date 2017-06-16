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
    public class ReceptaController : Controller
    {
        private PRZYCHODNIAEntities db = new PRZYCHODNIAEntities();

        // GET: Recepta
        public async Task<ActionResult> Index()
        {
            return View(await db.RECEPTY.ToListAsync());
        }

        // GET: Recepta/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECEPTA rECEPTA = await db.RECEPTY.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "DATA_WYKORZYSTANIA,NAZWA_LEKU,UWAGI")] RECEPTA rECEPTA)
        {
            if (ModelState.IsValid)
            {
                db.RECEPTY.Add(rECEPTA);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(rECEPTA);
        }

        // GET: Recepta/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECEPTA rECEPTA = await db.RECEPTY.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "DATA_WYKORZYSTANIA,NAZWA_LEKU,UWAGI")] RECEPTA rECEPTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rECEPTA).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(rECEPTA);
        }

        // GET: Recepta/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECEPTA rECEPTA = await db.RECEPTY.FindAsync(id);
            if (rECEPTA == null)
            {
                return HttpNotFound();
            }
            return View(rECEPTA);
        }

        // POST: Recepta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RECEPTA rECEPTA = await db.RECEPTY.FindAsync(id);
            db.RECEPTY.Remove(rECEPTA);
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
