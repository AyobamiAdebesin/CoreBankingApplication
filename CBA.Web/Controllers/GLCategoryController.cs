using Microsoft.AspNetCore.Mvc;
using CBA.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CBA.DAL;
using CBA.Core.Models;
using CBA.Services.Settings;
using CBA.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace CBA.Web.Controllers
{
    public class GLCategoryController : Controller
    {
        private readonly AppDbContext context;
        private readonly IMailService service;
        private readonly IGLAccountDAO accountDAO;

        public GLCategoryController(AppDbContext context, IMailService _service, IGLAccountDAO _accountDAO)
        {
            this.context = context;
            service = _service;
            accountDAO = _accountDAO;
        }

        public async Task<ActionResult> Index()
        {
            return View(await context.GLCategories.ToListAsync());
        }

        // GET: GlCategories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ErrorView", "Error");
            }
            GLCategory glCategory = await context.GLCategories.FindAsync(id);
            if (glCategory == null)
            {
                return RedirectToAction("ErrorView", "Error");
            }
            return View(glCategory);
        }

        // GET: GlCategories/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(GLCategory glCategory)
        {

            if (ModelState.IsValid)
            {
                if (!service.IsUniqueGLAcategory(glCategory.CategoryName))
                {
                    AddError("The GL Category Name already exists");
                    return View(glCategory);
                }

                glCategory.CategoryCode = service.CreateGlCategoryCode(glCategory);
                context.GLCategories.Add(glCategory);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(glCategory);
        }

        // GET: GlCategories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ErrorView", "Error");
            }
            GLCategory glCategory = await context.GLCategories.FindAsync(id);
            if (glCategory == null)
            {
                return RedirectToAction("ErrorView", "Error");
            }
            return View(glCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(GLCategory glCategory)
        {
            if (ModelState.IsValid)
            {
                if (!service.IsUniqueGLAcategory(glCategory.CategoryName))
                    context.Entry(glCategory).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(glCategory);
        }

        // GET: GlCategories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ErrorView", "Error");

            }
            GLCategory glCategory = await context.GLCategories.FindAsync(id);
            if (glCategory == null)
            {
                return RedirectToAction("ErrorView", "Error");
            }
            return View(glCategory);
        }

        // POST: GlCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            GLCategory glCategory = await context.GLCategories.FindAsync(id);


            var allGlAccount = context.GLAccounts.ToList();

            foreach (var acct in allGlAccount)
            {
                if (acct.GLCategoryID == id)
                {
                    AddError("GL Categories Cannot be deleted because it is linked to a GL Account");
                    return View("CategoryDeleteError");
                }

            }

            var tellers = await service.GetAllTellers();
            var gglAccountTill = context.GLAccounts.Where(c => c.AccountName.ToLower().Contains("till")).ToList();

            context.GLCategories.Remove(glCategory);
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
        private void AddError(string error)
        {
            ModelState.AddModelError("", error);
        }
    }
}