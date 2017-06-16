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
    public class SalaController : Controller
    {
        private PRZYCHODNIAEntities db = new PRZYCHODNIAEntities();

        // GET: Sala
        public async Task<ActionResult> Index()
        {
            return View(await db.SALE.ToListAsync());
        }

        // GET: Sala/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALA sALA = await db.SALE.FindAsync(id);
            if (sALA == null)
            {
                return HttpNotFound();
            }
            return View(sALA);
        }

        // GET: Sala/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sala/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_SALA,NUMER_SALI")] SALA sALA)
        {
            if (ModelState.IsValid)
            {
                db.SALE.Add(sALA);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sALA);
        }

        // GET: Sala/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALA sALA = await db.SALE.FindAsync(id);
            if (sALA == null)
            {
                return HttpNotFound();
            }
            return View(sALA);
        }

        // POST: Sala/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_SALA,NUMER_SALI")] SALA sALA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sALA).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sALA);
        }

        // GET: Sala/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALA sALA = await db.SALE.FindAsync(id);
            if (sALA == null)
            {
                return HttpNotFound();
            }
            return View(sALA);
        }

        // POST: Sala/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SALA sALA = await db.SALE.FindAsync(id);
            db.SALE.Remove(sALA);
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
