using IlyasCovidMovieMadness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IlyasCovidMovieMadness.ViewModels
{
    public class PostPartialViewModel
    {
        public Post Post { get; set; }
        public double AvarageRaiting { get; set; }
    }
}