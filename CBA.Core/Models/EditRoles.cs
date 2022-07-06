using CBA.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Core.Models
{
    public class EditRoles
    {
        public EditRoles()
        {
            Users = new List<string>();
        }
        public string Id { get; set; }
        [Required(ErrorMessage ="Role Name is required")]
        [Display(Name ="Role Name")]
        public string RoleName { get; set; }
        public Status? Status { get; set; }
        public List<string> Users { get; set; }

    }
}
