using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Przychodnia.Context;
using Przychodnia.Models;

namespace Przychodnia
{
    public class LekController : Controller
    {
        private PRZYCHODNIAEntities db = new PRZYCHODNIAEntities();

        // GET: Lek
        public async Task<ActionResult> Index()
        {
            return View(await db.LEKI.ToListAsync());
        }

        // GET: Lek/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LEK lEK = await db.LEKI.FindAsync(id);
            if (lEK == null)
            {
                return HttpNotFound();
            }
            return View(lEK);
        }

        // GET: Lek/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lek/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_LEKU,NAZWA_LEKU,UWAGI")] LEK lEK)
        {
            if (ModelState.IsValid)
            {
                db.LEKI.Add(lEK);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(lEK);
        }

        // GET: Lek/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LEK lEK = await db.LEKI.FindAsync(id);
            if (lEK == null)
            {
                return HttpNotFound();
            }
            return View(lEK);
        }

        // POST: Lek/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_LEKU,NAZWA_LEKU,UWAGI")] LEK lEK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lEK).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(lEK);
        }

        // GET: Lek/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LEK lEK = await db.LEKI.FindAsync(id);
            if (lEK == null)
            {
                return HttpNotFound();
            }
            return View(lEK);
        }

        // POST: Lek/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LEK lEK = await db.LEKI.FindAsync(id);
            db.LEKI.Remove(lEK);
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
