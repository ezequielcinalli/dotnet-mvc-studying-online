using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyingOnline.Migrations
{
    public partial class AddSeedRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "78d29013-0236-42ea-9234-84a01aea6226", "938c23d6-4d30-425b-a3a8-5f71944da9d3", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78d29013-0236-42ea-9234-84a01aea6226");
        }
    }
}
