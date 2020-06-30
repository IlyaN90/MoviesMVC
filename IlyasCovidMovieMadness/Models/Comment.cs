using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IlyasCovidMovieMadness.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        [Required]
        [Display(Name = "User")]
        [StringLength(50, MinimumLength = 1)]
        public string UserName { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 1)]
        public string Text { get; set; }
        [Display(Name = "Raiting")]
        [Range(1, 5, ErrorMessage = "The field {0} must be between {1} and {2}.")]
        public int UserRatig { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created")]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Edited")]
        public DateTime DateEdited { get; set; }

        public int PostID { get; set; }
        public Post Post { get; set; }
    }
}