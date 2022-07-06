using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Core.Utility
{
    public class BaseEntity
    {
        public long Id { get; set; }

        public virtual DateTime DateCreated { get; set; }

        public virtual DateTime DateModified { get; set; }
    }
}
