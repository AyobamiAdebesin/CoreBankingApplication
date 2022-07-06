using CBA.Core.Enums;
using CBA.Core.Models;
using CBA.DAL.Context;
using CBA.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CBA.Core.Enums.Enums;

namespace CBA.DAL.Implementations
{
    public class GLAccountDAO : IGLAccountDAO
    {
        private readonly AppDbContext context;

        public GLAccountDAO(AppDbContext context)
        {
            this.context = context;
        }
        //public GLAccount Delete(long id)
        //{
        //    GLAccount gLAccount = context.GLAccounts.Find(id);
        //    if (gLAccount != null)
        //    {
        //        context.GLAccounts.Remove(gLAccount);
        //        context.SaveChanges();
        //    }
        //    return gLAccount;
        //}

        //public GLAccount RetrieveById(int id)
        //{
        //    GLAccount gLAccount = context.GLAccounts.Find(id);
        //    return gLAccount;
        //}

        //public GLAccount Save(GLAccount gLAccount)
        //{
        //    context.GLAccounts.Add(gLAccount);
        //    context.SaveChanges();
        //    return gLAccount;
        //}

        //public GLAccount GetRoles(GLAccount gLAccount)
        //{
        //    throw new NotImplementedException();
        //}

        //public GLAccount UpdateGLAccount(GLAccount gLAccountsChanges)
        //{
        //    var gLAccount = context.GLAccounts.Attach(gLAccountsChanges);
        //    gLAccount.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //    context.SaveChanges();
        //    return gLAccountsChanges;
        //}

        //public IEnumerable<GLAccount> GetAllGLAccounts()
        //{
        //    var gLAccounts = context.GLAccounts.ToList();
        //    return gLAccounts;
        //}

        //public long CreateGlCategoryCode(GLAccount glAccount)
        //{
        //    long newGlCode = 10;
        //    Categories mainGl = glAccount.Categories;

        //    var categoryList = context.GLAccounts.ToList().OrderByDescending(c => c.Id);

        //    if (categoryList.Any())
        //    {
        //        var lastGlCode = categoryList.First().AccountCode;
        //        var stringLastGlCode = lastGlCode.ToString();
        //        //Get the main GlCode

        //        int endIndex = stringLastGlCode.Length - 3;
        //        string mainGlCode = stringLastGlCode.Substring(3, endIndex);

        //        lastGlCode = Convert.ToInt64(mainGlCode);

        //        newGlCode = lastGlCode + 10;

        //    }

        //    string stringGlCode = newGlCode.ToString();
        //    long finalGlCode;

        //    switch (mainGl)
        //    {
        //        case Categories.Asset:
        //            finalGlCode = Convert.ToInt64(MainCategoryCodes.AssetCode + stringGlCode);
        //            break;
        //        case Categories.Capital:
        //            finalGlCode = Convert.ToInt64(MainCategoryCodes.CapitalCode + stringGlCode);
        //            break;
        //        case Categories.Expense:
        //            finalGlCode = Convert.ToInt64(MainCategoryCodes.ExpenseCode + stringGlCode);
        //            break;
        //        case Categories.Income:
        //            finalGlCode = Convert.ToInt64(MainCategoryCodes.IncomeCode + stringGlCode);
        //            break;
        //        case Categories.Liability:
        //            finalGlCode = Convert.ToInt64(MainCategoryCodes.LiabilityCode + stringGlCode);
        //            break;
        //        default:
        //            finalGlCode = 000;
        //            break;
        //    }

        //    return finalGlCode;
        //}



        //public class MainCategoryCodes
        //{
        //    public static string AssetCode = "100";
        //    public static string LiabilityCode = "200";
        //    public static string CapitalCode = "300";
        //    public static string IncomeCode = "400";
        //    public static string ExpenseCode = "500";
        //}


        public bool AnyGlIn(Enums.MainGLCategory mainCategory)
        {
            return context.GLAccounts.Any(gl => gl.GLCategory.MainGLCategory == mainCategory);
        }

       

        public List<GLAccount> GetAll()
        {
            var glAccountList = context.GLAccounts.ToList();
            return glAccountList;
        }

        public List<GLAccount> GetAllAssetAccounts()
        {
            var output = context.GLAccounts.Where(c => c.GLCategory.MainGLCategory == MainGLCategory.Asset).ToList();

            return output;
        }

        public List<GLAccount> GetAllExpenseAccounts()
        {
            var output = context.GLAccounts.Where(c => c.GLCategory.MainGLCategory == MainGLCategory.Expense).ToList();

            return output;
        }

        public List<GLAccount> GetAllIncomeAccounts()
        {
            var output = context.GLAccounts.Where(c => c.GLCategory.MainGLCategory == MainGLCategory.Income).ToList();

            return output;
        }

        public List<GLAccount> GetAllLiabilityAccounts()
        {
            var output = context.GLAccounts.Where(c => c.GLCategory.MainGLCategory == MainGLCategory.Liability).ToList();

            return output;
        }

        public List<GLAccount> GetAllTills()
        {
            var tills = context.GLAccounts.Where(c => c.AccountName.ToLower().Contains("till")).ToList();

            return tills;
        }

        public GLAccount GetById(int Id)
        {
            var glAccount = context.GLAccounts.SingleOrDefault(c => c.Id == Id);

            return glAccount;
        }

        public List<GLAccount> GetByMainCategory(Enums.MainGLCategory mainCategory)
        {
            return context.GLAccounts.Where(a => a.GLCategory.MainGLCategory == mainCategory).ToList();

        }

       
        public GLAccount GetByName(string Name)
        {
            var glAccountByName = context.GLAccounts.SingleOrDefault(c => c.AccountName == Name);

            return glAccountByName;
        }

        public GLAccount GetLastGlIn(Enums.MainGLCategory mainCategory)
        {
            return context.GLAccounts.Where(g => g.GLCategory.MainGLCategory == mainCategory).OrderByDescending(a => a.Id).First();
        }

       
        public List<GLAccount> GetTillsWithoutTellers()
        {
            var output = new List<GLAccount>();
            List<GLAccount> allTills = GetAllTills();
            var tillAccount = context.TillAccounts.ToList();

            foreach (var till in allTills)
            {
                if (!tillAccount.Any(c => c.GlAccountID == till.Id))
                {
                    output.Add(till);
                }
            }

            return output;
        }

        public bool IsGlCategoryIsDeletable(int id)
        {
            return GetAll().Any(c => c.GLCategoryID == id);
        }
    }
}
