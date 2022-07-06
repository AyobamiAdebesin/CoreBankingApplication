using CBA.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CBA.Core.Enums.Enums;

namespace CBA.DAL.Interfaces
{
    public interface IGLAccountDAO
    {
        //GLAccount Save(GLAccount item);
        //GLAccount RetrieveById(int id);
        //GLAccount Delete(long id);
        //GLAccount UpdateGLAccount(GLAccount userChanges);
        //IEnumerable<GLAccount> GetAllGLAccounts();
        //GLAccount GetRoles(GLAccount user);
        //long CreateGlCategoryCode(GLAccount glAccount);

        List<GLAccount> GetAll();

        bool IsGlCategoryIsDeletable(int id);

        GLAccount GetLastGlIn(MainGLCategory mainCategory);

        bool AnyGlIn(MainGLCategory mainCategory);

        GLAccount GetByName(string Name);

        GLAccount GetById(int Id);

        List<GLAccount> GetAllTills();

        List<GLAccount> GetTillsWithoutTellers();

        List<GLAccount> GetAllAssetAccounts();

        List<GLAccount> GetAllIncomeAccounts();

        List<GLAccount> GetAllLiabilityAccounts();

        List<GLAccount> GetAllExpenseAccounts();

        List<GLAccount> GetByMainCategory(MainGLCategory mainCategory);

    }
}
