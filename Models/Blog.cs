using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SteveSimmsCodesBlog.Models
{
    public class Blog
    {
        public int Id { get; set; } //Records the unique piece of Data for every Blog aka The "Primary Key" For our Model
        public string AuthorId { get; set; } //Author Name "Foreign Key"- in the  Blog Model is the "Primary key " - in the ASP.NET user Model- The Foreign key in a class is the primary key in another class 

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at most {1} characters.", MinimumLength = 2)]
        public string Name { get; set; } //Blog Title They call it Name in the tut [Required]-data Annotation means Blogs must have a name/title [SringLength]- max 100, min 2 with error message if terms are violated  

        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and at most {1} characters.", MinimumLength = 2)]
        public string Description { get; set; } //Blog Description

        [DataType(DataType.Date)]
        [Display(Name = "Created Date")]
        public DateTime Created { get; set; } // Date and time of the blog being posted  [Annotation]-display purposes - treats prop like a date and not like datetime  [Display(Name = "Created")]- effects how prop is written to form user will see Created Date"

        [DataType(DataType.Date)]
        [Display(Name = "Updated Date")]
        public DateTime? Updated { get; set; } // Reflects when the blog was update if it was 

        [Display(Name = "Blog Image")]
        public byte[] ImageData { get; set; } // Will hold the byte stream of the related img data

        [Display(Name = "Image Type")]
        public string ContentType { get; set; } // Will reflect the type of img file png jpeg etc 

        [NotMapped]
        public IFormFile Image { get; set; }    // Represents the physical Image that the user selects 

        //Navigation Property- nav props deal in pairs or relationships between other props
        public virtual BlogUser Author { get; set; } // Refering to the Foreign key AuthorId without the foreign key we have no refrence to the parent 
        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();//Blog is a Parent to a collection of Post(s) Refrences Post.cs

    }
}
