using CBA.Core.Models;
using CBA.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CBA.Core.Enums.Enums;

namespace CBA.DAL.Logic
{
    public class CustomerAccountLogic
    {
        private readonly ICustomerDAO customerDAO;
        private readonly IAccountTypeManagementDAO accountTypeManagementDAO;

        public CustomerAccountLogic(ICustomerDAO _customerDAO, IAccountTypeManagementDAO _accountTypeManagementDAO)
        {
            customerDAO = _customerDAO;
            accountTypeManagementDAO = _accountTypeManagementDAO;
        }

        public string CreateAccountNumber(AccountType accountType, CustomerAccount customerAccount)
        {
            //int customerId = customerAccount.CustomerID;

            int consumerId = customerAccount.CustomerID;
            Customer consumer = customerDAO.GetById(consumerId);

            if (String.IsNullOrWhiteSpace(consumer.CustomerLongID))
            {
                return "";
            }

            long longId = Convert.ToInt64(consumer.CustomerLongID);

            if (accountType == AccountType.Savings)
            {
                long accountNumber = AccountTypes.SavingsId + longId;
                return accountNumber.ToString();
            }

            if (accountType == AccountType.Current)
            {
                long accountNumber = AccountTypes.CurrentId + longId;
                return accountNumber.ToString();
            }
            if (accountType == AccountType.Loan)
            {
                long accountNumber = AccountTypes.LoanId + longId;
                return accountNumber.ToString();
            }

            return "";
        }

        public void ComputeFixedRepayment(CustomerAccount act, double nyears, double interestRate)
        {
            double totalAmountToRepay = 0;
            double nMonth = nyears * 12;
            double totalInterest = interestRate * nMonth * (double)act.LoanAmount;
            totalAmountToRepay = (double)totalInterest + (double)act.LoanAmount;
            act.LoanMonthlyRepay = (totalAmountToRepay / (12 * (double)nyears));
            act.LoanMonthlyPrincipalRepay = ((double)act.LoanAmount / nMonth);
            act.LoanMonthlyInterestRepay = (totalInterest / nMonth);
            act.LoanPrincipalRemaining = (double)act.LoanAmount;
        }

        public void ComputeReducingRepayment(CustomerAccount act, double nyears, double interestRate)
        {
            double x = 1 - Math.Pow((1 + interestRate), -(nyears * 12));
            act.LoanMonthlyRepay = ((double)act.LoanAmount * (double)interestRate) / (double)x;

            act.LoanPrincipalRemaining = (double)act.LoanAmount;
            act.LoanMonthlyInterestRepay = (double)interestRate * act.LoanPrincipalRemaining;
            act.LoanMonthlyPrincipalRepay = act.LoanMonthlyRepay - act.LoanMonthlyInterestRepay;
        }

        public bool CheckIfAccountBalanceIsEnough(CustomerAccount account, double amountToDebit)
        {
            var accountConfig = accountTypeManagementDAO.GetFirst();

            if (account.AccountType == AccountType.Savings)
            {
                if (account.AccountBalance >= amountToDebit + accountConfig.SavingsMinimumBalance)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (account.AccountType == AccountType.Current)
            {

                if (account.AccountBalance >= amountToDebit + accountConfig.CurrentMinimumBalance)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
    }


    public static class AccountTypes
    {
        public static long SavingsId = 10000000;
        public static long CurrentId = 20000000;
        public static long LoanId = 30000000;
    }
}

