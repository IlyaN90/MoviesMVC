using IlyasCovidMovieMadness.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IlyasCovidMovieMadness.Context
{
    public class cmmDbContext : DbContext
    {
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Post> Post { get; set; }
    }
}