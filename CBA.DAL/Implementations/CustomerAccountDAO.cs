using CBA.Core.Enums;
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
    public class CustomerAccountDAO : ICustomerAccountDAO
    {
        private readonly AppDbContext context;
        //public CustomerAccountDAO(AppDbContext context)
        //{
        //    this.context = context;
        //}
        //public CustomerAccount Delete(long id)
        //{
        //    CustomerAccount customerAccount = context.CustomerAccounts.Find(id);
        //    if (customerAccount != null)
        //    {
        //        context.CustomerAccounts.Remove(customerAccount);
        //        context.SaveChanges();
        //    }
        //    return customerAccount;
        //}

        //public CustomerAccount RetrieveById(int id)
        //{
        //    CustomerAccount customerAccount = context.CustomerAccounts.Find(id);
        //    return customerAccount;
        //}

        //public CustomerAccount Save(CustomerAccount customerAccount)
        //{
        //    context.CustomerAccounts.Add(customerAccount);
        //    context.SaveChanges();
        //    return customerAccount;
        //}

        //public CustomerAccount GetRoles(CustomerAccount customerAccount)
        //{
        //    throw new NotImplementedException();
        //}

        //public CustomerAccount UpdateCustomerAccount(CustomerAccount customerAccountChanges)
        //{
        //    var customerAccount = context.CustomerAccounts.Attach(customerAccountChanges);
        //    customerAccount.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //    context.SaveChanges();
        //    return customerAccountChanges;
        //}

        //public IEnumerable<CustomerAccount> GetAllCustomerAccounts()
        //{
        //    var customerAccounts = context.CustomerAccounts.ToList();
        //    return customerAccounts;
        //}

        public CustomerAccountDAO(AppDbContext context)
        {
            this.context = context;
        }

        public bool AnyAccountOfType(Enums.AccountType type)
        {
            return context.CustomerAccounts.Any(a => a.AccountType == type);
        }

        public List<CustomerAccount> GetByType(Enums.AccountType actType)
        {
            return context.CustomerAccounts.Where(a => a.AccountType == actType).ToList();

        }

        public int GetCountByCustomerActType(Enums.AccountType actType, int customerId)
        {
            return context.CustomerAccounts.Where(a => a.AccountType == actType && a.Customer.ID == customerId).Count();

        }
    }
}
