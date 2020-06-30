using IlyasCovidMovieMadness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IlyasCovidMovieMadness.Services
{
    public interface ICommentData
    {
        IEnumerable<Comment> GetAll(int id);
        IEnumerable<Comment> GetAll();
        Comment Get(int id);
        void Add(Comment Comment);
        IEnumerable<Post> GetAllPosts();
        void Delete(int id);
        void Edit(Comment comment);
        Post GetPost(int id);
        void Dispose();
    }
}