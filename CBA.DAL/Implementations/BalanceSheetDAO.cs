using CBA.Core.Models;
using CBA.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CBA.Core.Enums.Enums;

namespace CBA.DAL.Implementations
{
    public class BalanceSheetDAO : IBalanceSheetDAO
    {
        private readonly IGLAccountDAO gLAccountDAO;
        private readonly ICustomerAccountDAO customerAccountDAO;
        public BalanceSheetDAO(IGLAccountDAO _gLAccountDAO, ICustomerAccountDAO _customerAccountDAO)
        {
            gLAccountDAO = _gLAccountDAO;
            customerAccountDAO = _customerAccountDAO;
        }

        public List<GLAccount> GetAssetAccounts()
        {
            var allAssets = gLAccountDAO.GetByMainCategory(MainGLCategory.Asset);

            GLAccount loanAsset = new GLAccount();
            loanAsset.AccountName = "Loan Accounts";
            var loanAccounts = customerAccountDAO.GetByType(AccountType.Loan);
            foreach (var act in loanAccounts)
            {
                loanAsset.AccountBalance += act.AccountBalance;
            }
            allAssets.Add(loanAsset);
            return allAssets;
        }

        public List<GLAccount> GetCapitalAccounts()
        {
            var allCapitals = gLAccountDAO.GetByMainCategory(MainGLCategory.Capital);
            //adding the "Reserves" capitals--> Profit or loss expressed as (Income - Expense)
            GLAccount reserveCapital = new GLAccount();
            reserveCapital.AccountName = "Reserves";
            double incomeSum = gLAccountDAO.GetByMainCategory(MainGLCategory.Income).Sum(a => a.AccountBalance);
            double expenseSum = gLAccountDAO.GetByMainCategory(MainGLCategory.Expense).Sum(a => a.AccountBalance);
            reserveCapital.AccountBalance = incomeSum - expenseSum;
            allCapitals.Add(reserveCapital);

            return allCapitals;
        }

        public List<Liability> GetLiabilityAccounts()
        {
            var liability = gLAccountDAO.GetByMainCategory(MainGLCategory.Liability);

            var allLiabilityAccounts = new List<Liability>();

            foreach (var account in liability)
            {
                var model = new Liability();
                model.AccountName = account.AccountName;
                model.Amount = account.AccountBalance;

                allLiabilityAccounts.Add(model);

            }
            //adding customer's savings and loan accounts since they are liabilities to the bank           
            var savingsAccounts = customerAccountDAO.GetByType(AccountType.Savings);
            var savingsLiability = new Liability();
            savingsLiability.AccountName = "Savings Accounts";
            savingsLiability.Amount = savingsAccounts != null ? savingsAccounts.Sum(a => a.AccountBalance) : 0;

            var currentAccounts = customerAccountDAO.GetByType(AccountType.Current);
            var currentLiability = new Liability();
            currentLiability.AccountName = "Current Accounts";
            currentLiability.Amount = currentAccounts != null ? currentAccounts.Sum(a => a.AccountBalance) : 0;

            allLiabilityAccounts.Add(savingsLiability);
            allLiabilityAccounts.Add(currentLiability);
            return allLiabilityAccounts;
        }
    }
}
