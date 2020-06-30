using IlyasCovidMovieMadness.Context;
using IlyasCovidMovieMadness.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IlyasCovidMovieMadness.Services
{
    public class SqlCommentData : ICommentData
    {
        private readonly cmmDbContext _db;

        public SqlCommentData(cmmDbContext db)
        {
            _db = db;
        }

        public void Add(Comment comment)
        {
            _db.Comment.Add(comment);
            _db.SaveChanges();
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _db.Post.ToList();
        }

        public void Delete(int id)
        {
            var comment = Get(id);
            if (comment != null)
            {
                _db.Comment.Remove(comment);
                _db.SaveChanges();
            }
        }

        public void Edit(Comment comment)
        {
            _db.Entry(comment).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public Comment Get(int id)
        {
            return _db.Comment.Include(c=>c.Post).FirstOrDefault(m => m.CommentId.Equals(id));
        }

        public Post GetPost(int id)
        {
            return _db.Post.Include(m => m.Movie).FirstOrDefault(m => m.PostId.Equals(id));
        }

        public IEnumerable<Comment> GetAll()
        {
            var comments = _db.Comment.OrderByDescending(m => m.DateCreated).Include(p => p.Post);
            return comments;
        }

        public IEnumerable<Comment> GetAll(int id)
        {
            var comments = _db.Comment.OrderByDescending(m => m.DateCreated).Include(p => p.Post).Where(x => x.Post.PostId == id).ToList();
            return comments;
        }


        public void Dispose()
        {
            _db.Dispose();
        }
    }
}