using CBA.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Core.View_Models
{
    public class GLCategoryCreateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Status? Status { get; set; }
        public string Description { get; set; }
    }
}
