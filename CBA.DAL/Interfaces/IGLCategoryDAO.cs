using CBA.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.DAL.Interfaces
{
    public interface IGLCategoryDAO
    {
        //GLCategory
        GLCategory Save(GLCategory item);
        GLCategory RetrieveById(int id);
        GLCategory Delete(long id);
        GLCategory UpdateGLCategory(GLCategory userChanges);
        IEnumerable<GLCategory> GetAllGLCategories();
        GLCategory GetRoles(GLCategory user);
		//long CreateGlCategoryCode(GLCategory glCategory);
    }
}
