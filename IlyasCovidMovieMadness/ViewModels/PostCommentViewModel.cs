using IlyasCovidMovieMadness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IlyasCovidMovieMadness.ViewModels
{
    public class PostCommentViewModel
    {

        public Post Post { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<Comment> Comments { get; set; }

        public PostCommentViewModel()
        {
        }
    }
}