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
    public class ProfessionTypesController : Controller
    {
        private MovAppContext db = new MovAppContext();

        // GET: ProfessionTypes
        public ActionResult Index()
        {
            return View(db.ProfessionTypes.ToList());
        }

        // GET: ProfessionTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessionType professionType = db.ProfessionTypes.Find(id);
            if (professionType == null)
            {
                return HttpNotFound();
            }
            return View(professionType);
        }

        // GET: ProfessionTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfessionTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProfessionTypeId,TypeName")] ProfessionType professionType)
        {
            if (ModelState.IsValid)
            {
                db.ProfessionTypes.Add(professionType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(professionType);
        }

        // GET: ProfessionTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessionType professionType = db.ProfessionTypes.Find(id);
            if (professionType == null)
            {
                return HttpNotFound();
            }
            return View(professionType);
        }

        // POST: ProfessionTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProfessionTypeId,TypeName")] ProfessionType professionType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(professionType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(professionType);
        }

        // GET: ProfessionTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessionType professionType = db.ProfessionTypes.Find(id);
            if (professionType == null)
            {
                return HttpNotFound();
            }
            return View(professionType);
        }

        // POST: ProfessionTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProfessionType professionType = db.ProfessionTypes.Find(id);
            db.ProfessionTypes.Remove(professionType);
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
