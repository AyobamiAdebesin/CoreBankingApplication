using CBA.Core.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Core.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string roleName) : base(roleName) { }

        public ApplicationRole(string roleName, Status? State) : base(roleName)
        {
            this.State = State;
        }

        public Status? State { get; set; } 

       // public ApplicationRole(string roleName, string State) : base(roleName)
       // {
       //     this.State = State;
       // }
        //public string Name { get; set; }
       // public string State { get; set; }
    }
}
