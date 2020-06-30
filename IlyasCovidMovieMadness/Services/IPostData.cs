using IlyasCovidMovieMadness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IlyasCovidMovieMadness.Services
{
    public interface IPostData
    {
        IEnumerable<Post> GetAll();
        Post Get(int id);
        void Add(Post post);
        void Delete(int id);
        void Edit(Post post);
        Movie GetMovie(int id);
        IEnumerable<Movie> GetAllMovies();
        void Dispose();
    }
}