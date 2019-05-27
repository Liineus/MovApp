using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovApp.Models;
using MovApp.ViewModels;

namespace MovApp.Controllers
{
    public class MoviesController : Controller
    {
        private MovAppContext db = new MovAppContext();

        // GET: Movies
        public ActionResult Index()
        {

            var Results = db.Movies.ToList();
            var MyViewModels = new List<MoviesViewModel>();

            var MovieDetails = from md in db.Movies
                               select new
                               {
                                   md.MovieId,
                                   md.Name,
                                   md.Name_org,
                                   md.Premiere,
                                   md.Description,
                                   MovieGenres = (from b in db.Genres
                                                  select new
                                                  {
                                                      b.GenreId,
                                                      b.GenreName,
                                                      Checked = ((from ab in db.MovieGenres
                                                                  where (ab.MovieId == md.MovieId) & (ab.GenreId == b.GenreId)
                                                                  select ab).Count() > 0)
                                                  })
                               };
        

            foreach (var item in MovieDetails)
            {
                var MyCheckBoxList = new List<MovieCheckBoxViewModel>();

                var Genres = from b in db.Genres
                             select new
                             {
                                 b.GenreId,
                                 b.GenreName,
                                 Checked = ((from ab in db.MovieGenres
                                             where (ab.MovieId == item.MovieId) & (ab.GenreId == b.GenreId)
                                             select ab).Count() > 0)
                             };

                foreach (var genre in Genres)
                {
                    MyCheckBoxList.Add(new MovieCheckBoxViewModel { CheckBoxId = genre.GenreId, Name = genre.GenreName, Checked = genre.Checked });
                }

                MyViewModels.Add(new MoviesViewModel { MovieId = item.MovieId, Name = item.Name, Name_org = item.Name_org, Premiere = item.Premiere, Description = item.Description, Genres = MyCheckBoxList });
            }

            return View(MyViewModels);
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            var Results = from b in db.Genres
                          select new
                          {
                              b.GenreId,
                              b.GenreName,
                              Checked = ((from ab in db.MovieGenres
                                          where (ab.MovieId == id) & (ab.GenreId == b.GenreId)
                                          select ab).Count() > 0)
                          };

            var MyViewModel = new MoviesViewModel
            {
                MovieId = id.Value,
                Name = movie.Name,
                Name_org = movie.Name_org,
                Premiere = movie.Premiere,
                Description = movie.Description
            };

            var MyCheckBoxList = new List<MovieCheckBoxViewModel>();

            foreach (var item in Results)
            {
                MyCheckBoxList.Add(new MovieCheckBoxViewModel { CheckBoxId = item.GenreId, Name = item.GenreName, Checked = item.Checked });
            }

            MyViewModel.Genres = MyCheckBoxList;

            return View(MyViewModel);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            var movie = new MoviesViewModel();
            var MyCheckBoxList = new List<MovieCheckBoxViewModel>();
            var Results = from b in db.Genres
                          select new
                          {
                              b.GenreId,
                              b.GenreName,
                              Checked = false
                          };

            foreach (var item in Results)
            {
                MyCheckBoxList.Add(new MovieCheckBoxViewModel { CheckBoxId = item.GenreId, Name = item.GenreName, Checked = item.Checked });
            }

            movie.Genres = MyCheckBoxList;

            return View(movie);
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MoviesViewModel movie)
        {
            if (ModelState.IsValid)
            {
                var myMovie = new Movie()
                {
                    Name = movie.Name,
                    Name_org = movie.Name_org,
                    Premiere = movie.Premiere,
                    Description = movie.Description
                };
                db.Movies.Add(myMovie);

                foreach (var item in movie.Genres)
                {
                    if (item.Checked)
                    {
                        db.MovieGenres.Add(new MovieGenre()
                        {
                            MovieId = myMovie.MovieId,
                            GenreId = item.CheckBoxId
                        });
                    }
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            var Results = from b in db.Genres
                          select new
                          {
                              b.GenreId,
                              b.GenreName,
                              Checked = ((from ab in db.MovieGenres
                                          where (ab.MovieId == id) & (ab.GenreId == b.GenreId)
                                          select ab).Count() > 0)
                          };

            var MyViewModel = new MoviesViewModel
            {
                MovieId = id.Value,
                Name = movie.Name,
                Name_org = movie.Name_org,
                Premiere = movie.Premiere,
                Description = movie.Description
            };

            var MyCheckBoxList = new List<MovieCheckBoxViewModel>();

            foreach (var item in Results)
            {
                MyCheckBoxList.Add(new MovieCheckBoxViewModel { CheckBoxId = item.GenreId, Name = item.GenreName, Checked = item.Checked });
            }

            MyViewModel.Genres = MyCheckBoxList;

            return View(MyViewModel);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MoviesViewModel movie)
        {
            if (ModelState.IsValid)
            {
                var MyMovie = db.Movies.Find(movie.MovieId);

                MyMovie.Name = movie.Name;
                MyMovie.Name_org = movie.Name_org;
                MyMovie.Premiere = movie.Premiere;
                MyMovie.Description = movie.Description;

                foreach (var item in db.MovieGenres)
                {
                    if (item.MovieId == movie.MovieId)
                    {
                        db.Entry(item).State = System.Data.Entity.EntityState.Deleted;

                    }
                }

                foreach (var item in movie.Genres)
                {
                    if (item.Checked)
                    {
                        db.MovieGenres.Add(new MovieGenre()
                        {
                            MovieId = movie.MovieId,
                            GenreId = item.CheckBoxId
                        });
                    }
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
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
