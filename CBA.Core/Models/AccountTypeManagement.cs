using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Core.Models
{
    public class AccountTypeManagement
    {
        public int ID { get; set; }


        //For Current Accounts

        [Display(Name = "Credit Interest Rate for Current")]
        [Range(0, 100)]
        [RegularExpression(@"^[.0-9]+$", ErrorMessage = "Invalid format")]
        public double CurrentCreditInterestRate { get; set; }

        //[Display(Name = "Minimum Balance for Current")]
        //[Range(0, (double)decimal.MaxValue)]
        //[DataType(DataType.Currency)]
        //[RegularExpression(@"^[.0-9]+$", ErrorMessage = "Invalid format")]
        public double CurrentMinimumBalance { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "COT")]
        [Range(0.00, 1000.00)]
        [RegularExpression(@"^[.0-9]+$", ErrorMessage = "Invalid format")]
        public double COT { get; set; }

        [Display(Name = "Select Interest Expense GL")]
        public int? CurrentInterestExpenseGlID { get; set; }
        public virtual GLAccount CurrentInterestExpenseGl { get; set; }

        [Display(Name = "Select COT Income GL")]
        public int? COTIncomeGlID { get; set; }
        public virtual GLAccount COTIncomeGl { get; set; }






        //For Savings Accounts


        [Display(Name = "Credit Interest Rate for Savings")]
        [Range(0, 100)]
        [RegularExpression(@"^[.0-9]+$", ErrorMessage = "Invalid format for interest rate")]
        public double SavingsCreditInterestRate { get; set; }

        [Display(Name = "Minimum Balance for Savings")]
        [Range(0, (double)decimal.MaxValue)]
        [DataType(DataType.Currency)]
        [RegularExpression(@"^[.0-9]+$", ErrorMessage = "Invalid format for minimum balance")]
        public double SavingsMinimumBalance { get; set; }




        [Display(Name = "Select the Savings Interest Expense GL")]
        public int? SavingsInterestExpenseGlID { get; set; }
        public virtual GLAccount SavingsInterestExpenseGl { get; set; }



        [Display(Name = "Select Interest Payable GL for Savings")]
        public int? SavingsInterestPayableGlID { get; set; }
        public virtual GLAccount SavingsInterestPayableGl { get; set; }





        //For Loan Account Types

        [Display(Name = "The Debit Interest Rate for Loan")]
        [Range(0, 100)]
        [RegularExpression(@"^[.0-9]+$", ErrorMessage = "Invalid format")]
        public double LoanDebitInterestRate { get; set; }

        [Display(Name = "Choose the Interest Income GL")]
        public int? LoanInterestIncomeGlID { get; set; }
        public virtual GLAccount LoanInterestIncomeGl { get; set; }


        [Display(Name = "Choose the Interest Receivable GL")]
        public int? LoanInterestReceivableGlID { get; set; }
        public virtual GLAccount LoanInterestReceivableGl { get; set; }


        [Display(Name = "Business Status")]
        public bool IsOpened { get; set; }

        public DateTime FinancialDate { get; set; }
    }
}
