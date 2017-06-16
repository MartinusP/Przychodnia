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
    public class PacjentController : Controller
    {
        private PRZYCHODNIAEntities db = new PRZYCHODNIAEntities();

        // GET: Pacjent
        public async Task<ActionResult> Index()
        {
            return View(await db.PACJENCI.ToListAsync());
        }

        // GET: Pacjent/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PACJENT pACJENT = await db.PACJENCI.FindAsync(id);
            if (pACJENT == null)
            {
                return HttpNotFound();
            }
            return View(pACJENT);
        }

        // GET: Pacjent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pacjent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IMIE,NAZWISKO,ADRES,PESEL,TELEFON_KONTAKTOWY,EMAIL_KONTAKTOWY")] PACJENT pACJENT)
        {
            if (ModelState.IsValid)
            {
                db.PACJENCI.Add(pACJENT);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(pACJENT);
        }

        // GET: Pacjent/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PACJENT pACJENT = await db.PACJENCI.FindAsync(id);
            if (pACJENT == null)
            {
                return HttpNotFound();
            }
            return View(pACJENT);
        }

        // POST: Pacjent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IMIE,NAZWISKO,ADRES,PESEL,TELEFON_KONTAKTOWY,EMAIL_KONTAKTOWY")] PACJENT pACJENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pACJENT).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pACJENT);
        }

        // GET: Pacjent/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PACJENT pACJENT = await db.PACJENCI.FindAsync(id);
            if (pACJENT == null)
            {
                return HttpNotFound();
            }
            return View(pACJENT);
        }

        // POST: Pacjent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PACJENT pACJENT = await db.PACJENCI.FindAsync(id);
            db.PACJENCI.Remove(pACJENT);
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
