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
    public class CustomerDAO : ICustomerDAO
    {
        private readonly AppDbContext context;
        public CustomerDAO(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Customer> GetAll()
        {
            return context.Customers.ToList();
        }

        public Customer GetById(int id)
        {
            Customer result = context.Customers.SingleOrDefault(c => c.ID.Equals(id));
            return result;
        }



        //public int GenerateCustomerId(int id)
        //{
        //    var now = DateTime.Now;
        //    var zeroDate = DateTime.MinValue.AddHours(now.Hour).AddMinutes(now.Minute).AddSeconds(now.Second).AddMilliseconds(now.Millisecond);
        //    int newCustomerId = (int)(zeroDate.Ticks / 10000);
        //    return newCustomerId;
        //}
        //public Customer Delete(long id)
        //{
        //    Customer customer = context.Customers.Find(id);
        //    if (customer != null)
        //    {
        //        context.Customers.Remove(customer);
        //        context.SaveChanges();
        //    }
        //    return customer;
        //}

        //public Customer RetrieveById(int id)
        //{
        //    Customer customer = context.Customers.Find(id);
        //    return customer;
        //}

        //public Customer Save(Customer customer)
        //{
        //    context.Customers.Add(customer);
        //    context.SaveChanges();
        //    return customer;
        //}

        //public Customer GetRoles(Customer customer)
        //{
        //    throw new NotImplementedException();
        //}

        //public Customer UpdateCustomer(Customer customerChanges)
        //{
        //    var customer = context.Customers.Attach(customerChanges);
        //    customer.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //    context.SaveChanges();
        //    return customerChanges;
        //}

        //public IEnumerable<Customer> GetAllCustomers()
        //{
        //    var customers = context.Customers.ToList();
        //    return customers;
        //}
    }
}
