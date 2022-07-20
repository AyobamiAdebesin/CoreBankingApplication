using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CBA.DAL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44211155-60f0-45ef-a036-16cd8a0a9aec");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "711e67ed-1877-4afe-ac64-229457f3de17");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "State" },
                values: new object[] { "0419ac73-a110-4f13-911c-e512d2073285", "2ddfe3c6-2bc9-49db-b0e1-0888fea4481e", "Super Admin", null, 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ddae8b4e-89bd-4f13-bf85-369b7ea5a649", 0, "7d999f5f-6be7-4ad9-bbc0-611e14cb856d", "bolexcoded43@gmail.com", false, "Boluwatife", 0, "Oyetoro", false, null, null, null, null, null, false, "dac16ace-6553-4560-b84b-0343f9b588a4", 0, false, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0419ac73-a110-4f13-911c-e512d2073285");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddae8b4e-89bd-4f13-bf85-369b7ea5a649");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "State" },
                values: new object[] { "44211155-60f0-45ef-a036-16cd8a0a9aec", "5ced3699-cd5f-4b37-89ed-78bde7faa1b0", "Super Admin", null, 0 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { "711e67ed-1877-4afe-ac64-229457f3de17", 0, "e2b38678-694b-4318-842a-be58b34b6910", "bolexcoded43@gmail.com", false, "Boluwatife", 0, "Oyetoro", false, null, null, null, null, null, false, "eedc5852-78d5-4594-bc96-69f512134e01", 0, false, null });
        }
    }
}
