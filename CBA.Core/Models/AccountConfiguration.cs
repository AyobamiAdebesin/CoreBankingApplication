using CBA.Core.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Core.Models
{
    public class AccountConfiguration 
    {
        public int ID { get; set; }
        [Display(Name = "Business Status")]
        public bool IsBusinessOpen { get; set; }

        public DateTime FinancialDate { get; set; }

        [Display(Name = "Savings Credit Interest Rate")]
        [Range(0, 100)]
        [RegularExpression(@"^[.0-9]+$", ErrorMessage = "Invalid format for interest rate")]
        public double SavingsCreditInterestRate { get; set; }

        //[Display(Name = "Savings Minimum Balance")]
        //[Column(TypeName = "decimal(18,4)")]
       // [Range(0, (double)decimal.MaxValue)]
        [DataType(DataType.Currency)]
        [RegularExpression(@"^[.0-9]+$", ErrorMessage = "Invalid format for minimum balance")]
        public double SavingsMinimumBalance { get; set; }

        [Display(Name = "Select Interest Expense GL")]
        public int? SavingsInterestExpenseGlID { get; set; }
        public virtual GLAccount SavingsInterestExpenseGl { get; set; }

        [Display(Name = "Select Interest Payable GL")]
        public int? SavingsInterestPayableGlID { get; set; }
        public virtual GLAccount SavingsInterestPayableGl { get; set; }     //Liability


        //current account side
        [Display(Name = "Current Credit Interest Rate")]
        [Range(0, 100)]
        [RegularExpression(@"^[.0-9]+$", ErrorMessage = "Invalid format")]
        public double CurrentCreditInterestRate { get; set; }

        [Display(Name = "Current Minimum Balance")]
        [Range(0, (double)decimal.MaxValue)]
        [DataType(DataType.Currency)]
        [RegularExpression(@"^[.0-9]+$", ErrorMessage = "Invalid format")]
        public double CurrentMinimumBalance { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "COT")]
        [Range(0.00, 1000.00)]
        [RegularExpression(@"^[.0-9]+$", ErrorMessage = "Invalid format")]
        public double CurrentCot { get; set; }        //Commission On Turnover

        [Display(Name = "Select Interest Expense GL")]
        public int? CurrentInterestExpenseGlID { get; set; }
        public virtual GLAccount CurrentInterestExpenseGl { get; set; }

        [Display(Name = "Select COT Income GL")]
        public int? CurrentCotIncomeGlID { get; set; }
        public virtual GLAccount CurrentCotIncomeGl { get; set; }


        //Loan account side
        [Display(Name = "Loan Debit Interest Rate")]
        [Range(0, 100)]
        [RegularExpression(@"^[.0-9]+$", ErrorMessage = "Invalid format")]
        public double LoanDebitInterestRate { get; set; }

        [Display(Name = "Select Interest Income GL")]
        public int? LoanInterestIncomeGlID { get; set; }
        public virtual GLAccount LoanInterestIncomeGl { get; set; }

        [Display(Name = "Select Interest Expense GL")]
        public int? LoanInterestExpenseGLID { get; set; }
        public virtual GLAccount LoanInterestExpenseGl { get; set; }        //Expense: from where the loan is disbursed

        [Display(Name = "Select Interest Receivable GL")]
        public int? LoanInterestReceivableGlID { get; set; }
        public virtual GLAccount LoanInterestReceivableGl { get; set; }
    }
}
