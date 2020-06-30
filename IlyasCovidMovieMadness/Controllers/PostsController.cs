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
    public class PostsController : Controller
    {
        //private cmmDbContext db = new cmmDbContext();
        private readonly IPostData _db;
        public PostsController(IPostData db)
        {
            _db = db;
        }
        // GET: Posts
        public ActionResult Index()
        {
            var model = _db.GetAll(); 
            return View(model.ToList());
        }

        // GET: Posts/Details/5
        public ActionResult Details(int id)
        {

            var model = _db.Get(id);
            ViewBag.DateCreated = model.DateCreated.ToString("dddd , MMM dd yyyy,hh:mm");
            ViewBag.DateEdited = model.DateEdited.ToString("dddd , MMM dd yyyy,hh:mm");
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // GET: Posts/Create
        public ActionResult Create(int id)
        {
            var model = _db.GetMovie(id);
            if (model == null)
            {
                return Redirect("Index");
            }
            var movies = _db.GetAllMovies();
            ViewBag.PostId = new SelectList(movies, "MovieId", "Title", id);
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostId,Text,PostRating")] Post post, int id)
        {
            post.DateCreated = DateTime.Now;
            post.DateEdited = DateTime.Now;
            var movie = _db.GetMovie(id);
            post.MovieTitle = movie.Title;
            if (ModelState.IsValid)
            {
                _db.Add(post);
                return RedirectToAction("Details", new { id = post.PostId });
            }
            var movies = _db.GetAllMovies();
            ViewBag.PostId = new SelectList(movies, "MovieId", "Title", post.PostId);
            return View(post);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            var movies = _db.GetAllMovies();
            ViewBag.PostId = new SelectList(movies, "MovieId", "Title", model.PostId);
            ViewBag.DateCreated = model.DateCreated.ToString("dddd , MMM dd yyyy,hh:mm");
            ViewBag.DateEdited = model.DateEdited.ToString("dddd , MMM dd yyyy,hh:mm");
            ViewBag.MovieTitle = model.MovieTitle;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Post post)
        {
            post.DateEdited = DateTime.Now;
            if (ModelState.IsValid)
            {
                _db.Edit(post);
                TempData["MessageEdited"] = "You have saved your post!";
                return RedirectToAction("Index");
            }
            var movies = _db.GetAllMovies();
            ViewBag.PostId = new SelectList(movies, "MovieId", "Title", post.PostId);
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Posts/Delete/5
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
