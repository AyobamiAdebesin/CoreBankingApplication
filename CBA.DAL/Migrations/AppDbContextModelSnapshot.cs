﻿// <auto-generated />
using System;
using CBA.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CBA.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CBA.Core.Models.AccountTypeManagement", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<double>("COT")
                        .HasColumnType("float");

                    b.Property<int?>("COTIncomeGlID")
                        .HasColumnType("int");

                    b.Property<double>("CurrentCreditInterestRate")
                        .HasColumnType("float");

                    b.Property<int?>("CurrentInterestExpenseGlID")
                        .HasColumnType("int");

                    b.Property<double>("CurrentMinimumBalance")
                        .HasColumnType("float");

                    b.Property<DateTime>("FinancialDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsOpened")
                        .HasColumnType("bit");

                    b.Property<double>("LoanDebitInterestRate")
                        .HasColumnType("float");

                    b.Property<int?>("LoanInterestIncomeGlID")
                        .HasColumnType("int");

                    b.Property<int?>("LoanInterestReceivableGlID")
                        .HasColumnType("int");

                    b.Property<double>("SavingsCreditInterestRate")
                        .HasColumnType("float");

                    b.Property<int?>("SavingsInterestExpenseGlID")
                        .HasColumnType("int");

                    b.Property<int?>("SavingsInterestPayableGlID")
                        .HasColumnType("int");

                    b.Property<double>("SavingsMinimumBalance")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("COTIncomeGlID");

                    b.HasIndex("CurrentInterestExpenseGlID");

                    b.HasIndex("LoanInterestIncomeGlID");

                    b.HasIndex("LoanInterestReceivableGlID");

                    b.HasIndex("SavingsInterestExpenseGlID");

                    b.HasIndex("SavingsInterestPayableGlID");

                    b.ToTable("AccountTypeManagements");
                });

            modelBuilder.Entity("CBA.Core.Models.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int?>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "44211155-60f0-45ef-a036-16cd8a0a9aec",
                            ConcurrencyStamp = "5ced3699-cd5f-4b37-89ed-78bde7faa1b0",
                            Name = "Super Admin",
                            State = 0
                        });
                });

            modelBuilder.Entity("CBA.Core.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "711e67ed-1877-4afe-ac64-229457f3de17",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e2b38678-694b-4318-842a-be58b34b6910",
                            Email = "bolexcoded43@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Boluwatife",
                            Gender = 0,
                            LastName = "Oyetoro",
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "eedc5852-78d5-4594-bc96-69f512134e01",
                            Status = 0,
                            TwoFactorEnabled = false
                        });
                });

            modelBuilder.Entity("CBA.Core.Models.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<long>("SortCode")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("CBA.Core.Models.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CustomerInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerLongID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.HasKey("ID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CBA.Core.Models.CustomerAccount", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<double>("AccountBalance")
                        .HasColumnType("float");

                    b.Property<string>("AccountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AccountStatus")
                        .HasColumnType("int");

                    b.Property<int>("AccountType")
                        .HasColumnType("int");

                    b.Property<int>("BranchID")
                        .HasColumnType("int");

                    b.Property<double?>("CurrentLien")
                        .HasColumnType("float");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<string>("CustomerLongID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DaysCount")
                        .HasColumnType("int");

                    b.Property<int?>("LinkedAccountID")
                        .HasColumnType("int");

                    b.Property<double>("LoanAmount")
                        .HasColumnType("float");

                    b.Property<double?>("LoanInterestRatePerMonth")
                        .HasColumnType("float");

                    b.Property<double>("LoanMonthlyInterestRepay")
                        .HasColumnType("float");

                    b.Property<double>("LoanMonthlyPrincipalRepay")
                        .HasColumnType("float");

                    b.Property<double>("LoanMonthlyRepay")
                        .HasColumnType("float");

                    b.Property<double>("LoanPrincipalRemaining")
                        .HasColumnType("float");

                    b.Property<string>("NewCustomerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SavingsWithdrawalCount")
                        .HasColumnType("int");

                    b.Property<int?>("TermsOfLoan")
                        .HasColumnType("int");

                    b.Property<double?>("dailyInterestAccrued")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("BranchID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("LinkedAccountID");

                    b.ToTable("CustomerAccounts");
                });

            modelBuilder.Entity("CBA.Core.Models.ExpenseIncomeEntry", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("AccountName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EntryType")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("ExpenseIncomeEntries");
                });

            modelBuilder.Entity("CBA.Core.Models.FineNames", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FineNames");
                });

            modelBuilder.Entity("CBA.Core.Models.GLAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("AccountBalance")
                        .HasColumnType("float");

                    b.Property<long>("AccountCode")
                        .HasColumnType("bigint");

                    b.Property<string>("AccountName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BranchID")
                        .HasColumnType("int");

                    b.Property<int>("Categories")
                        .HasColumnType("int");

                    b.Property<int>("GLCategoryID")
                        .HasColumnType("int");

                    b.Property<int?>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BranchID");

                    b.HasIndex("GLCategoryID");

                    b.ToTable("GLAccounts");
                });

            modelBuilder.Entity("CBA.Core.Models.GLCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Categories")
                        .HasColumnType("int");

                    b.Property<long>("CategoryCode")
                        .HasColumnType("bigint");

                    b.Property<string>("CategoryDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MainGLCategory")
                        .HasColumnType("int");

                    b.Property<int?>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("GLCategories");
                });

            modelBuilder.Entity("CBA.Core.Models.GLPosting", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("CrGlAccountID")
                        .HasColumnType("int");

                    b.Property<double>("CreditAmount")
                        .HasColumnType("float");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("DebitAmount")
                        .HasColumnType("float");

                    b.Property<int?>("DrGlAccountID")
                        .HasColumnType("int");

                    b.Property<string>("Narration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostInitiatorId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CrGlAccountID");

                    b.HasIndex("DrGlAccountID");

                    b.ToTable("GLPostings");
                });

            modelBuilder.Entity("CBA.Core.Models.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RememberMe")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("CBA.Core.Models.MembershipType", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<byte>("DiscountRate")
                        .HasColumnType("tinyint");

                    b.Property<byte>("DurationInMonths")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("SignUpFee")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("MembershipTypes");
                });

            modelBuilder.Entity("CBA.Core.Models.TellerPosting", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("ConsumerAccountID")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerAccountID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Narration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostInitiatorId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostingType")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("TillAccountID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CustomerAccountID");

                    b.HasIndex("TillAccountID");

                    b.ToTable("TellerPostings");
                });

            modelBuilder.Entity("CBA.Core.Models.TellersTill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GLAccounID")
                        .HasColumnType("int");

                    b.Property<int?>("GlAccountId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserId1")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("GlAccountId");

                    b.HasIndex("UserId1");

                    b.ToTable("TellerTills");
                });

            modelBuilder.Entity("CBA.Core.Models.TillAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GlAccountID")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GlAccountID");

                    b.ToTable("TillAccounts");
                });

            modelBuilder.Entity("CBA.Core.Models.Transaction", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("AccountName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("MainCategory")
                        .HasColumnType("int");

                    b.Property<string>("SubCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CBA.Core.Models.AccountTypeManagement", b =>
                {
                    b.HasOne("CBA.Core.Models.GLAccount", "COTIncomeGl")
                        .WithMany()
                        .HasForeignKey("COTIncomeGlID");

                    b.HasOne("CBA.Core.Models.GLAccount", "CurrentInterestExpenseGl")
                        .WithMany()
                        .HasForeignKey("CurrentInterestExpenseGlID");

                    b.HasOne("CBA.Core.Models.GLAccount", "LoanInterestIncomeGl")
                        .WithMany()
                        .HasForeignKey("LoanInterestIncomeGlID");

                    b.HasOne("CBA.Core.Models.GLAccount", "LoanInterestReceivableGl")
                        .WithMany()
                        .HasForeignKey("LoanInterestReceivableGlID");

                    b.HasOne("CBA.Core.Models.GLAccount", "SavingsInterestExpenseGl")
                        .WithMany()
                        .HasForeignKey("SavingsInterestExpenseGlID");

                    b.HasOne("CBA.Core.Models.GLAccount", "SavingsInterestPayableGl")
                        .WithMany()
                        .HasForeignKey("SavingsInterestPayableGlID");

                    b.Navigation("COTIncomeGl");

                    b.Navigation("CurrentInterestExpenseGl");

                    b.Navigation("LoanInterestIncomeGl");

                    b.Navigation("LoanInterestReceivableGl");

                    b.Navigation("SavingsInterestExpenseGl");

                    b.Navigation("SavingsInterestPayableGl");
                });

            modelBuilder.Entity("CBA.Core.Models.CustomerAccount", b =>
                {
                    b.HasOne("CBA.Core.Models.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CBA.Core.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CBA.Core.Models.CustomerAccount", "LinkedAccount")
                        .WithMany()
                        .HasForeignKey("LinkedAccountID");

                    b.Navigation("Branch");

                    b.Navigation("Customer");

                    b.Navigation("LinkedAccount");
                });

            modelBuilder.Entity("CBA.Core.Models.GLAccount", b =>
                {
                    b.HasOne("CBA.Core.Models.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CBA.Core.Models.GLCategory", "GLCategory")
                        .WithMany()
                        .HasForeignKey("GLCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("GLCategory");
                });

            modelBuilder.Entity("CBA.Core.Models.GLPosting", b =>
                {
                    b.HasOne("CBA.Core.Models.GLAccount", "CrGlAccount")
                        .WithMany()
                        .HasForeignKey("CrGlAccountID");

                    b.HasOne("CBA.Core.Models.GLAccount", "DrGlAccount")
                        .WithMany()
                        .HasForeignKey("DrGlAccountID");

                    b.Navigation("CrGlAccount");

                    b.Navigation("DrGlAccount");
                });

            modelBuilder.Entity("CBA.Core.Models.TellerPosting", b =>
                {
                    b.HasOne("CBA.Core.Models.CustomerAccount", "CustomerAccount")
                        .WithMany()
                        .HasForeignKey("CustomerAccountID");

                    b.HasOne("CBA.Core.Models.GLAccount", "TillAccount")
                        .WithMany()
                        .HasForeignKey("TillAccountID");

                    b.Navigation("CustomerAccount");

                    b.Navigation("TillAccount");
                });

            modelBuilder.Entity("CBA.Core.Models.TellersTill", b =>
                {
                    b.HasOne("CBA.Core.Models.GLAccount", "GlAccount")
                        .WithMany()
                        .HasForeignKey("GlAccountId");

                    b.HasOne("CBA.Core.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId1");

                    b.Navigation("GlAccount");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CBA.Core.Models.TillAccount", b =>
                {
                    b.HasOne("CBA.Core.Models.GLAccount", "GlAccount")
                        .WithMany()
                        .HasForeignKey("GlAccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GlAccount");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("CBA.Core.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CBA.Core.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CBA.Core.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("CBA.Core.Models.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CBA.Core.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CBA.Core.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
