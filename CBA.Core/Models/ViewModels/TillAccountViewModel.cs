using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Core.Models.ViewModels
{
    public class TillAccountViewModel
    {
        public int Id { get; set; }


        public string Username { get; set; }

        [Display(Name = "Account Name")]
        public string GLAccountName { get; set; }

        [Display(Name = "Account Balance")]
        public string AccountBalance { get; set; }

        public bool IsDeletable { get; set; }

        public bool HasDetails { get; set; }
    }
}
