using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace demo_dotnetcore_web_api.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoleAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4dc25f63-c982-455e-b98c-dc06a2418bd4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4dee5fea-a9d0-4d99-8cb7-d7a61f5bcea8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5b0810c1-0b28-4d11-8753-d460234a6fd5", null, "User", "USER" },
                    { "a68e1faf-b6ce-4960-a1f1-dd2ed4650eb2", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b0810c1-0b28-4d11-8753-d460234a6fd5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a68e1faf-b6ce-4960-a1f1-dd2ed4650eb2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4dc25f63-c982-455e-b98c-dc06a2418bd4", null, "Admin", "ADMIN" },
                    { "4dee5fea-a9d0-4d99-8cb7-d7a61f5bcea8", null, "User", "USER" }
                });
        }
    }
}
