using CBA.Core.Enums;
using CBA.Core.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Core.Models
{
    public class MainAccount : BaseEntity
    {
        [Display(Name = "Branch Name")]
        [Required(ErrorMessage = "{0} is required")]
        public virtual AccountCategory Name { get; set; }
    }
}
