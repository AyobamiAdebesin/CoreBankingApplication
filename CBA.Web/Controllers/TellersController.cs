using CBA.Core.Models;
using CBA.Core.Models.ViewModels;
using CBA.DAL.Context;
using CBA.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CBA.Web.Controllers
{
    public class TellersController : Controller
    {
        private readonly AppDbContext context;
        private readonly ITellerDAO tellerDAO;
        private readonly IGLAccountDAO gLAccountDAO;
        private readonly UserManager<ApplicationUser> userManager;

        public TellersController(AppDbContext _context, ITellerDAO _tellerDAO, IGLAccountDAO _gLAccountDAO, UserManager<ApplicationUser> _userManager)
        {
            context = _context;
            tellerDAO = _tellerDAO;
            gLAccountDAO = _gLAccountDAO;
            userManager = _userManager;
        }

        // GET: TillAccounts
        public async Task<ActionResult> Index()
        {
            var tellerDetails = await tellerDAO.GetAllTellerDetails();
            var tellerDetailsString = JsonConvert.SerializeObject(tellerDetails);
            Console.WriteLine(tellerDetailsString);
            var viewModel = new List<TillAccountViewModel>();

            foreach (var detail in tellerDetails)
            {
                TillAccountViewModel data;
                if (detail.GlAccountID == 0)
                {
                    data = new TillAccountViewModel
                    {
                        GLAccountName = "--",
                        AccountBalance = "--",
                        Username = context.Users.Find(detail.UserId).UserName,
                        HasDetails = false,
                        IsDeletable = false
                    };
                    viewModel.Add(data);
                }
                else
                {
                    var applicationUser = context.Users.Find(detail.UserId);
                    //if (detail.GlAccount != null)
                    //{
                    data = new TillAccountViewModel
                    {
                        GLAccountName = detail.GlAccount.AccountName,
                        Id = detail.Id,
                        Username = applicationUser.UserName,
                        AccountBalance = detail.GlAccount.AccountBalance.ToString(),
                    };
                    viewModel.Add(data);
                    //}

                }
            }


            return View(viewModel);
        }

        // GET: TillAccounts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ErrorView", "Error");
            }
            TillAccount tillAccount = await context.TillAccounts.FindAsync(id);
            if (tillAccount == null)
            {
                return RedirectToAction("ErrorView", "Error");
            }
            return View(tillAccount);
        }

        // GET: TillAccounts/Create
        public async Task<ActionResult> Create()
        {
            //var testList = new List<string> { "a", "b", "c" };

            ViewBag.Users = new SelectList(await tellerDAO.GetTellersWithNoTills(), "Id", "UserName");
            ViewBag.GlAccountID = new SelectList(gLAccountDAO.GetTillsWithoutTellers(), "ID", "AccountName");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TillAccount tillAccount)
        {
            if (ModelState.IsValid)
            {
                context.TillAccounts.Add(tillAccount);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Users = new SelectList(await tellerDAO.GetTellersWithNoTills(), "Id", "UserName", tillAccount.UserId);
            ViewBag.GlAccountID = new SelectList(await tellerDAO.GetTellersWithNoTills(), "ID", "AccountName", tillAccount.GlAccountID);
            return View(tillAccount);
        }

        // GET: TillAccounts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ErrorView", "Error");
            }
            TillAccount tillAccount = await context.TillAccounts.FindAsync(id);
            if (tillAccount == null)
            {
                return RedirectToAction("ErrorView", "Error");
            }
            ViewBag.GlAccountID = new SelectList(context.GLAccounts, "ID", "AccountName", tillAccount.GlAccountID);
            return View(tillAccount);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TillAccount tillAccount)
        {
            if (ModelState.IsValid)
            {
                context.Entry(tillAccount).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.GlAccountID = new SelectList(context.GLAccounts, "ID", "AccountName", tillAccount.GlAccountID);
            return View(tillAccount);
        }

        // GET: TillAccounts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ErrorView", "Error");
            }
            TillAccount tillAccount = await context.TillAccounts.FindAsync(id);
            if (tillAccount == null)
            {
                return RedirectToAction("ErrorView", "Error");
            }
            return View(tillAccount);
        }

        // POST: TillAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TillAccount tillAccount = await context.TillAccounts.FindAsync(id);
            context.TillAccounts.Remove(tillAccount);
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
    }
}
