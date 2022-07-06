using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CBA.DAL.Migrations
{
    public partial class GeneralMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortCode = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerLongID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    CustomerInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseIncomeEntries",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntryType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseIncomeEntries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FineNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FineNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GLCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Categories = table.Column<int>(type: "int", nullable: false),
                    CategoryCode = table.Column<long>(type: "bigint", nullable: false),
                    MainGLCategory = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: true),
                    CategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GLCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RememberMe = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MembershipTypes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SignUpFee = table.Column<short>(type: "smallint", nullable: false),
                    DurationInMonths = table.Column<byte>(type: "tinyint", nullable: false),
                    DiscountRate = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainCategory = table.Column<int>(type: "int", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAccounts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountBalance = table.Column<double>(type: "float", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    AccountStatus = table.Column<int>(type: "int", nullable: false),
                    AccountType = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    DaysCount = table.Column<int>(type: "int", nullable: true),
                    dailyInterestAccrued = table.Column<double>(type: "float", nullable: true),
                    LoanInterestRatePerMonth = table.Column<double>(type: "float", nullable: true),
                    SavingsWithdrawalCount = table.Column<int>(type: "int", nullable: true),
                    CurrentLien = table.Column<double>(type: "float", nullable: true),
                    LoanMonthlyInterestRepay = table.Column<double>(type: "float", nullable: false),
                    LoanMonthlyRepay = table.Column<double>(type: "float", nullable: false),
                    LoanMonthlyPrincipalRepay = table.Column<double>(type: "float", nullable: false),
                    LoanPrincipalRemaining = table.Column<double>(type: "float", nullable: false),
                    TermsOfLoan = table.Column<int>(type: "int", nullable: true),
                    LoanAmount = table.Column<double>(type: "float", nullable: false),
                    LinkedAccountID = table.Column<int>(type: "int", nullable: true),
                    NewCustomerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerLongID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAccounts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomerAccounts_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAccounts_CustomerAccounts_LinkedAccountID",
                        column: x => x.LinkedAccountID,
                        principalTable: "CustomerAccounts",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CustomerAccounts_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GLAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountCode = table.Column<long>(type: "bigint", nullable: false),
                    Categories = table.Column<int>(type: "int", nullable: false),
                    AccountBalance = table.Column<double>(type: "float", nullable: false),
                    State = table.Column<int>(type: "int", nullable: true),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    GLCategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GLAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GLAccounts_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GLAccounts_GLCategories_GLCategoryID",
                        column: x => x.GLCategoryID,
                        principalTable: "GLCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountTypeManagements",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentCreditInterestRate = table.Column<double>(type: "float", nullable: false),
                    CurrentMinimumBalance = table.Column<double>(type: "float", nullable: false),
                    COT = table.Column<double>(type: "float", nullable: false),
                    CurrentInterestExpenseGlID = table.Column<int>(type: "int", nullable: true),
                    COTIncomeGlID = table.Column<int>(type: "int", nullable: true),
                    SavingsCreditInterestRate = table.Column<double>(type: "float", nullable: false),
                    SavingsMinimumBalance = table.Column<double>(type: "float", nullable: false),
                    SavingsInterestExpenseGlID = table.Column<int>(type: "int", nullable: true),
                    SavingsInterestPayableGlID = table.Column<int>(type: "int", nullable: true),
                    LoanDebitInterestRate = table.Column<double>(type: "float", nullable: false),
                    LoanInterestIncomeGlID = table.Column<int>(type: "int", nullable: true),
                    LoanInterestReceivableGlID = table.Column<int>(type: "int", nullable: true),
                    IsOpened = table.Column<bool>(type: "bit", nullable: false),
                    FinancialDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypeManagements", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AccountTypeManagements_GLAccounts_COTIncomeGlID",
                        column: x => x.COTIncomeGlID,
                        principalTable: "GLAccounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountTypeManagements_GLAccounts_CurrentInterestExpenseGlID",
                        column: x => x.CurrentInterestExpenseGlID,
                        principalTable: "GLAccounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountTypeManagements_GLAccounts_LoanInterestIncomeGlID",
                        column: x => x.LoanInterestIncomeGlID,
                        principalTable: "GLAccounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountTypeManagements_GLAccounts_LoanInterestReceivableGlID",
                        column: x => x.LoanInterestReceivableGlID,
                        principalTable: "GLAccounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountTypeManagements_GLAccounts_SavingsInterestExpenseGlID",
                        column: x => x.SavingsInterestExpenseGlID,
                        principalTable: "GLAccounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountTypeManagements_GLAccounts_SavingsInterestPayableGlID",
                        column: x => x.SavingsInterestPayableGlID,
                        principalTable: "GLAccounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GLPostings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditAmount = table.Column<double>(type: "float", nullable: false),
                    DebitAmount = table.Column<double>(type: "float", nullable: false),
                    Narration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DrGlAccountID = table.Column<int>(type: "int", nullable: true),
                    CrGlAccountID = table.Column<int>(type: "int", nullable: true),
                    PostInitiatorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GLPostings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GLPostings_GLAccounts_CrGlAccountID",
                        column: x => x.CrGlAccountID,
                        principalTable: "GLAccounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GLPostings_GLAccounts_DrGlAccountID",
                        column: x => x.DrGlAccountID,
                        principalTable: "GLAccounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TellerPostings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Narration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostingType = table.Column<int>(type: "int", nullable: false),
                    ConsumerAccountID = table.Column<int>(type: "int", nullable: false),
                    CustomerAccountID = table.Column<int>(type: "int", nullable: true),
                    PostInitiatorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TillAccountID = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TellerPostings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TellerPostings_CustomerAccounts_CustomerAccountID",
                        column: x => x.CustomerAccountID,
                        principalTable: "CustomerAccounts",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TellerPostings_GLAccounts_TillAccountID",
                        column: x => x.TillAccountID,
                        principalTable: "GLAccounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TellerTills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    GLAccounID = table.Column<int>(type: "int", nullable: false),
                    GlAccountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TellerTills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TellerTills_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TellerTills_GLAccounts_GlAccountId",
                        column: x => x.GlAccountId,
                        principalTable: "GLAccounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TillAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GlAccountID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TillAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TillAccounts_GLAccounts_GlAccountID",
                        column: x => x.GlAccountID,
                        principalTable: "GLAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "State" },
                values: new object[] { "44211155-60f0-45ef-a036-16cd8a0a9aec", "5ced3699-cd5f-4b37-89ed-78bde7faa1b0", "Super Admin", null, 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { "711e67ed-1877-4afe-ac64-229457f3de17", 0, "e2b38678-694b-4318-842a-be58b34b6910", "bolexcoded43@gmail.com", false, "Boluwatife", 0, "Oyetoro", false, null, null, null, null, null, false, "eedc5852-78d5-4594-bc96-69f512134e01", 0, false, null });

            migrationBuilder.CreateIndex(
                name: "IX_AccountTypeManagements_COTIncomeGlID",
                table: "AccountTypeManagements",
                column: "COTIncomeGlID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTypeManagements_CurrentInterestExpenseGlID",
                table: "AccountTypeManagements",
                column: "CurrentInterestExpenseGlID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTypeManagements_LoanInterestIncomeGlID",
                table: "AccountTypeManagements",
                column: "LoanInterestIncomeGlID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTypeManagements_LoanInterestReceivableGlID",
                table: "AccountTypeManagements",
                column: "LoanInterestReceivableGlID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTypeManagements_SavingsInterestExpenseGlID",
                table: "AccountTypeManagements",
                column: "SavingsInterestExpenseGlID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTypeManagements_SavingsInterestPayableGlID",
                table: "AccountTypeManagements",
                column: "SavingsInterestPayableGlID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccounts_BranchID",
                table: "CustomerAccounts",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccounts_CustomerID",
                table: "CustomerAccounts",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccounts_LinkedAccountID",
                table: "CustomerAccounts",
                column: "LinkedAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_GLAccounts_BranchID",
                table: "GLAccounts",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_GLAccounts_GLCategoryID",
                table: "GLAccounts",
                column: "GLCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_GLPostings_CrGlAccountID",
                table: "GLPostings",
                column: "CrGlAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_GLPostings_DrGlAccountID",
                table: "GLPostings",
                column: "DrGlAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_TellerPostings_CustomerAccountID",
                table: "TellerPostings",
                column: "CustomerAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_TellerPostings_TillAccountID",
                table: "TellerPostings",
                column: "TillAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_TellerTills_GlAccountId",
                table: "TellerTills",
                column: "GlAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_TellerTills_UserId1",
                table: "TellerTills",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_TillAccounts_GlAccountID",
                table: "TillAccounts",
                column: "GlAccountID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountTypeManagements");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ExpenseIncomeEntries");

            migrationBuilder.DropTable(
                name: "FineNames");

            migrationBuilder.DropTable(
                name: "GLPostings");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "MembershipTypes");

            migrationBuilder.DropTable(
                name: "TellerPostings");

            migrationBuilder.DropTable(
                name: "TellerTills");

            migrationBuilder.DropTable(
                name: "TillAccounts");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "CustomerAccounts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "GLAccounts");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "GLCategories");
        }
    }
}
