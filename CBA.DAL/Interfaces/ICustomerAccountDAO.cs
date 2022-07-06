using CBA.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CBA.Core.Enums.Enums;

namespace CBA.DAL.Interfaces
{
    public interface ICustomerAccountDAO
    {
        //CustomerAccount Save(CustomerAccount item);
        //CustomerAccount RetrieveById(int id);
        //CustomerAccount Delete(long id);
        //CustomerAccount UpdateCustomerAccount(CustomerAccount userChanges);
        //IEnumerable<CustomerAccount> GetAllCustomerAccounts();
        //CustomerAccount GetRoles(CustomerAccount user);



        List<CustomerAccount> GetByType(AccountType actType);
        int GetCountByCustomerActType(AccountType actType, int customerId);
        bool AnyAccountOfType(AccountType type);
    }
}
