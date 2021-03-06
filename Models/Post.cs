using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SteveSimmsCodesBlog.Enums;
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

        public string BlogUserId { get; set; }

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




        public ReadyStatus ReadyStatus { get; set; }

        public string Slug { get; set; } // not determined by user input, Derived from the title the user enters 
        public byte[] ImageData { get; set; }

        public string ContentType { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; } // the physical file will be used to fill out the ImageData and ContentType props 

        //Navigation Property 
        public virtual Blog Blog { get; set; }
        public virtual BlogUser BlogUser { get; set; }

        public virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

    }
}
