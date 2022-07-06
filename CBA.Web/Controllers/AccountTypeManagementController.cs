using CBA.Core.Models;
using CBA.DAL.Context;
using CBA.DAL.Interfaces;
using CBA.Services.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CBA.Web.Controllers
{
    public class AccountTypeManagementController : Controller
    {
        public class AccountTypeManagementsController : Controller
        {
            private readonly AppDbContext context;
            private readonly IMailService service;
            private readonly IGLAccountDAO gLAccountDAO;

            public AccountTypeManagementsController(AppDbContext context, IMailService _service, IGLAccountDAO _gLAccountDAO)
            {
                this.context = context;
                service = _service;
                gLAccountDAO = _gLAccountDAO;
            }

            //[HttpGet]
            //[AllowAnonymous]
            //public IActionResult AccessDenied()
            //{
            //    return View();
            //}
            // GET: /<controller>/
            public async Task<ActionResult> Index()
            {
                var accountTypeManagements = context.AccountTypeManagements.Include(a => a.COTIncomeGl).Include(a => a.CurrentInterestExpenseGl).Include(a => a.LoanInterestIncomeGl).Include(a => a.LoanInterestReceivableGl).Include(a => a.SavingsInterestExpenseGl).Include(a => a.SavingsInterestPayableGl);
                return View(await accountTypeManagements.ToListAsync());
            }

            public ActionResult Info()
            {
                AccountTypeManagement accountConfiguration = context.AccountTypeManagements.First();
                //AccountConfiguration accountConfiguration = db.AccountConfigurations.Include(a => a.CurrentCotIncomeGl).Include(a => a.CurrentInterestExpenseGl).Include(a => a.LoanInterestExpenseGl).Include(a => a.LoanInterestIncomeGl).Include(a => a.LoanInterestReceivableGl).Include(a => a.SavingsInterestExpenseGl).Include(a => a.SavingsInterestPayableGl).First();
                if (accountConfiguration == null)
                {
                    return RedirectToAction("index", "home");

                }
                return View(accountConfiguration);
            }

            // GET: AccountTypeManagements/Details/5
            public async Task<ActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return RedirectToAction("index", "home");
                }
                AccountTypeManagement accountTypeManagement = await context.AccountTypeManagements.FindAsync(id);
                if (accountTypeManagement == null)
                {
                    return RedirectToAction("index", "home");

                }
                return View(accountTypeManagement);
            }

            // GET: AccountTypeManagements/Create
            public ActionResult Create()
            {
                ViewBag.COTIncomeGlID = new SelectList(context.GLAccounts, "ID", "AccountName");
                ViewBag.CurrentInterestExpenseGlID = new SelectList(context.GLAccounts, "ID", "AccountName");
                ViewBag.LoanInterestIncomeGlID = new SelectList(context.GLAccounts, "ID", "AccountName");
                ViewBag.LoanInterestReceivableGlID = new SelectList(context.GLAccounts, "ID", "AccountName");
                ViewBag.SavingsInterestExpenseGlID = new SelectList(context.GLAccounts, "ID", "AccountName");
                ViewBag.SavingsInterestPayableGlID = new SelectList(context.GLAccounts, "ID", "AccountName");
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> Create(AccountTypeManagement accountTypeManagement)
            {
                if (ModelState.IsValid)
                {
                    accountTypeManagement.FinancialDate = DateTime.Now;
                    context.AccountTypeManagements.Add(accountTypeManagement);
                    await context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

                ViewBag.COTIncomeGlID = new SelectList(context.GLAccounts, "ID", "AccountName", accountTypeManagement.COTIncomeGlID);
                ViewBag.CurrentInterestExpenseGlID = new SelectList(context.GLAccounts, "ID", "AccountName", accountTypeManagement.CurrentInterestExpenseGlID);
                ViewBag.LoanInterestIncomeGlID = new SelectList(context.GLAccounts, "ID", "AccountName", accountTypeManagement.LoanInterestIncomeGlID);
                ViewBag.LoanInterestReceivableGlID = new SelectList(context.GLAccounts, "ID", "AccountName", accountTypeManagement.LoanInterestReceivableGlID);
                ViewBag.SavingsInterestExpenseGlID = new SelectList(context.GLAccounts, "ID", "AccountName", accountTypeManagement.SavingsInterestExpenseGlID);
                ViewBag.SavingsInterestPayableGlID = new SelectList(context.GLAccounts, "ID", "AccountName", accountTypeManagement.SavingsInterestPayableGlID);
                return View(accountTypeManagement);
            }

            // GET: AccountTypeManagements/Edit/5
            public async Task<ActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return RedirectToAction("index", "home");

                }
                AccountTypeManagement accountTypeManagement = await context.AccountTypeManagements.FindAsync(id);
                if (accountTypeManagement == null)
                {
                    return RedirectToAction("index", "home");

                }
                InitializeGetViewBags(accountTypeManagement);
                return View(accountTypeManagement);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> Edit(AccountTypeManagement accountTypeManagement)
            {
                if (ModelState.IsValid)
                {
                    context.Entry(accountTypeManagement).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                InitializePostViewBags(accountTypeManagement);
                return View(accountTypeManagement);
            }

            // GET: AccountTypeManagements/Edit/5
            public ActionResult EditSavings()
            {
                AccountTypeManagement accountTypeManagement = context.AccountTypeManagements.First();
                if (accountTypeManagement == null)
                {
                    return RedirectToAction("index", "home");

                }
                InitializeGetViewBags(accountTypeManagement);
                return View(accountTypeManagement);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> EditSavings(AccountTypeManagement accountTypeManagement)
            {
                if (ModelState.IsValid)
                {

                    context.Entry(accountTypeManagement).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                InitializePostViewBags(accountTypeManagement);
                return View(accountTypeManagement);
            }

            public ActionResult EditCurrent()
            {
                AccountTypeManagement accountTypeManagement = context.AccountTypeManagements.First();
                if (accountTypeManagement == null)
                {
                    return RedirectToAction("index", "home");

                }
                InitializeGetViewBags(accountTypeManagement);
                return View(accountTypeManagement);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> EditCurrent(AccountTypeManagement accountTypeManagement)
            {
                if (ModelState.IsValid)
                {

                    context.Entry(accountTypeManagement).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                InitializePostViewBags(accountTypeManagement);
                return View(accountTypeManagement);
            }

            public ActionResult EditLoan()
            {
                AccountTypeManagement accountTypeManagement = context.AccountTypeManagements.First();
                if (accountTypeManagement == null)
                {
                    return RedirectToAction("index", "home");

                }
                InitializeGetViewBags(accountTypeManagement);
                return View(accountTypeManagement);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> EditLoan(AccountTypeManagement accountTypeManagement)
            {
                if (ModelState.IsValid)
                {

                    context.Entry(accountTypeManagement).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                InitializePostViewBags(accountTypeManagement);
                return View(accountTypeManagement);
            }

            // GET: AccountTypeManagements/Delete/5
            public async Task<ActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return RedirectToAction("index", "home");

                }
                AccountTypeManagement accountTypeManagement = await context.AccountTypeManagements.FindAsync(id);
                if (accountTypeManagement == null)
                {
                    return RedirectToAction("index", "home");

                }
                return View(accountTypeManagement);
            }

            // POST: AccountTypeManagements/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> DeleteConfirmed(int id)
            {
                AccountTypeManagement accountTypeManagement = await context.AccountTypeManagements.FindAsync(id);
                context.AccountTypeManagements.Remove(accountTypeManagement);
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

            public void InitializeGetViewBags(AccountTypeManagement accountTypeManagement)
            {
                var allAssets = gLAccountDAO.GetAllAssetAccounts();
                var allLiabilities = gLAccountDAO.GetAllLiabilityAccounts();
                var allIncomes = gLAccountDAO.GetAllIncomeAccounts();
                var allExpenses = gLAccountDAO.GetAllExpenseAccounts();



                ViewBag.COTIncomeGlID = new SelectList(allIncomes, "ID", "AccountName", accountTypeManagement.COTIncomeGlID);
                ViewBag.CurrentInterestExpenseGlID = new SelectList(allExpenses, "ID", "AccountName", accountTypeManagement.CurrentInterestExpenseGlID);
                ViewBag.LoanInterestIncomeGlID = new SelectList(allIncomes, "ID", "AccountName", accountTypeManagement.LoanInterestIncomeGlID);
                ViewBag.LoanInterestReceivableGlID = new SelectList(allAssets, "ID", "AccountName", accountTypeManagement.LoanInterestReceivableGlID);
                ViewBag.SavingsInterestExpenseGlID = new SelectList(allExpenses, "ID", "AccountName", accountTypeManagement.SavingsInterestExpenseGlID);
                ViewBag.SavingsInterestPayableGlID = new SelectList(allLiabilities, "ID", "AccountName", accountTypeManagement.SavingsInterestPayableGlID);
            }

            public void InitializePostViewBags(AccountTypeManagement accountTypeManagement)
            {

                var allAssets = gLAccountDAO.GetAllAssetAccounts();
                var allLiabilities = gLAccountDAO.GetAllLiabilityAccounts();
                var allIncomes = gLAccountDAO.GetAllIncomeAccounts();
                var allExpenses = gLAccountDAO.GetAllExpenseAccounts();


                ViewBag.COTIncomeGlID = new SelectList(allIncomes, "ID", "AccountName", accountTypeManagement.COTIncomeGlID);
                ViewBag.CurrentInterestExpenseGlID = new SelectList(allExpenses, "ID", "AccountName", accountTypeManagement.CurrentInterestExpenseGlID);
                ViewBag.LoanInterestIncomeGlID = new SelectList(allIncomes, "ID", "AccountName", accountTypeManagement.LoanInterestIncomeGlID);
                ViewBag.LoanInterestReceivableGlID = new SelectList(allAssets, "ID", "AccountName", accountTypeManagement.LoanInterestReceivableGlID);
                ViewBag.SavingsInterestExpenseGlID = new SelectList(allExpenses, "ID", "AccountName", accountTypeManagement.SavingsInterestExpenseGlID);
                ViewBag.SavingsInterestPayableGlID = new SelectList(allLiabilities, "ID", "AccountName", accountTypeManagement.SavingsInterestPayableGlID);
            }

            public void InstantiateGlAccounts(AccountTypeManagement accountTypeManagement)
            {
                if (accountTypeManagement.SavingsInterestExpenseGlID == 0) accountTypeManagement.SavingsInterestExpenseGlID = null;
                if (accountTypeManagement.SavingsInterestPayableGlID == 0) accountTypeManagement.SavingsInterestPayableGlID = null;
                if (accountTypeManagement.COTIncomeGlID == 0) accountTypeManagement.COTIncomeGlID = null;
                if (accountTypeManagement.CurrentInterestExpenseGlID == 0) accountTypeManagement.CurrentInterestExpenseGlID = null;
                if (accountTypeManagement.LoanInterestIncomeGlID == 0) accountTypeManagement.LoanInterestIncomeGlID = null;
                if (accountTypeManagement.LoanInterestReceivableGlID == 0) accountTypeManagement.LoanInterestReceivableGlID = null;
            }

        }
    }
}
