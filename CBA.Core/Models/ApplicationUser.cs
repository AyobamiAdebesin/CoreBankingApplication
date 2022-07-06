using CBA.Core.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CBA.Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Key]
        [Required]
        
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        public Gender? Gender { get; set; }
        public Status? Status { get; set; }
    }
}
