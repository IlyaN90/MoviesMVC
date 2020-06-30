using IlyasCovidMovieMadness.Context;
using IlyasCovidMovieMadness.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace IlyasCovidMovieMadness.Services
{
    public class SqlMovieData : IMovieData
    {
        private readonly cmmDbContext _db;

        public SqlMovieData(cmmDbContext db)
        {
            _db = db;
        }

        public void Add(Movie movie)
        {
            _db.Movie.Add(movie);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var movie = Get(id);
            if (movie != null)
            {
                if (movie.Post != null)
                {
                    var post = _db.Post.Find(movie.Post.PostId);
                    if (post != null)
                    {
                        _db.Post.Remove(post);
                        _db.SaveChanges();
                    }
                }
                _db.Movie.Remove(movie);
                _db.SaveChanges();
            }
        }

        public void Edit(Movie movie)
        {
            _db.Entry(movie).State = EntityState.Modified;
            _db.SaveChanges();

            /*var entry = _db.Entry(movie);
            entry.State = EntityState.Modified;
            _db.SaveChanges();*/
        }

        public Movie Get(int id)
        {
            return _db.Movie.Find(id);
        }

        public IEnumerable<Movie> GetAll()
        {
            var movie = _db.Movie.Include(m => m.Post);
            return movie;
        }

        public IEnumerable<Post> GetPost()
        {
            return _db.Post;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}