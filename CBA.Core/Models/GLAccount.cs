using CBA.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Core.Models
{
    public class GLAccount
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Account Name")]
        public string AccountName { get; set; }

        [Display(Name = "GL Account Code")]
        public long AccountCode { get; set; }
        public Categories Categories { get; set; }

        [Display(Name = "Account Balance")]
        [DataType(DataType.Currency)]
        public double AccountBalance { get; set; }


        public Status? State { get; set; }


        [Required(ErrorMessage = "Select a Branch")]
        public int BranchID { get; set; }
        public Branch Branch { get; set; }

        //public GLCategory GlCategory { get; set; }
        public int GLCategoryID { get; set; }
        public virtual GLCategory GLCategory { get; set; }

    }
}
