using IlyasCovidMovieMadness.Context;
using IlyasCovidMovieMadness.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IlyasCovidMovieMadness.Services
{
    public class SqlPostData : IPostData
    {
        private readonly cmmDbContext _db;

        public SqlPostData(cmmDbContext db)
        {
            _db = db;
        }

        public void Add(Post post)
        {
            _db.Post.Add(post);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var post = Get(id);
            if (post != null)
            {
                _db.Post.Remove(post);
                _db.SaveChanges();
            }
        }

        public void Edit(Post post)
        {
            _db.Entry(post).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public Post Get(int id)
        {
            return _db.Post.Include(p => p.Movie).FirstOrDefault(m => m.PostId.Equals(id));
        }

        public Movie GetMovie(int id)
        {
            return _db.Movie.FirstOrDefault(m => m.MovieId.Equals(id));
        }

        public IEnumerable<Post> GetAll()
        {
            var posts = _db.Post.OrderByDescending(m => m.DateCreated).Include(p => p.Movie).Include(p=>p.Comments);
            return posts;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _db.Movie.Where(p=>p.Post==null).ToList();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}