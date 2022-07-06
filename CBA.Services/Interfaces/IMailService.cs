 using CBA.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CBA.Core.Enums.Enums;

namespace CBA.Services.Settings
{
    public interface IMailService
    {
        string GeneratePassword();
        string GenerateUserName(string firstname, string secondname);
        Task SendEmailAsync(MailRequest mailRequest);
        string CreateAccountNumber(AccountType accountType, CustomerAccount customerAccount);
        void ComputeFixedRepayment(CustomerAccount act, double nyears, double interestRate);
        void ComputeReducingRepayment(CustomerAccount act, double nyears, double interestRate);
        bool CheckIfAccountBalanceIsEnough(CustomerAccount account, double amountToDebit);
        string GenerateCustomerLongId();
        bool IsConfigurationSet();
        bool CreditCustomerAccount(CustomerAccount customerAccount, double amount);
        bool DebitCustomerAccount(CustomerAccount customerAccount, double amount);
        bool CreditGl(GLAccount account, double amount);
        bool DebitGl(GLAccount account, double amount);
        void CreateTransaction(GLAccount account, double amount, TransactionType trnType);
        void CreateTransaction(CustomerAccount account, double amount, TransactionType trnType);
        bool IsUniqueGLAccount(string glAccountName);
        long GenerateGLAccountNumber(MainGLCategory glMainCategory);
        bool IsUniqueGLAcategory(string glAccountName);
        long CreateGlCategoryCode(GLCategory glCategory);
        Task<List<ApplicationUser>> GetAllTellers();
        string PostTeller(CustomerAccount account, GLAccount till, double amt, TellerPostingType pType);
        List<Transaction> GetTrialBalanceTransactions(DateTime startDate, DateTime endDate);
        List<GLAccount> GetAssetAccounts();
        List<GLAccount> GetCapitalAccounts();
        List<Liability> GetLiabilityAccounts();
        List<ExpenseIncomeEntry> GetAllExpenseIncomeEntries();
        List<ExpenseIncomeEntry> GetEntries();
        List<ExpenseIncomeEntry> GetEntriesDate(DateTime startDate, DateTime endDate);
    }
}
