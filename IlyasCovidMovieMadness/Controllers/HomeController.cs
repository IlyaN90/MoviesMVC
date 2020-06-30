using IlyasCovidMovieMadness.Context;
using IlyasCovidMovieMadness.Models;
using IlyasCovidMovieMadness.Services;
using IlyasCovidMovieMadness.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace IlyasCovidMovieMadness.Controllers
{
    public class HomeController : Controller
    {
        private readonly cmmDbContext _db;

        public HomeController(cmmDbContext db)
        {
            _db = db;
        }

        public PartialViewResult Particular()
        {
            var viewModel = new PostPartialViewModel();
            viewModel.Post = _db.Post.Include(c => c.Comments).FirstOrDefault();
            if (viewModel.Post.Comments != null) 
            {
                viewModel.AvarageRaiting = viewModel.Post.Comments.Select(c => c.UserRatig).Average();
            }
            return PartialView("_PartialPost", viewModel);
        }

        public ActionResult Index(int? id, int? PostId)
        {
            var viewModel = new PostCommentViewModel();
            viewModel.Posts = _db.Post
                .Include(p => p.Comments)
               //.Include(p=> p.Movie)
                .OrderByDescending(p=>p.DateEdited);

            if (id != null)
            {
                ViewBag.PostID = id.Value;
                viewModel.Comments = viewModel.Posts.Where(
                    c => c.PostId == id.Value).Single().Comments;
            }
            if (PostId != null)
            {
                ViewBag.PostID = PostId.Value;
                var selectedPost = viewModel.Posts.Where(x => x.PostId == PostId).Single();
                _db.Entry(selectedPost).Collection(x => x.Comments).Load();
                ViewBag.Post = viewModel.Post.Movie.Title;
                foreach (Comment comment in selectedPost.Comments)
                {
                    _db.Entry(comment).Reference(x => x.Post).Load();
                }

                viewModel.Comments = selectedPost.Comments;
            }
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}