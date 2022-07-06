using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Core.Models
{
    public class TellersTill
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A Teller must be selected")]
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Required(ErrorMessage = "The Till Account must be selected")]

        public int GLAccounID { get; set; }
        public virtual GLAccount GlAccount { get; set; }
    }
}
