using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Core.Models
{
    public static class ClaimsStore
    {
        public static List<Claim> AllClaims = new List<Claim>()
        {
        new Claim("Create Role", "Create Role"),
        new Claim("Edit Role","Edit Role"),
        };
    }
}
