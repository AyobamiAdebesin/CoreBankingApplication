using CBA.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBA.Core.Models;
using CBA.DAL.Context;

namespace CBA.DAL.Implementations
{
    public class GLCategoryDAO : IGLCategoryDAO
    {
        private readonly AppDbContext context;
       

        public GLCategoryDAO(AppDbContext context)
        {
            this.context = context;
        }

        public GLCategory Delete(long id)
        {
            GLCategory gLCategory = context.GLCategories.Find(id);
            if (gLCategory != null)
            {
                context.GLCategories.Remove(gLCategory);
                context.SaveChanges();
            }
            return gLCategory;
        }

        public IEnumerable<GLCategory> GetAllGLCategories()
        {
            var gLCategories = context.GLCategories.ToList();
            return gLCategories;
        }

        public GLCategory GetRoles(GLCategory user)
        {
            throw new NotImplementedException();
        }

        public GLCategory RetrieveById(int id)
        {
            GLCategory gLCategory = context.GLCategories.Find(id);
            return gLCategory;
        }

        public GLCategory Save(GLCategory item)
        {
            context.GLCategories.Add(item);
            context.SaveChanges();
            return item;
        }

        public GLCategory UpdateGLCategory(GLCategory userChanges)
        {
            var gLCategory = context.GLCategories.Attach(userChanges);
            gLCategory.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return userChanges;
        }



    }
}
