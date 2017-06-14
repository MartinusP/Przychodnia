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
            SPECJALIZACJA specjalizacja = await db.SPECJALIZACJE.FindAsync(id);
            if (specjalizacja == null)
            {
                return HttpNotFound();
            }
            return View(specjalizacja);
        }

        // GET: Specjalizacja/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Specjalizacja/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_SPECJALIZACJA,NAZWA")] SPECJALIZACJA specjalizacja)
        {
            if (ModelState.IsValid)
            {
                db.SPECJALIZACJE.Add(specjalizacja);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(specjalizacja);
        }

        // GET: Specjalizacja/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPECJALIZACJA specjalizacja = await db.SPECJALIZACJE.FindAsync(id);
            if (specjalizacja == null)
            {
                return HttpNotFound();
            }
            return View(specjalizacja);
        }

        // POST: Specjalizacja/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_SPECJALIZACJA,NAZWA")] SPECJALIZACJA specjalizacja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(specjalizacja).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(specjalizacja);
        }

        // GET: Specjalizacja/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPECJALIZACJA specjalizacja = await db.SPECJALIZACJE.FindAsync(id);
            if (specjalizacja == null)
            {
                return HttpNotFound();
            }
            return View(specjalizacja);
        }

        // POST: Specjalizacja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SPECJALIZACJA specjalizacja = await db.SPECJALIZACJE.FindAsync(id);
            db.SPECJALIZACJE.Remove(specjalizacja);
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
