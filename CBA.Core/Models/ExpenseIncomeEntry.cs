using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CBA.Core.Enums.Enums;

namespace CBA.Core.Models
{
    public class ExpenseIncomeEntry
    {
        public int ID { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string AccountName { get; set; }
        public PandLType EntryType { get; set; }
    }
}
