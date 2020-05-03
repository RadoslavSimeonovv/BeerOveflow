using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerOverflow.Data.Migrations
{
    public partial class addedSeeder_User_UB_Roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "e2a7bac8-5222-4ea2-b036-c4d046a3cc24");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "180c2da2-d198-4d23-ba95-426bb26d1e50");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "banDescription", "isBanned" },
                values: new object[,]
                {
                    { 1, 0, "c3863f2c-3172-4279-81fb-b1eae4e49ce9", new DateTime(2020, 5, 3, 18, 4, 28, 546, DateTimeKind.Utc).AddTicks(6942), null, "bvuchev@abv.bg", false, "Boyan", "Vuchev", true, null, "BVUCHEV@ABV.BG", "BVUCHEV@ABV.BG", "AQAAAAEAACcQAAAAEOKPRD0sL3tpM8O6m1v/YGCXsiQZI++MBho+Mlh/swj3AwfhGa5RbvMHzJLocNmc6g==", null, false, "DC6E275DD1E24957A7781D42BB68293B", false, "bvuchev@abv.bg", null, false },
                    { 2, 0, "0a44a4c9-e758-4a0f-8f29-76d2c4d34b77", new DateTime(2020, 5, 3, 18, 4, 28, 568, DateTimeKind.Utc).AddTicks(9101), null, "RSIMEONOV@aABV.BG", false, "Radoslav", "Simeonov", true, null, "RSIMEONOV@ABV.BG", "RSIMEONOV@ABV.BG", "AQAAAAEAACcQAAAAEEBwKM4Q+ELbKlPArRPixDUsCZeR0Tb53zTcBVhM9Suq3INNafzzut4clL/Hfk3I6A==", null, false, "HNWQ7GQFUMWKGOAWSJNC5XV2VFYQRWHC", false, "rsimeonov@abv.bg", null, false },
                    { 3, 0, "08c33479-3bda-497e-8e57-1a60acf90228", new DateTime(2020, 5, 3, 18, 4, 28, 583, DateTimeKind.Utc).AddTicks(5992), null, "IVAN@ABV.BG", false, "Ivan", "Ivanov", true, null, "IVAN@ABV.BG", "IVAN@ABV.BG", "AQAAAAEAACcQAAAAEMWIDeDn31jXsG+vJRuTt9Wf37MroJZohRgh/gkPalA8qYIZGEGBkLvLaJPGcCdENA==", null, false, "CYHXVA33BAZ6B5DDG6AKUABAP3K7ONVY", false, "ivan@abv.bg", null, false }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { 3, 2 },
                    { 2, 2 },
                    { 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BeerId", "DeletedOn", "RMessage", "Rating", "ReviewedOn", "UserId" },
                values: new object[,]
                {
                    { 7, 7, null, "Rip off!", 1, new DateTime(2020, 5, 3, 18, 4, 28, 596, DateTimeKind.Utc).AddTicks(4046), 3 },
                    { 3, 6, null, "I don't recommend it!", 1, new DateTime(2020, 5, 3, 18, 4, 28, 596, DateTimeKind.Utc).AddTicks(3716), 3 },
                    { 5, 2, null, "Not great, not terrible.", 3, new DateTime(2020, 5, 3, 18, 4, 28, 596, DateTimeKind.Utc).AddTicks(3978), 2 },
                    { 2, 9, null, "Very fresh, would buy again!", 4, new DateTime(2020, 5, 3, 18, 4, 28, 596, DateTimeKind.Utc).AddTicks(3621), 2 },
                    { 1, 9, null, "Cool beer!", 5, new DateTime(2020, 5, 3, 18, 4, 28, 596, DateTimeKind.Utc).AddTicks(2373), 1 },
                    { 6, 3, null, "Not my taste.", 2, new DateTime(2020, 5, 3, 18, 4, 28, 596, DateTimeKind.Utc).AddTicks(4018), 1 },
                    { 4, 4, null, "Top class!", 5, new DateTime(2020, 5, 3, 18, 4, 28, 596, DateTimeKind.Utc).AddTicks(3747), 1 }
                });

            migrationBuilder.InsertData(
                table: "UserBeers",
                columns: new[] { "UserId", "BeerId", "DeletedOn", "DrankOn" },
                values: new object[,]
                {
                    { 1, 4, null, new DateTime(2020, 5, 3, 18, 4, 28, 595, DateTimeKind.Utc).AddTicks(7228) },
                    { 1, 3, null, new DateTime(2020, 5, 3, 18, 4, 28, 595, DateTimeKind.Utc).AddTicks(7128) },
                    { 3, 6, null, null },
                    { 2, 2, null, new DateTime(2020, 5, 3, 18, 4, 28, 595, DateTimeKind.Utc).AddTicks(7198) },
                    { 2, 5, null, new DateTime(2020, 5, 3, 18, 4, 28, 595, DateTimeKind.Utc).AddTicks(7254) },
                    { 2, 9, null, new DateTime(2020, 5, 3, 18, 4, 28, 595, DateTimeKind.Utc).AddTicks(7306) },
                    { 1, 2, null, null },
                    { 3, 7, null, new DateTime(2020, 5, 3, 18, 4, 28, 595, DateTimeKind.Utc).AddTicks(5807) },
                    { 3, 5, null, null },
                    { 1, 9, null, new DateTime(2020, 5, 3, 18, 4, 28, 595, DateTimeKind.Utc).AddTicks(7333) },
                    { 2, 10, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 2, 9 });

            migrationBuilder.DeleteData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 2, 10 });

            migrationBuilder.DeleteData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "0027434f-f6e0-4d66-b182-a366bc42fa12");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "cc3b6368-cd43-484f-9e1a-512ab248e0f3");
        }
    }
}
