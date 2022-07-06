using CBA.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.DAL.Interfaces
{
    public interface ICustomerDAO
    {

        Customer GetById(int id);
        IEnumerable<Customer> GetAll();


        //Customer Save(Customer item);
        //Customer RetrieveById(int id);
        //Customer Delete(long id);
        //Customer UpdateCustomer(Customer userChanges);
        //IEnumerable<Customer> GetAllCustomers();
        //Customer GetRoles(Customer user);
        //int GenerateCustomerId(int id);
    }
}
