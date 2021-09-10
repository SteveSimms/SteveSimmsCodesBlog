using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SteveSimmsCodesBlog.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string AuthorId { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "The {0} must be at least {2} and no more than {1} characters long", MinimumLength = 2)]
        public string Text { get; set; } // holds the text of the tag

        public virtual Post Post { get; set; } // allows us to navigate away from the tag and to the Post record 

        public virtual IdentityUser Author { get; set; }
    }
}
