using Microsoft.AspNetCore.Identity;
using SteveSimmsCodesBlog.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SteveSimmsCodesBlog.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string AuthorId { get; set; }

        public string ModeratorId { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and no more than {1} characters long", MinimumLength = 2)]
        [Display(Name = "Comment")]
        public string Body { get; set; }

        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

        public DateTime? Moderated { get; set; }
        public DateTime? Deleted { get; set; }

        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and no more than {1} characters long", MinimumLength = 2)]
        [Display(Name = "Moderated Comment")]
        public string ModeratedBody { get; set; } // When the moderator changes the user comments 

        public ModerationType ModerationType { get; set;}

        //Navigation properties levrages the foreign key to get the entire record 
        public virtual Post Post { get; set; } // hold the entire record of the AuthorId string 


        public virtual IdentityUser Author { get; set; } // Represents the default id of the user in our system tied to our foreign key Author 

        public virtual IdentityUser Moderator { get; set; } // purpose of this is to go from the moderator id string to the (IdentityUser)moderator record 
    }
}
