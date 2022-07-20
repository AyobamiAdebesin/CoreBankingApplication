using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CBA.DAL.Migrations
{
    public partial class TransactionAccountNUmber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Narration",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "State" },
                values: new object[] { "5b5311b7-5828-4cdc-af46-c9737e2386ef", "565d8756-0696-407a-8c7b-bc74811ee9e0", "Super Admin", null, 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b6e9f4b6-f7e7-4fbe-9302-f85ca272261a", 0, "e696c02e-0464-4e46-9f58-a85698dab848", "bolexcoded43@gmail.com", false, "Boluwatife", 0, "Oyetoro", false, null, null, null, null, null, false, "a1bd11dd-767e-495d-94ab-a2ab389d7ad9", 0, false, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b5311b7-5828-4cdc-af46-c9737e2386ef");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b6e9f4b6-f7e7-4fbe-9302-f85ca272261a");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Narration",
                table: "Transactions");

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
    }
}
