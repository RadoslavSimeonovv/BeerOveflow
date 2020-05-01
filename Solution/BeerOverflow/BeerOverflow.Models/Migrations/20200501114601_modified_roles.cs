using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerOverflow.Data.Migrations
{
    public partial class modified_roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "0027434f-f6e0-4d66-b182-a366bc42fa12", "Sysadmin" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "cc3b6368-cd43-484f-9e1a-512ab248e0f3", "Sysuser" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "81be2487-56e9-4264-aecd-a185e42f42d2", null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "81ed744a-d9b4-4dc1-9a09-1576786ca7ae", null });
        }
    }
}
