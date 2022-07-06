using CBA.Core.Models;
using CBA.DAL.Context;
using CBA.DAL.Interfaces;
using CBA.Services.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CBA.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IMailService service;
        private readonly AppDbContext context;
        public CustomerController(IMailService _service, AppDbContext context)
        {
            service = _service;
            this.context = context;
        }


        public async Task<ActionResult> Index()
        {
            return View(await context.Customers.ToListAsync());
        }



        // GET: Consumers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("index", "home");

            }
            Customer consumer = await context.Customers.FindAsync(id);
            if (consumer == null)
            {
                return RedirectToAction("index", "home");

            }
            return View(consumer);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.CustomerLongID = service.GenerateCustomerLongId();

                if (customer.CustomerLongID != null && !String.IsNullOrWhiteSpace(customer.FullName))
                {
                    var customerInfo = (customer.FullName + " " + "(" + customer.CustomerLongID.ToString() + ")");
                    customer.CustomerInfo = customerInfo;
                }

                context.Customers.Add(customer);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Consumers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("index", "home");

            }
            Customer consumer = await context.Customers.FindAsync(id);
            if (consumer == null)
            {
                return RedirectToAction("index", "home");

            }
            return View(consumer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Customer consumer)
        {
            if (ModelState.IsValid)
            {

                if (consumer.CustomerLongID != null && !String.IsNullOrWhiteSpace(consumer.FullName))
                {
                    var consumerInfo = (consumer.FullName + " " + "(" + consumer.CustomerLongID.ToString() + ")");
                    consumer.CustomerInfo = consumerInfo;
                }
                context.Entry(consumer).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(consumer);
        }

        // GET: Consumers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("index", "home");

            }
            Customer consumer = await context.Customers.FindAsync(id);
            if (consumer == null)
            {
                return RedirectToAction("index", "home");

            }
            return View(consumer);
        }

        // POST: Consumers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Customer consumer = await context.Customers.FindAsync(id);
            context.Customers.Remove(consumer);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }

        //public IActionResult Index()
        //{
        //    var customers = _customer.GetAllCustomers();
        //    return View(customers);
        //}
        //[HttpPost]
        //public IActionResult Delete(long id)
        //{
        //    Customer customer = _customer.Delete(id);
        //    return RedirectToAction("index", "customer", new { area = "" });
        //}
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(Customer model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Customer newCustomer = new()
        //        {
        //            Id = model.Id,
        //            NewCustomerId = _customer.GenerateCustomerId(model.NewCustomerId),
        //            FirstName = model.FirstName,
        //            LastName = model.LastName,
        //            Gender = model.Gender,
        //            Email = model.Email,
        //            State = model.State,
        //            //CustomerAccount = model.CustomerAccount,
        //        };

        //        _customer.Save(newCustomer);
        //        //return RedirectToAction("index", new { id = newUser.Id });
        //        return RedirectToAction("index", "customer", new { area = "" });
        //    }

        //    return View(model);
        //}

        //[HttpGet]
        //public IActionResult Detail(int id)
        //{
        //    var customer = _customer.RetrieveById(id);
        //    Customer editUserViewModel = new Customer()
        //    {
        //        //CustomerId = customer.CustomerId,
        //        FirstName = customer.FirstName,
        //        LastName = customer.LastName,
        //        Gender = customer.Gender,
        //        Email = customer.Email,
        //        State = customer.State,
        //        CustomerAccount = customer.CustomerAccount,
        //    };
        //    return View(editUserViewModel);
        //}

        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    var customer = _customer.RetrieveById(id);
        //    Customer editUserViewModel = new Customer()
        //    {
        //        //CustomerId = customer.CustomerId,
        //        FirstName = customer.FirstName,
        //        LastName = customer.LastName,
        //        Gender = customer.Gender,
        //        Email = customer.Email,
        //        State = customer.State,
        //        CustomerAccount = customer.CustomerAccount,
        //    };
        //    return View(editUserViewModel);
        //}

        //[HttpPost]
        //public IActionResult Edit(Customer model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Customer customer = _customer.RetrieveById(model.Id);
        //        //Console.WriteLine(model.Id);
        //        //customer.CustomerId = model.CustomerId;
        //        customer.FirstName = model.FirstName;
        //        customer.LastName = model.LastName;
        //        customer.Gender = model.Gender;
        //        customer.Email = model.Email;
        //        customer.State = model.State;
        //        customer.CustomerAccount = model.CustomerAccount;

        //        Customer updatedCustomer = _customer.UpdateCustomer(customer);

        //        return RedirectToAction("index", "customer", new { area = "" });
        //    }

        //    return View(model);
        //}
    }
}
