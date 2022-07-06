using CBA.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CBA.Core.Enums.Enums;

namespace CBA.Core.Models
{
    public class CustomerAccount
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Account Name")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Enter Only Characters!")]
        public string AccountName { get; set; }


        [Display(Name = "Account Number")]
        [RegularExpression(@"^[0-9]*$")]
        public string AccountNumber { get; set; }

        [Display(Name = "Account Balance")]
        [DataType(DataType.Currency)]
        public double AccountBalance { get; set; }

        [Display(Name = "Branch Name")]
        public int BranchID { get; set; }

        [Display(Name = "Branch Name")]
        public virtual Branch Branch { get; set; }



        [Display(Name = "Account Status")]
        public AccountStatus AccountStatus { get; set; }

        [Required]
        [Display(Name = "Account Type")]
        public AccountType AccountType { get; set; }


        [Display(Name = "Date Created")]



        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }





        //Accounting Part

        [Display(Name = "Virtual days count since loan account creation")]
        public int? DaysCount { get; set; }      //counts the number of days (at EOD) from account creation, (esp for loan accounts)

        [Display(Name = "Savings Interest Accrued / Current COT Accrued / Loan Interest Accrued")]
        public double? dailyInterestAccrued { get; set; }
        [Range(0, 100, ErrorMessage = "Interest rate must be between 0 an 100")]
        [Display(Name = "Loan Interest Rate Per Month")]
        public double? LoanInterestRatePerMonth { get; set; }
        [Display(Name = "Savings Withdrawal Count")]
        public int? SavingsWithdrawalCount { get; set; }

        [Display(Name = "Current Lien")]
        public double? CurrentLien { get; set; }       //holding amount






        //Creating the Loan Account

        [Display(Name = "Loan Monthly Interest Repay")]
        [RegularExpression(@"^[.0-9]+$", ErrorMessage = "Invalid format")]
        public double LoanMonthlyInterestRepay { get; set; }

        [Display(Name = "Loan Monthly Repay")]
        [RegularExpression(@"^[.0-9]+$", ErrorMessage = "Invalid format")]
        public double LoanMonthlyRepay { get; set; }

        [Display(Name = "Loan Monthly Principal Repay")]
        [RegularExpression(@"^[.0-9]+$", ErrorMessage = "Invalid format")]
        public double LoanMonthlyPrincipalRepay { get; set; }

        [Display(Name = "Loan Principal Remaining")]
        [RegularExpression(@"^[.0-9]+$", ErrorMessage = "Invalid format")]
        public double LoanPrincipalRemaining { get; set; }

        [Display(Name = "Terms Of Loan")]
        public TermsOfLoan? TermsOfLoan { get; set; }

        /*[Required(ErrorMessage = "Number of years is required")]
        [Range(0.084, 1000.0)]
        [RegularExpression(@"^[.0-9]+$", ErrorMessage = "Invalid format")]
        [Display(Name = "Number of years")]
        public double? NumberOfYears { get; set; }*/

        [DataType(DataType.Currency)]
        [Display(Name = "Loan Amount")]
        [RegularExpression(@"^[.0-9]+$", ErrorMessage = "Invalid format")]
        public double LoanAmount { get; set; }

        [RegularExpression(@"^[0-9+]+$", ErrorMessage = "Please enter a valid Account Number")]
        [Display(Name = "Linked Account Number")]
        public int? LinkedAccountID { get; set; }
        public virtual CustomerAccount LinkedAccount { get; set; }
        public string NewCustomerId { get; set; }
        public string CustomerLongID { get; set; }
    }
}
