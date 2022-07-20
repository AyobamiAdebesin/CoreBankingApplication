using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBA.Core.Models;

namespace CBA.DAL.Interfaces
{
    public interface ITransactionDAO
    {
        Task<bool> SaveBulk(List<Transaction> transactions);


    }
}
