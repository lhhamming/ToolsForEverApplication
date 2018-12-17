using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ToolsForEverApplication.Models;

namespace ToolsForEverApplication.Controllers
{
    [Authorize(Roles = "Applicatiebeheerder, Manager, Binnen Medewerker, Buiten Medewerker")]
    public class ArtikelController : Controller
    {
        private Entities db = new Entities();

        // GET: Artikel
        public ActionResult Index()
        {
            var artikel = db.Artikel.Include(a => a.Fabriek);
            return View(artikel.ToList());
        }

        // GET: Artikel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artikel artikel = db.Artikel.Find(id);
            if (artikel == null)
            {
                return HttpNotFound();
            }
            return View(artikel);
        }

        // GET: Artikel/Create
        public ActionResult Create()
        {
            ViewBag.Fabriekscode = new SelectList(db.Fabriek, "Fabriekscode", "Fabriek1");
            return View();
        }

        // POST: Artikel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Productcode,Product,PType,Fabriekscode,Inkoopprijs,Verkoopprijs")] Artikel artikel)
        {
            if (ModelState.IsValid)
            {
                db.Artikel.Add(artikel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Fabriekscode = new SelectList(db.Fabriek, "Fabriekscode", "Fabriek1", artikel.Fabriekscode);
            return View(artikel);
        }

        public ActionResult waardevoorraad()
        {
            List<Artikel> artikelen = db.Artikel.ToList();
            double waardeinkoop;
            double waardeverkoop;
            foreach(var artikel in db.Artikel.ToList())
            {
                waardeinkoop =+  artikel.Inkoopprijs;
                waardeverkoop =+ artikel.Verkoopprijs;

                ViewBag.Inkoop = waardeinkoop;
                ViewBag.Verkoop = waardeverkoop;
            }

            

            return View();
        }

        // GET: Artikel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artikel artikel = db.Artikel.Find(id);
            if (artikel == null)
            {
                return HttpNotFound();
            }
            ViewBag.Fabriekscode = new SelectList(db.Fabriek, "Fabriekscode", "Fabriek1", artikel.Fabriekscode);
            return View(artikel);
        }

        // POST: Artikel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Productcode,Product,PType,Fabriekscode,Inkoopprijs,Verkoopprijs")] Artikel artikel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artikel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Fabriekscode = new SelectList(db.Fabriek, "Fabriekscode", "Fabriek1", artikel.Fabriekscode);
            return View(artikel);
        }

        // GET: Artikel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artikel artikel = db.Artikel.Find(id);
            if (artikel == null)
            {
                return HttpNotFound();
            }
            return View(artikel);
        }

        // POST: Artikel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artikel artikel = db.Artikel.Find(id);
            db.Artikel.Remove(artikel);
            db.SaveChanges();
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
