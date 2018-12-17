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
    [Authorize]
    public class VoorraadsController : Controller
    {
        private Entities db = new Entities();

        // GET: Voorraads
        public ActionResult Index()
        {
            var voorraad = db.Voorraad.Include(v => v.Artikel).Include(v => v.Locatie);
            return View(voorraad.ToList());
        }

        // GET: Voorraads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voorraad voorraad = db.Voorraad.Find(id);
            if (voorraad == null)
            {
                return HttpNotFound();
            }
            return View(voorraad);
        }

        // GET: Voorraads/Create
        public ActionResult Create()
        {
            ViewBag.Productcode = new SelectList(db.Artikel, "Productcode", "Product");
            ViewBag.Locatiecode = new SelectList(db.Locatie, "Locatiecode", "Locatie1");
            return View();
        }

        // POST: Voorraads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Locatiecode,Productcode,Aantal")] Voorraad voorraad)
        {
            if (ModelState.IsValid)
            {
                db.Voorraad.Add(voorraad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Productcode = new SelectList(db.Artikel, "Productcode", "Product", voorraad.Productcode);
            ViewBag.Locatiecode = new SelectList(db.Locatie, "Locatiecode", "Locatie1", voorraad.Locatiecode);
            return View(voorraad);
        }

        // GET: Voorraads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voorraad voorraad = db.Voorraad.Find(id);
            if (voorraad == null)
            {
                return HttpNotFound();
            }
            ViewBag.Productcode = new SelectList(db.Artikel, "Productcode", "Product", voorraad.Productcode);
            ViewBag.Locatiecode = new SelectList(db.Locatie, "Locatiecode", "Locatie1", voorraad.Locatiecode);
            return View(voorraad);
        }

        // POST: Voorraads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Productcode,Aantal")] AddtoVoorraadViewModel voorraad)
        {
            //Hoe pak ik het ID?
            var HuidigeItem = db.Voorraad.Find();
            HuidigeItem.Aantal = +voorraad.extravoorraad;
            if (ModelState.IsValid)
            {
                db.Entry(HuidigeItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            /*ViewBag.Productcode = new SelectList(db.Artikel, "Productcode", "Product", voorraad.Productcode);
            ViewBag.Locatiecode = new SelectList(db.Locatie, "Locatiecode", "Locatie1", voorraad.Locatiecode);*/
            return View(voorraad);
        }

        // GET: Voorraads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voorraad voorraad = db.Voorraad.Find(id);
            if (voorraad == null)
            {
                return HttpNotFound();
            }
            return View(voorraad);
        }

        // POST: Voorraads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Voorraad voorraad = db.Voorraad.Find(id);
            db.Voorraad.Remove(voorraad);
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
