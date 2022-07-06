using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CBA.Core.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }

        [Required]
        [Display(Name = "Membership Type")]
        public string Name { get; set; }

        public short SignUpFee { get; set; }

        public byte DurationInMonths { get; set; }

        public byte DiscountRate { get; set; }
    }
}
