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
    public class FabrieksController : Controller
    {
        private Entities db = new Entities();

        // GET: Fabrieks
        public ActionResult Index()
        {
            return View(db.Fabriek.ToList());
        }

        // GET: Fabrieks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabriek fabriek = db.Fabriek.Find(id);
            if (fabriek == null)
            {
                return HttpNotFound();
            }
            return View(fabriek);
        }

        // GET: Fabrieks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fabrieks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Fabriekscode,Fabriek1,Telefoon")] Fabriek fabriek)
        {
            if (ModelState.IsValid)
            {
                db.Fabriek.Add(fabriek);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fabriek);
        }

        // GET: Fabrieks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabriek fabriek = db.Fabriek.Find(id);
            if (fabriek == null)
            {
                return HttpNotFound();
            }
            return View(fabriek);
        }

        // POST: Fabrieks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Fabriekscode,Fabriek1,Telefoon")] Fabriek fabriek)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fabriek).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fabriek);
        }

        // GET: Fabrieks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabriek fabriek = db.Fabriek.Find(id);
            if (fabriek == null)
            {
                return HttpNotFound();
            }
            return View(fabriek);
        }

        // POST: Fabrieks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fabriek fabriek = db.Fabriek.Find(id);
            db.Fabriek.Remove(fabriek);
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
