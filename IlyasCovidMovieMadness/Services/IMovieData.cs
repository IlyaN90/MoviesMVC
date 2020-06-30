using IlyasCovidMovieMadness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IlyasCovidMovieMadness.Services
{
    public interface IMovieData
    {
        IEnumerable<Movie> GetAll();
        Movie Get(int id);
        void Add(Movie movie);
        void Delete(int id);
        void Edit(Movie movie);
        IEnumerable<Post> GetPost();
        void Dispose();

    }
}