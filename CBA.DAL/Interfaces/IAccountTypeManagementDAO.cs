using CBA.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.DAL.Interfaces
{
    public interface IAccountTypeManagementDAO
    {
        AccountTypeManagement GetFirst();
    }
}
