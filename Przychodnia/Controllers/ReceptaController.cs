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
            RECEPTA recepta = await db.RECEPTY.FindAsync(id);
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DATA_WYKORZYSTANIA,NAZWA_LEKU,UWAGI")] RECEPTA recepta)
        {
            if (ModelState.IsValid)
            {
                db.RECEPTY.Add(recepta);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(recepta);
        }

        // GET: Recepta/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECEPTA recepta = await db.RECEPTY.FindAsync(id);
            if (recepta == null)
            {
                return HttpNotFound();
            }
            return View(recepta);
        }

        // POST: Recepta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DATA_WYKORZYSTANIA,NAZWA_LEKU,UWAGI")] RECEPTA recepta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recepta).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(recepta);
        }

        // GET: Recepta/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECEPTA recepta = await db.RECEPTY.FindAsync(id);
            if (recepta == null)
            {
                return HttpNotFound();
            }
            return View(recepta);
        }

        // POST: Recepta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RECEPTA recepta = await db.RECEPTY.FindAsync(id);
            db.RECEPTY.Remove(recepta);
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
