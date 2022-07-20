using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CBA.DAL.Migrations
{
    public partial class FinancialDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0419ac73-a110-4f13-911c-e512d2073285");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddae8b4e-89bd-4f13-bf85-369b7ea5a649");

            migrationBuilder.AddColumn<DateTime>(
                name: "FinancialDate",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "State" },
                values: new object[] { "13991d61-98b3-4eb0-8144-7da1e98f992b", "aad1f40f-5e52-4b63-8b18-f18f5915a739", "Super Admin", null, 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { "efdc41df-c48a-4813-a835-6ae050d70098", 0, "a16729c2-a2bd-4e4f-8b51-8d590041b2b2", "bolexcoded43@gmail.com", false, "Boluwatife", 0, "Oyetoro", false, null, null, null, null, null, false, "24deab0b-3b5a-4b32-98a5-1d8630e77f4f", 0, false, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13991d61-98b3-4eb0-8144-7da1e98f992b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "efdc41df-c48a-4813-a835-6ae050d70098");

            migrationBuilder.DropColumn(
                name: "FinancialDate",
                table: "Transactions");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "State" },
                values: new object[] { "0419ac73-a110-4f13-911c-e512d2073285", "2ddfe3c6-2bc9-49db-b0e1-0888fea4481e", "Super Admin", null, 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ddae8b4e-89bd-4f13-bf85-369b7ea5a649", 0, "7d999f5f-6be7-4ad9-bbc0-611e14cb856d", "bolexcoded43@gmail.com", false, "Boluwatife", 0, "Oyetoro", false, null, null, null, null, null, false, "dac16ace-6553-4560-b84b-0343f9b588a4", 0, false, null });
        }
    }
}
