using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IlyasCovidMovieMadness.Models
{
    public class Post
    {
        [ForeignKey("Movie")]
        public int PostId { get; set; }
        [Display(Name = "Movie title")]
        [StringLength(50, MinimumLength = 1)]
        public string MovieTitle { get; set; }
        [Required]
        [Display(Name = "Post")]
        [MaxLength(1000)]
        public string Text { get; set; }
        [Display(Name = "Raiting")]
        [Range(1, 5, ErrorMessage = "The field {0} must be between {1} and {2}.")]
        public int PostRating { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created")]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Edited")]
        public DateTime DateEdited { get; set; }

        //public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}