using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SteveSimmsCodesBlog.Models
{
    public class Post
    {
        public int Id { get; set; } //Primary Key

        [Display(Name = "Blog Name")]
        public int BlogId { get; set; } //Foreign key

        public string AuthorId { get; set; }

        [Required]
        [StringLength(75, ErrorMessage = "The {0} must be at least{2} and no more than {1} characters long.", MinimumLength = 2)]
        public string Title { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The {0} must be at least{2} and no more than {1} characters long.", MinimumLength = 2)]
        public string Abstract { get; set; } // Like a preview intended to get the reader hooked into reading the entire blog

        [Required]
        public string Content { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created Date")]
        public DateTime Created { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Updated Date")]
        public DateTime? Updated { get; set; }

        public bool IsReady { get; set; } //Wether or not the particular Post is ready to be viewed by the public (blog is not still in the works )

        public string Slug { get; set; } // not determined by user input, Derived from the title the user enters 
        public byte[] ImageData { get; set; }

        public string ContentType { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; } // the physical file will be used to fill out the ImageData and ContentType props 
    }
}
