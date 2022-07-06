using CBA.Core.Enums;
using CBA.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.DAL.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole,string>
    {
        //public AppDbContext()
        //{

        //}
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Login> Login { get; set; }
        public DbSet<GLCategory> GLCategories { get; set; }
        public DbSet<GLAccount> GLAccounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<AccountTypeManagement> AccountTypeManagements { get; set; }
        public DbSet<TillAccount> TillAccounts { get; set; }
        public DbSet<TellersTill> TellerTills { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<FineNames> FineNames { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }

        public DbSet<GLPosting> GLPostings { get; set; }
        public DbSet<TellerPosting> TellerPostings { get; set; }
        public DbSet<ExpenseIncomeEntry> ExpenseIncomeEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    FirstName = "Boluwatife",
                    LastName = "Oyetoro",
                    Email = "bolexcoded43@gmail.com",
                    Gender = Gender.Any,
                    Status = Status.Enabled,
                });

            modelBuilder.Entity<ApplicationRole>().HasData(
                new ApplicationRole
                {
                    Name = "Super Admin",
                    State = Status.Enabled,
                });

            //modelBuilder.Entity<UserRoles>().HasData(
            //    new UserRoles
            //    {
            //        RoleName = "Super Admin"
            //    });

            //modelBuilder.Entity<UserRole>().HasData(
            //    new UserRole
            //    {
            //        UserName = "bolexcoded43@gmail.com"
            //    });

        }


    }
}
