using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class IntialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24618f0d-5928-4c2e-9476-4dabebd34957");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6910d1a2-65ac-41c7-8b71-a80afe63a15a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "296be4f7-7947-426e-9bd2-cbca97c1eafd", null, "User", "USER" },
                    { "c2318e6c-4280-4d87-9818-b75fcb5e24ff", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "296be4f7-7947-426e-9bd2-cbca97c1eafd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2318e6c-4280-4d87-9818-b75fcb5e24ff");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "24618f0d-5928-4c2e-9476-4dabebd34957", null, "User", "USER" },
                    { "6910d1a2-65ac-41c7-8b71-a80afe63a15a", null, "Admin", "ADMIN" }
                });
        }
    }
}
