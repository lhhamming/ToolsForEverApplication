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
    public class ArtikelsController : Controller
    {
        private Entities db = new Entities();

        // GET: Artikels
        public ActionResult Index()
        {
            var artikel = db.Artikel.Include(a => a.Fabriek).Include(a => a.Voorraad);
            return View(artikel.ToList());
        }

        // GET: Artikels/Details/5
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

        // GET: Artikels/Create
        public ActionResult Create()
        {
            ViewBag.Fabriekscode = new SelectList(db.Fabriek, "Fabriekscode", "Fabriek1");
            ViewBag.Productcode = new SelectList(db.Voorraad, "Productcode", "Productcode");
            return View();
        }

        // POST: Artikels/Create
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
            ViewBag.Productcode = new SelectList(db.Voorraad, "Productcode", "Productcode", artikel.Productcode);
            return View(artikel);
        }

        // GET: Artikels/Edit/5
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
            ViewBag.Productcode = new SelectList(db.Voorraad, "Productcode", "Productcode", artikel.Productcode);
            return View(artikel);
        }

        // POST: Artikels/Edit/5
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
            ViewBag.Productcode = new SelectList(db.Voorraad, "Productcode", "Productcode", artikel.Productcode);
            return View(artikel);
        }

        // GET: Artikels/Delete/5
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

        // POST: Artikels/Delete/5
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
