using CBA.Core.Models;
using CBA.DAL.Context;
using CBA.DAL.Interfaces;
using CBA.Services.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CBA.Web.Controllers
{
    public class GLAccountController : Controller
    {
        private readonly AppDbContext context;
        private readonly IMailService service;

        public GLAccountController(AppDbContext context, IMailService _service)
        {
            this.context = context;
            service = _service;
        }

        public async Task<ActionResult> Index()
        {
            var glAccounts = context.GLAccounts.Include(g => g.Branch).Include(g => g.GLCategory);
            return View(await glAccounts.ToListAsync());
        }

        // GET: GlAccounts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ErrorView", "Error");
            }
            GLAccount glAccount = await context.GLAccounts.FindAsync(id);
            if (glAccount == null)
            {
                return RedirectToAction("ErrorView", "Error");
            }
            return View(glAccount);
        }

        // GET: GlAccounts/Create
        public ActionResult Create()
        {
            ViewBag.BranchID = new SelectList(context.Branches, "ID", "Name");
            ViewBag.GlCategoryID = new SelectList(context.GLCategories, "ID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(GLAccount glAccount)
        {
            if (ModelState.IsValid)
            {
                ViewBag.BranchID = new SelectList(context.Branches, "ID", "Name", glAccount.BranchID);
                ViewBag.GlCategoryID = new SelectList(context.GLCategories, "ID", "Name", glAccount.GLCategoryID);

                if (!service.IsUniqueGLAccount(glAccount.AccountName))
                {
                    AddError("GL Account Name already exists");
                    return View("Create");
                }

                GLCategory glCategory = context.GLCategories.Find(glAccount.GLCategoryID);

                glAccount.AccountCode = service.GenerateGLAccountNumber(glCategory.MainGLCategory);
                glAccount.AccountBalance = 0;
                context.GLAccounts.Add(glAccount);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(glAccount);
        }

        // GET: GlAccounts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ErrorView", "Error");
            }
            GLAccount glAccount = await context.GLAccounts.FindAsync(id);
            if (glAccount == null)
            {
                return RedirectToAction("ErrorView", "Error");
            }
            ViewBag.BranchID = new SelectList(context.Branches, "ID", "Name", glAccount.BranchID);
            ViewBag.GlCategoryID = new SelectList(context.GLCategories, "ID", "Name", glAccount.GLCategoryID);
            return View(glAccount);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(
            GLAccount glAccount)
        {
            if (ModelState.IsValid)
            {
                GLAccount dbGlAccount = await context.GLAccounts.FindAsync(glAccount.Id);

                ViewBag.BranchID = new SelectList(context.Branches, "ID", "Name", glAccount.BranchID);
                ViewBag.GlCategoryID = new SelectList(context.GLCategories, "ID", "Name", glAccount.GLCategoryID);
                try
                {
                    GLAccount originalAccount = context.GLAccounts.Find(glAccount.Id);
                    context.Entry(originalAccount).State = EntityState.Detached;

                    string originalName = originalAccount.AccountName;
                    if (!glAccount.AccountName.ToLower().Equals(originalName.ToLower()))
                    {
                        if (!service.IsUniqueGLAccount(glAccount.AccountName))
                        {
                            AddError("Please select another name");
                            return View(glAccount);
                        }
                    }
                    glAccount.AccountCode = originalAccount.AccountCode;
                    glAccount.AccountBalance = originalAccount.AccountBalance;
                    glAccount.GLCategoryID = originalAccount.GLCategoryID;

                    context.Entry(glAccount).State = EntityState.Modified;
                    context.SaveChanges();


                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    AddError(ex.ToString());
                    return View(glAccount);
                }

            }
            ViewBag.BranchID = new SelectList(context.Branches, "ID", "Name", glAccount.BranchID);
            ViewBag.GlCategoryID = new SelectList(context.GLCategories, "ID", "Name", glAccount.GLCategoryID);
            AddError("Please enter valid data");
            return View(glAccount);
        }

        // GET: GlAccounts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ErrorView", "Error");
            }
            GLAccount glAccount = await context.GLAccounts.FindAsync(id);
            if (glAccount == null)
            {
                return RedirectToAction("ErrorView", "Error");
            }
            return View(glAccount);
        }

        // POST: GlAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            GLAccount glAccount = await context.GLAccounts.FindAsync(id);


            context.GLAccounts.Remove(glAccount);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public ActionResult GlAccountDeleteError()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }

        private void AddError(string error)
        {
            ModelState.AddModelError("", error);
        }
    }
}
