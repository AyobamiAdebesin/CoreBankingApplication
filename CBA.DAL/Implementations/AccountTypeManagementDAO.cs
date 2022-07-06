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
    public class AccountTypeManagementDAO : IAccountTypeManagementDAO
    {
        private readonly AppDbContext context;

        public AccountTypeManagementDAO(AppDbContext context)
        {
            this.context = context;
        }

        public AccountTypeManagement GetFirst()
        {
            return context.AccountTypeManagements.First();
        }
    }
}
