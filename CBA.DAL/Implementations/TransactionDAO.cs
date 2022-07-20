using CBA.Core.Models;
using CBA.DAL.Context;
using CBA.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.DAL.Implementations
{
    public class TransactionDAO : ITransactionDAO
    {
        private readonly AppDbContext context;
        public TransactionDAO(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> SaveBulk(List<Transaction> transactions)
        {
            foreach (Transaction transaction in transactions)
            {
                await context.Transactions.AddAsync(transaction);
            }

            await context.SaveChangesAsync();
            return true;
        }
    }
}
