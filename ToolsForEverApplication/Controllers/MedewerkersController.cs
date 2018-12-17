using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ToolsForEverApplication.Models;

namespace ToolsForEverApplication.Controllers
{
    [Authorize(Roles = "Applicatiebeheerder, Manager")]
    public class MedewerkersController : Controller
    {
        private Entities db = new Entities();

        // GET: Medewerkers
        public ActionResult Index()
        {
            return View(db.Medewerkers.ToList());
        }

        // GET: Medewerkers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medewerkers medewerkers = db.Medewerkers.Find(id);
            if (medewerkers == null)
            {
                return HttpNotFound();
            }
            return View(medewerkers);
        }

        // GET: Medewerkers/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Medewerkers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Medewerkerscode,Voorletters,Voorvoegsels,Achternaam,Gebruikersnaam,Email")] Medewerkers medewerkers)
        {
            if (ModelState.IsValid)
            {
                db.Medewerkers.Add(medewerkers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medewerkers);
        }

        // GET: Medewerkers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medewerkers medewerkers = db.Medewerkers.Find(id);
            if (medewerkers == null)
            {
                return HttpNotFound();
            }
            return View(medewerkers);
        }

        // POST: Medewerkers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Medewerkerscode,Voorletters,Voorvoegsels,Achternaam,Gebruikersnaam,Email")] Medewerkers medewerkers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medewerkers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medewerkers);
        }

        // GET: Medewerkers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medewerkers medewerkers = db.Medewerkers.Find(id);
            if (medewerkers == null)
            {
                return HttpNotFound();
            }
            return View(medewerkers);
        }

        // POST: Medewerkers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medewerkers medewerkers = db.Medewerkers.Find(id);
            db.Medewerkers.Remove(medewerkers);
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
