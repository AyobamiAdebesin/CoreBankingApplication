using CBA.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Core.Models
{
    [MetadataType(typeof(CreateRole))]
    public class CreateRole
    {
        [Required]
        [RegularExpression(@"^[ a-zA-Z]+$", ErrorMessage = "Full name should contain characters and white spaces only"), MaxLength(40)]
        public string RoleName { get; set; }

        public Status? Status { get; set; }
    }
}
