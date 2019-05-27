using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovApp.Models;

namespace MovApp.Controllers
{
    public class Professions1Controller : Controller
    {
        private MovAppContext db = new MovAppContext();

        // GET: Professions1
        public ActionResult Index()
        {
            var professions = db.Professions.Include(p => p.ProfessionType);
            return View(professions.ToList());
        }

        // GET: Professions1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profession profession = db.Professions.Find(id);
            if (profession == null)
            {
                return HttpNotFound();
            }
            return View(profession);
        }

        // GET: Professions1/Create
        public ActionResult Create()
        {
            ViewBag.ProfessionTypeId = new SelectList(db.ProfessionTypes, "ProfessionTypeId", "TypeName");
            return View();
        }

        // POST: Professions1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProfessionId,Name,ProfessionTypeId")] Profession profession)
        {
            if (ModelState.IsValid)
            {
                db.Professions.Add(profession);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProfessionTypeId = new SelectList(db.ProfessionTypes, "ProfessionTypeId", "TypeName", profession.ProfessionTypeId);
            return View(profession);
        }

        // GET: Professions1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profession profession = db.Professions.Find(id);
            if (profession == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProfessionTypeId = new SelectList(db.ProfessionTypes, "ProfessionTypeId", "TypeName", profession.ProfessionTypeId);
            return View(profession);
        }

        // POST: Professions1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProfessionId,Name,ProfessionTypeId")] Profession profession)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profession).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProfessionTypeId = new SelectList(db.ProfessionTypes, "ProfessionTypeId", "TypeName", profession.ProfessionTypeId);
            return View(profession);
        }

        // GET: Professions1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profession profession = db.Professions.Find(id);
            if (profession == null)
            {
                return HttpNotFound();
            }
            return View(profession);
        }

        // POST: Professions1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profession profession = db.Professions.Find(id);
            db.Professions.Remove(profession);
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
