using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerOverflow.Data.Migrations
{
    public partial class imgPath_AddedToBeer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imgPath",
                table: "Beers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "a589b4d8-3d3f-4c4f-9151-9aeff6bf661c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "d8c7d357-778b-41ec-bc5a-480997d2c2b9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "2071b763-858f-4f16-ab31-94ab048cb0f0", new DateTime(2020, 5, 6, 16, 52, 48, 452, DateTimeKind.Utc).AddTicks(2747), "AQAAAAEAACcQAAAAEIx+v98TySZfeplBid+ssqyhygubLE2VSVqZRbvJEYmY5b5J/XbleIvq84kq9Qkrdw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "2b6395a8-a2a6-4415-968f-e1c370ceb091", new DateTime(2020, 5, 6, 16, 52, 48, 464, DateTimeKind.Utc).AddTicks(2961), "AQAAAAEAACcQAAAAENmUu6vMcnE3UeArAMTIAaBShI/HvFcAhcDDoK2VbQGSFAKwJaBxEqIxMfzlXaeGvg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "76594292-0429-4282-b57d-227390f0b3f4", new DateTime(2020, 5, 6, 16, 52, 48, 470, DateTimeKind.Utc).AddTicks(9019), "AQAAAAEAACcQAAAAEFyMsU4yH+nRtgI6hHlc+Yb6IvkuTSRbBk5uddnJvb94C2Usd8yikjI8L/zfIVM6JQ==" });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 6, 16, 52, 48, 477, DateTimeKind.Utc).AddTicks(7066));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 6, 16, 52, 48, 477, DateTimeKind.Utc).AddTicks(7715));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 6, 16, 52, 48, 477, DateTimeKind.Utc).AddTicks(7764));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 6, 16, 52, 48, 477, DateTimeKind.Utc).AddTicks(7783));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 6, 16, 52, 48, 477, DateTimeKind.Utc).AddTicks(7800));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 6, 16, 52, 48, 477, DateTimeKind.Utc).AddTicks(7820));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 6, 16, 52, 48, 477, DateTimeKind.Utc).AddTicks(7837));

            migrationBuilder.UpdateData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 1, 3 },
                column: "DrankOn",
                value: new DateTime(2020, 5, 6, 16, 52, 48, 477, DateTimeKind.Utc).AddTicks(4797));

            migrationBuilder.UpdateData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 1, 4 },
                column: "DrankOn",
                value: new DateTime(2020, 5, 6, 16, 52, 48, 477, DateTimeKind.Utc).AddTicks(4860));

            migrationBuilder.UpdateData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 1, 9 },
                column: "DrankOn",
                value: new DateTime(2020, 5, 6, 16, 52, 48, 477, DateTimeKind.Utc).AddTicks(4967));

            migrationBuilder.UpdateData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 2, 2 },
                column: "DrankOn",
                value: new DateTime(2020, 5, 6, 16, 52, 48, 477, DateTimeKind.Utc).AddTicks(4842));

            migrationBuilder.UpdateData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 2, 5 },
                column: "DrankOn",
                value: new DateTime(2020, 5, 6, 16, 52, 48, 477, DateTimeKind.Utc).AddTicks(4877));

            migrationBuilder.UpdateData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 2, 9 },
                column: "DrankOn",
                value: new DateTime(2020, 5, 6, 16, 52, 48, 477, DateTimeKind.Utc).AddTicks(4911));

            migrationBuilder.UpdateData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 3, 7 },
                column: "DrankOn",
                value: new DateTime(2020, 5, 6, 16, 52, 48, 477, DateTimeKind.Utc).AddTicks(4112));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imgPath",
                table: "Beers");

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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "c3863f2c-3172-4279-81fb-b1eae4e49ce9", new DateTime(2020, 5, 3, 18, 4, 28, 546, DateTimeKind.Utc).AddTicks(6942), "AQAAAAEAACcQAAAAEOKPRD0sL3tpM8O6m1v/YGCXsiQZI++MBho+Mlh/swj3AwfhGa5RbvMHzJLocNmc6g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "0a44a4c9-e758-4a0f-8f29-76d2c4d34b77", new DateTime(2020, 5, 3, 18, 4, 28, 568, DateTimeKind.Utc).AddTicks(9101), "AQAAAAEAACcQAAAAEEBwKM4Q+ELbKlPArRPixDUsCZeR0Tb53zTcBVhM9Suq3INNafzzut4clL/Hfk3I6A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "08c33479-3bda-497e-8e57-1a60acf90228", new DateTime(2020, 5, 3, 18, 4, 28, 583, DateTimeKind.Utc).AddTicks(5992), "AQAAAAEAACcQAAAAEMWIDeDn31jXsG+vJRuTt9Wf37MroJZohRgh/gkPalA8qYIZGEGBkLvLaJPGcCdENA==" });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 3, 18, 4, 28, 596, DateTimeKind.Utc).AddTicks(2373));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 3, 18, 4, 28, 596, DateTimeKind.Utc).AddTicks(3621));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 3, 18, 4, 28, 596, DateTimeKind.Utc).AddTicks(3716));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 3, 18, 4, 28, 596, DateTimeKind.Utc).AddTicks(3747));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 3, 18, 4, 28, 596, DateTimeKind.Utc).AddTicks(3978));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 3, 18, 4, 28, 596, DateTimeKind.Utc).AddTicks(4018));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 7,
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 3, 18, 4, 28, 596, DateTimeKind.Utc).AddTicks(4046));

            migrationBuilder.UpdateData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 1, 3 },
                column: "DrankOn",
                value: new DateTime(2020, 5, 3, 18, 4, 28, 595, DateTimeKind.Utc).AddTicks(7128));

            migrationBuilder.UpdateData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 1, 4 },
                column: "DrankOn",
                value: new DateTime(2020, 5, 3, 18, 4, 28, 595, DateTimeKind.Utc).AddTicks(7228));

            migrationBuilder.UpdateData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 1, 9 },
                column: "DrankOn",
                value: new DateTime(2020, 5, 3, 18, 4, 28, 595, DateTimeKind.Utc).AddTicks(7333));

            migrationBuilder.UpdateData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 2, 2 },
                column: "DrankOn",
                value: new DateTime(2020, 5, 3, 18, 4, 28, 595, DateTimeKind.Utc).AddTicks(7198));

            migrationBuilder.UpdateData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 2, 5 },
                column: "DrankOn",
                value: new DateTime(2020, 5, 3, 18, 4, 28, 595, DateTimeKind.Utc).AddTicks(7254));

            migrationBuilder.UpdateData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 2, 9 },
                column: "DrankOn",
                value: new DateTime(2020, 5, 3, 18, 4, 28, 595, DateTimeKind.Utc).AddTicks(7306));

            migrationBuilder.UpdateData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 3, 7 },
                column: "DrankOn",
                value: new DateTime(2020, 5, 3, 18, 4, 28, 595, DateTimeKind.Utc).AddTicks(5807));
        }
    }
}
