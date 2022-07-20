using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CBA.DAL.Migrations
{
    public partial class TransactionCustomerAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13991d61-98b3-4eb0-8144-7da1e98f992b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "efdc41df-c48a-4813-a835-6ae050d70098");

            migrationBuilder.AddColumn<int>(
                name: "CustomerAccountID",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "State" },
                values: new object[] { "0168882b-d81a-4fb1-bca6-9e393a4e536c", "dce146d4-8373-4dc6-a349-35dec0218859", "Super Admin", null, 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1674d5e0-850c-4f12-8b1c-f929cd982b1c", 0, "6a66cff0-3107-4fed-9dbd-c21ad149c136", "bolexcoded43@gmail.com", false, "Boluwatife", 0, "Oyetoro", false, null, null, null, null, null, false, "e51987e4-f5cd-4082-b7f9-007843423e15", 0, false, null });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CustomerAccountID",
                table: "Transactions",
                column: "CustomerAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_CustomerAccounts_CustomerAccountID",
                table: "Transactions",
                column: "CustomerAccountID",
                principalTable: "CustomerAccounts",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_CustomerAccounts_CustomerAccountID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CustomerAccountID",
                table: "Transactions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0168882b-d81a-4fb1-bca6-9e393a4e536c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1674d5e0-850c-4f12-8b1c-f929cd982b1c");

            migrationBuilder.DropColumn(
                name: "CustomerAccountID",
                table: "Transactions");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "State" },
                values: new object[] { "13991d61-98b3-4eb0-8144-7da1e98f992b", "aad1f40f-5e52-4b63-8b18-f18f5915a739", "Super Admin", null, 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { "efdc41df-c48a-4813-a835-6ae050d70098", 0, "a16729c2-a2bd-4e4f-8b51-8d590041b2b2", "bolexcoded43@gmail.com", false, "Boluwatife", 0, "Oyetoro", false, null, null, null, null, null, false, "24deab0b-3b5a-4b32-98a5-1d8630e77f4f", 0, false, null });
        }
    }
}
