using CBA.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.DAL.Interfaces
{
    public interface ITellerDAO
    {
        Task<List<ApplicationUser>> GetAllTellers();
        Task<List<ApplicationUser>> GetTellersWithNoTills();
        Task<List<TillAccount>> GetAllTellerDetails();
        List<TillAccount> GetDbTillAccounts();
        Task<List<ApplicationUser>> GetTellersWithTills();
    }
}
