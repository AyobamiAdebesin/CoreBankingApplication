using CBA.Core.Enums;
using CBA.Core.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CBA.Core.Enums.Enums;

namespace CBA.Core.Models
{
    public class GLCategory  
    {
        [Key]
        public int Id { get; set; }
        public  string CategoryName { get; set; }
        public Categories Categories { get; set; }
        public long CategoryCode { get; set; }
        [Display(Name = "Main GL Category")]
        public MainGLCategory MainGLCategory { get; set; }
        public Status? State { get; set; }
        public string CategoryDescription { get; set; }
    }
}
