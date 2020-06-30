using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;

namespace IlyasCovidMovieMadness.Models
{
    public class Movie
    {
        [Display(Name = "Movie")]
        public int MovieId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Title { get; set; }
        //[RegularExpression(@"^[a-zA-Z''-'\s]{1,50}$",
        // ErrorMessage = "Characters are not allowed.")]
        [StringLength(500, MinimumLength = 1)]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        public virtual Post Post { get; set; }
    }
}