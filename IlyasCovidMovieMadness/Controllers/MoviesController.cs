using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IlyasCovidMovieMadness.Context;
using IlyasCovidMovieMadness.Models;
using IlyasCovidMovieMadness.Services;

namespace IlyasCovidMovieMadness.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieData _db;

        public MoviesController(IMovieData db)
        {
            _db = db;
        }
        // GET: Movies
        public ActionResult Index()
        {
            var model = _db.GetAll();
            return View(model);
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            var model = _db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            var post=_db.GetPost();
            ViewBag.MovieId = new SelectList(post, "PostId", "Text");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieId,Title,ReleaseDate,Description")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _db.Add(movie);
                return RedirectToAction("Details", new { id = movie.MovieId });
            }
            var post = _db.GetPost();
            ViewBag.MovieId = new SelectList(post, "PostId", "Text", movie.MovieId);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            var post = _db.GetPost();
            ViewBag.MovieId = new SelectList(post, "PostId", "Text", model.MovieId);
            return View(model);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieId,Title,ReleaseDate,Description")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _db.Edit(movie);
                return RedirectToAction("Index");
            }
            var post = _db.GetPost();
            ViewBag.MovieId = new SelectList(post, "PostId", "Text", movie.MovieId);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _db.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
