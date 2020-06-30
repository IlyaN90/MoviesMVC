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
    public class CommentsController : Controller
    {
        private readonly ICommentData _db;

        public CommentsController(ICommentData db)
        {
            _db = db;
        }
        // GET: Comments
        public ActionResult Index(int id)
        {
            var comment = _db.GetAll(id);
            //var comment = _db.Comment.Include(c => c.Post);
            return View(comment.ToList());
        }

        // GET: Comments/Details/5
        public ActionResult Details(int id)
        {
            var model = _db.Get(id);
            if (model == null)
            {
                return HttpNotFound();

            }
            return View(model);
        }

        // GET: Comments/Create
        public ActionResult Create(int id)
        {
            var model = _db.GetPost(id);
            if (model == null)
            {
                return Redirect("Index");
            }
            var posts = _db.GetAllPosts();
            ViewBag.PostID = new SelectList(posts, "PostId", "Text", model.PostId);
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentId,UserName,Text,UserRatig,DateCreated,DateEdited,PostID")] Comment comment)
        {
            comment.DateCreated = DateTime.Now;
            comment.DateEdited = DateTime.Now;

            var posts = _db.GetAllPosts();
            ViewBag.PostID = new SelectList(posts, "PostId", "Text", comment.PostID);

            if (ModelState.IsValid)
            {
                _db.Add(comment);
                return RedirectToAction("Details", new { id = comment.CommentId });
            }
            return View(comment);
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _db.Get(id);
            var post = _db.GetPost(model.PostID);

            if (model == null)
            {
                return HttpNotFound();
            }
            var posts = _db.GetAllPosts();
            ViewBag.PostID = new SelectList(posts, "PostId", "Text", post.PostId);
            ViewBag.DateCreated = model.DateCreated.ToString("dddd , MMM dd yyyy,hh:mm");
            ViewBag.DateEdited = model.DateEdited.ToString("dddd , MMM dd yyyy,hh:mm");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Comment comment)
        {
            comment.DateEdited = DateTime.Now;
            var post = _db.GetPost(comment.PostID);

            if (ModelState.IsValid)
            {
                _db.Edit(comment);
                TempData["MessageEdited"] = "You have saved your post!";
                return RedirectToAction("Details", new { id = comment.CommentId });
            }
            var posts = _db.GetAllPosts();
            ViewBag.PostID = new SelectList(posts, "PostId", "Text", post.PostId);
            return View(comment);
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Comments/Delete/5
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
