using CBA.Core.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MimeKit;
using CBA.DAL.Context;
using CBA.DAL.Interfaces;
using System.Security.Cryptography;
using static CBA.Core.Enums.Enums;
using CBA.Core.Enums;

namespace CBA.Services.Settings
{
    public class MailService : IMailService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly AppDbContext context;
        private readonly MailSettings _mailSettings;
        private readonly ICustomerDAO customerDAO;
        private readonly IGLAccountDAO gLAccountDAO;
        private readonly IBalanceSheetDAO balanceSheetDAO;
        private readonly IAccountTypeManagementDAO accountTypeManagementDAO;
        DateTime yesterday;

        public MailService(IOptions<MailSettings> mailSettings, AppDbContext context, ICustomerDAO _customerDAO, IAccountTypeManagementDAO _accountTypeManagementDAO, IGLAccountDAO _gLAccountDAO, IGLCategoryDAO _gLCategoryDAO, UserManager<ApplicationUser> _userManager, RoleManager<ApplicationRole> _roleManager, IBalanceSheetDAO _balanceSheetDAO)
        {
            this.context = context;
            userManager = _userManager;
            roleManager = _roleManager;
            _mailSettings = mailSettings.Value;
            customerDAO = _customerDAO;
            accountTypeManagementDAO = _accountTypeManagementDAO;
            gLAccountDAO = _gLAccountDAO;
            gLAccountDAO = _gLAccountDAO;
            balanceSheetDAO = _balanceSheetDAO;
            //yesterday = context.AccountTypeManagements.First().FinancialDate.AddDays(-1);

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

        public string CreateAccountNumber(AccountType accounttype, CustomerAccount customerAccount)
        {
            Random rd = new Random();
            long rand_num = rd.Next(100, 999);
            CustomerAccount customerId = customerAccount;
            string stringId = customerAccount.NewCustomerId;
            if (accounttype == AccountType.Savings)
            {
                string accountNumber = AccountTypes.SavingsId + stringId + rand_num.ToString();
                return accountNumber.ToString();
            }

            if (accounttype == AccountType.Current)
            {
                string accountNumber = AccountTypes.CurrentId + stringId + rand_num.ToString();
                return accountNumber.ToString();
            }
            if (accounttype == AccountType.Loan)
            {
                string accountNumber = AccountTypes.LoanId + stringId + rand_num.ToString();
                return accountNumber.ToString();
            }

            return "";
        }


        public long CreateGlCategoryCode(GLCategory glCategory)
        {
            long newGlCode = 10;
            MainGLCategory mainGl = glCategory.MainGLCategory;

            var categoryList = context.GLCategories.ToList().OrderByDescending(c => c.Id);

            if (categoryList.Any())
            {
                var lastGlCode = categoryList.First().CategoryCode;
                var stringLastGlCode = lastGlCode.ToString();
                /*Get the main GlCode*/
                int endIndex = stringLastGlCode.Length - 3;
                string mainGlCode = stringLastGlCode.Substring(3, endIndex);

                lastGlCode = Convert.ToInt64(mainGlCode);

                newGlCode = lastGlCode + 10;

            }

            string stringGlCode = newGlCode.ToString();
            long finalGlCode;

            switch (mainGl)
            {
                case MainGLCategory.Asset:
                    finalGlCode = Convert.ToInt64(MainCategoryCodes.AssetCode + stringGlCode);
                    break;
                case MainGLCategory.Capital:
                    finalGlCode = Convert.ToInt64(MainCategoryCodes.CapitalCode + stringGlCode);
                    break;
                case MainGLCategory.Expense:
                    finalGlCode = Convert.ToInt64(MainCategoryCodes.ExpenseCode + stringGlCode);
                    break;
                case MainGLCategory.Income:
                    finalGlCode = Convert.ToInt64(MainCategoryCodes.IncomeCode + stringGlCode);
                    break;
                case MainGLCategory.Liability:
                    finalGlCode = Convert.ToInt64(MainCategoryCodes.LiabilityCode + stringGlCode);
                    break;
                default:
                    finalGlCode = 000;
                    break;
            }

            return finalGlCode;
        }


        public void CreateTransaction(GLAccount account, double amount, TransactionType trnType)
        {
            //Record this transaction for Trial Balance generation
            Transaction transaction = new Transaction();
            transaction.Amount = amount;
            transaction.Date = DateTime.Now;
            transaction.AccountName = account.AccountName;
            transaction.SubCategory = account.GLCategory.CategoryName;
            transaction.MainCategory = account.GLCategory.MainGLCategory;
            transaction.TransactionType = trnType;

            context.Transactions.Add(transaction);
            context.SaveChanges();
        }

        public void CreateTransaction(CustomerAccount account, double amount, TransactionType trnType)
        {
            if (account.AccountType == AccountType.Loan)
            {
                //Record this transaction for Trial Balance generation
                Transaction transaction = new Transaction();
                transaction.Amount = amount;
                transaction.Date = DateTime.Now;
                transaction.AccountName = account.AccountName;
                transaction.SubCategory = "Customer's Loan Account";
                transaction.MainCategory = MainGLCategory.Asset;
                transaction.TransactionType = trnType;

                context.Transactions.Add(transaction);
                context.SaveChanges();
            }
            else
            {
                //Record this transaction for Trial Balance generation
                Transaction transaction = new Transaction();
                transaction.Amount = amount;
                transaction.Date = DateTime.Now;
                transaction.AccountName = account.AccountName;
                transaction.SubCategory = "Customer Account";
                transaction.MainCategory = MainGLCategory.Liability;
                transaction.TransactionType = trnType;

                context.Transactions.Add(transaction);
                context.SaveChanges();
            }
        }

        public bool CreditCustomerAccount(CustomerAccount customerAccount, double amount)
        {
            try
            {
                if (customerAccount.AccountType == AccountType.Loan)
                {
                    customerAccount.AccountBalance -= amount;    //Because a Loan Account is an Asset Account
                }
                else
                {
                    customerAccount.AccountBalance += amount;     //Because a Savings or Current Account is a Liability Account
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CreditGl(GLAccount account, double amount)
        {
            try
            {
                switch (account.GLCategory.MainGLCategory)
                {
                    case MainGLCategory.Asset:
                        account.AccountBalance -= amount;
                        break;
                    case MainGLCategory.Capital:
                        account.AccountBalance += amount;
                        break;
                    case MainGLCategory.Expense:
                        account.AccountBalance -= amount;
                        break;
                    case MainGLCategory.Income:
                        account.AccountBalance += amount;
                        break;
                    case MainGLCategory.Liability:
                        account.AccountBalance += amount;
                        break;
                    default:
                        break;
                }//end switch

                //frLogic.CreateTransaction(account, amount, TransactionType.Credit);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DebitCustomerAccount(CustomerAccount customerAccount, double amount)
        {
            try
            {
                if (customerAccount.AccountType == AccountType.Loan)
                {
                    customerAccount.AccountBalance += amount;    //Because a Loan Account is an Asset Account
                }
                else
                {
                    customerAccount.AccountBalance -= amount;     //Because a Savings or Current Account is a Liability Account
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DebitGl(GLAccount account, double amount)
        {
            try
            {
                switch (account.GLCategory.MainGLCategory)
                {
                    case MainGLCategory.Asset:
                        account.AccountBalance += amount;
                        break;
                    case MainGLCategory.Capital:
                        account.AccountBalance -= amount;
                        break;
                    case MainGLCategory.Expense:
                        account.AccountBalance += amount;
                        break;
                    case MainGLCategory.Income:
                        account.AccountBalance -= amount;
                        break;
                    case MainGLCategory.Liability:
                        account.AccountBalance -= amount;
                        break;
                    default:
                        break;
                }//end switch
                //frLogic.CreateTransaction(account, amount, TransactionType.Debit);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string GenerateCustomerLongId()
        {
            string id = "00000001";

            var customers = customerDAO.GetAll().OrderByDescending(c => c.ID);

            if (customers.Any())
            {
                long newId = Convert.ToInt64(customers.First().CustomerLongID);
                id = (newId + 1).ToString("D8");
            }

            return id;
        }

        public long GenerateGLAccountNumber(MainGLCategory glMainCategory)
        {
            long code = 0;

            //get the last account number in this category
            if (gLAccountDAO.AnyGlIn(glMainCategory))
            {
                var lastAct = gLAccountDAO.GetLastGlIn(glMainCategory);
                code = lastAct.AccountCode + 1;
            }

            else                //this is going to be the first act in this category
            {
                switch (glMainCategory)     //these codes are assumed at author's descretion
                {
                    case MainGLCategory.Asset:
                        code = 10001020;
                        break;
                    case MainGLCategory.Capital:
                        code = 30001020;
                        break;
                    case MainGLCategory.Expense:
                        code = 50001020;
                        break;
                    case MainGLCategory.Income:
                        code = 40001020;
                        break;
                    case MainGLCategory.Liability:
                        code = 20001020;
                        break;
                    default:
                        break;
                }
            }//end if

            return code;
        }

        public string GeneratePassword()
        {
            using RNGCryptoServiceProvider cryptRNGen = new();
            byte[] tokenBuffer = new byte[12];
            cryptRNGen.GetBytes(tokenBuffer);
            return Convert.ToBase64String(tokenBuffer);
        }

        public string GenerateUserName(string firstname, string secondname)
        {
            //Store the second name attach substring of first name.
            var possibleUsername = string.Format("{0}_{1}", secondname, firstname.Substring(0, 1));
            return possibleUsername;
        }

        public List<ExpenseIncomeEntry> GetAllExpenseIncomeEntries()
        {
            return context.ExpenseIncomeEntries.ToList();
        }

        public async Task<List<ApplicationUser>> GetAllTellers()
        {
            var users = userManager.Users;

            List<ApplicationUser> tellers = new List<ApplicationUser>();

            foreach (var user in users)
            {
                var isInTellerRole = await userManager.IsInRoleAsync(user, "teller");
                if (isInTellerRole)
                {
                    tellers.Add(user);
                }
            }

            return (tellers);
        }

        public List<GLAccount> GetAssetAccounts()
        {
            return balanceSheetDAO.GetAssetAccounts();
        }

        public List<GLAccount> GetCapitalAccounts()
        {
            return balanceSheetDAO.GetCapitalAccounts();
        }

        public List<ExpenseIncomeEntry> GetEntries()
        {
            var result = new List<ExpenseIncomeEntry>();
            var allEntries = GetAllExpenseIncomeEntries();
            foreach (var item in allEntries)
            {
                if (item.Date.Date == yesterday.Date)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public List<ExpenseIncomeEntry> GetEntriesDate(DateTime startDate, DateTime endDate)
        {
            var result = new List<ExpenseIncomeEntry>();
            if (startDate < endDate)
            {
                //gets all entries(with their balances) for the start and the end dates. eg: Current exp gl (bal: 3k) on Jan5, (bal 8k) on Jan 9. etc. A GL cant exist more than 2 times (for start and end dates).
                var allEntries = GetAllExpenseIncomeEntries();
                foreach (var item in allEntries)
                {
                    if (item.Date.Date == startDate || item.Date.Date == endDate)
                    {
                        result.Add(item);
                    }
                }

            }
            return result.OrderByDescending(e => e.Date).ToList();  //making entries on endDate to come before those of startDate so that the difference in Account balance between the two days could be easily calculated
        }

        public List<Liability> GetLiabilityAccounts()
        {
            return balanceSheetDAO.GetLiabilityAccounts();
        }

        public List<Transaction> GetTrialBalanceTransactions(DateTime startDate, DateTime endDate)
        {
            var result = new List<Transaction>();
            if (startDate < endDate)
            {
                var allTransactions = context.Transactions.ToList();
                foreach (var item in allTransactions)
                {
                    if (item.Date.Date >= startDate && item.Date.Date <= endDate)
                    {
                        result.Add(item);
                    }
                }

            }
            return result;
        }

        public bool IsConfigurationSet()
        {
            var config = accountTypeManagementDAO.GetFirst();
            if (config.SavingsInterestExpenseGl == null || config.SavingsInterestPayableGl == null || config.CurrentInterestExpenseGl == null || config.COTIncomeGl == null || config.LoanInterestIncomeGl == null || config.LoanInterestReceivableGl == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsUniqueGLAcategory(string glcatName)
        {
            if (gLAccountDAO.GetByName(glcatName) == null)
            {
                return true;
            }

            return false;
        }

        public bool IsUniqueGLAccount(string glAccountName)
        {

            if (gLAccountDAO.GetByName(glAccountName) == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string PostTeller(CustomerAccount account, GLAccount till, double amt, TellerPostingType pType)
        {
            string output = "";
            switch (pType)
            {
                case TellerPostingType.Deposit:
                    CreditCustomerAccount(account, amt);
                    DebitGl(till, amt);

                    output = "success";
                    break;
                //break;
                case TellerPostingType.Withdrawal:
                    //Transfer the money from the user's till and reflect the changes in the customer account balance
                    //check withdrawal limit

                    var config = accountTypeManagementDAO.GetFirst();
                    //till = user.TillAccount;
                    if (account.AccountType == AccountType.Savings)
                    {
                        if (account.AccountBalance >= config.SavingsMinimumBalance + amt)
                        {
                            if (till.AccountBalance >= amt)
                            {
                                CreditGl(till, amt);
                                DebitCustomerAccount(account, amt);

                                output = "success";
                                account.SavingsWithdrawalCount++;
                            }
                            else
                            {
                                output = "Insufficient fund in the Till account";
                            }
                        }
                        else
                        {
                            output = "insufficient Balance in Customer's account, cannot withdraw!";
                        }

                    }//end if savings


                    else if (account.AccountType == AccountType.Current)
                    {
                        if (account.AccountBalance >= config.CurrentMinimumBalance + amt)
                        {

                            if (till.AccountBalance >= amt)
                            {
                                CreditGl(till, amt);
                                DebitCustomerAccount(account, amt);

                                output = "success";
                                //double x = (amt + account.CurrentLien) / 1000;
                                double x = (amt) / 1000;
                                double charge = (int)x * config.COT;
                                account.dailyInterestAccrued += charge;
                                //account.CurrentLien = (x - (int)x) * 1000;
                            }
                            else
                            {
                                output = "Insufficient fund in the Till account";
                            }
                        }
                        else
                        {
                            output = "insufficient Balance in Customer's account, cannot withdraw!";
                        }

                    }
                    else //for loan
                    {
                        output = "Please select a valid account";
                    }
                    break;
                //break;
                default:
                    break;
            }//end switch
            return output;
        }

        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            ///smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }

        List<Liability> IMailService.GetLiabilityAccounts()
        {
            throw new NotImplementedException();
        }
    }

    public static class AccountTypes
    {
        public static long SavingsId = 10000000;
        public static long CurrentId = 20000000;
        public static long LoanId = 30000000;
    }
    public class MainCategoryCodes
    {
        public static string AssetCode = "100";
        public static string LiabilityCode = "200";
        public static string CapitalCode = "300";
        public static string IncomeCode = "400";
        public static string ExpenseCode = "500";
    }
}
