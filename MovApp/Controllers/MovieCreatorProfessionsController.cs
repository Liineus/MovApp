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
    public class MovieCreatorProfessionsController : Controller
    {
        private MovAppContext db = new MovAppContext();

        // GET: MovieCreatorProfessions
        public ActionResult Index()
        {
            var movieCreatorProfessions = db.MovieCreatorProfessions.Include(m => m.Creator).Include(m => m.Movie).Include(m => m.Profession);
            return View(movieCreatorProfessions.ToList());
        }

        // GET: MovieCreatorProfessions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieCreatorProfession movieCreatorProfession = db.MovieCreatorProfessions.Find(id);
            if (movieCreatorProfession == null)
            {
                return HttpNotFound();
            }
            return View(movieCreatorProfession);
        }

        // GET: MovieCreatorProfessions/Create
        public ActionResult Create()
        {
            ViewBag.CreatorId = new SelectList(db.Creators, "CreatorId", "Name");
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Name");
            ViewBag.ProfessionId = new SelectList(db.Professions, "ProfessionId", "Name");
            return View();
        }

        // POST: MovieCreatorProfessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieCreatorProfessionId,MovieId,CreatorId,ProfessionId")] MovieCreatorProfession movieCreatorProfession)
        {
            if (ModelState.IsValid)
            {
                db.MovieCreatorProfessions.Add(movieCreatorProfession);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CreatorId = new SelectList(db.Creators, "CreatorId", "Name", movieCreatorProfession.CreatorId);
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Name", movieCreatorProfession.MovieId);
            ViewBag.ProfessionId = new SelectList(db.Professions, "ProfessionId", "Name", movieCreatorProfession.ProfessionId);
            return View(movieCreatorProfession);
        }

        // GET: MovieCreatorProfessions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieCreatorProfession movieCreatorProfession = db.MovieCreatorProfessions.Find(id);
            if (movieCreatorProfession == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreatorId = new SelectList(db.Creators, "CreatorId", "Name", movieCreatorProfession.CreatorId);
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Name", movieCreatorProfession.MovieId);
            ViewBag.ProfessionId = new SelectList(db.Professions, "ProfessionId", "Name", movieCreatorProfession.ProfessionId);
            return View(movieCreatorProfession);
        }

        // POST: MovieCreatorProfessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieCreatorProfessionId,MovieId,CreatorId,ProfessionId")] MovieCreatorProfession movieCreatorProfession)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movieCreatorProfession).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreatorId = new SelectList(db.Creators, "CreatorId", "Name", movieCreatorProfession.CreatorId);
            ViewBag.MovieId = new SelectList(db.Movies, "MovieId", "Name", movieCreatorProfession.MovieId);
            ViewBag.ProfessionId = new SelectList(db.Professions, "ProfessionId", "Name", movieCreatorProfession.ProfessionId);
            return View(movieCreatorProfession);
        }

        // GET: MovieCreatorProfessions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieCreatorProfession movieCreatorProfession = db.MovieCreatorProfessions.Find(id);
            if (movieCreatorProfession == null)
            {
                return HttpNotFound();
            }
            return View(movieCreatorProfession);
        }

        // POST: MovieCreatorProfessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MovieCreatorProfession movieCreatorProfession = db.MovieCreatorProfessions.Find(id);
            db.MovieCreatorProfessions.Remove(movieCreatorProfession);
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
