using CBA.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Core.Models
{
    public class CreateRole
    {
        [Required]
        public string RoleName { get; set; }
        public Status? Status { get; set; }
    }
}
