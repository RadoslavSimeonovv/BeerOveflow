using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerOverflow.Data.Migrations
{
    public partial class addedSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beers_Countries_CountryId",
                table: "Beers");

            migrationBuilder.DropIndex(
                name: "IX_Beers_CountryId",
                table: "Beers");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Beers");

            migrationBuilder.InsertData(
                table: "BeerTypes",
                columns: new[] { "Id", "DeletedOn", "Description", "Type" },
                values: new object[,]
                {
                    { 1, null, "Style of beer that was developed in London in the early eighteenth century.", "Porter" },
                    { 2, null, "Type of beer conditioned at low temperatures.", "Lager" },
                    { 3, null, "Type of beer brewed using a warm fermentation method", "Ale" },
                    { 4, null, "Dark, top-fermented beer with a number of variations, including dry stout, Baltic porter, milk stout, and imperial stout.", "Stout" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "DeletedOn", "Name" },
                values: new object[,]
                {
                    { 10, null, "Norway" },
                    { 9, null, "China" },
                    { 8, null, "Switzerland" },
                    { 7, null, "Mexico" },
                    { 6, null, "Netherlands" },
                    { 4, null, "United Kingdom" },
                    { 3, null, "Germany" },
                    { 2, null, "Belgium" },
                    { 1, null, "United States" },
                    { 5, null, "Canada" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedOn", "DateOfBirth", "Email", "FirstName", "LastName", "Username" },
                values: new object[,]
                {
                    { 5, new DateTime(2020, 4, 25, 12, 23, 50, 555, DateTimeKind.Utc).AddTicks(444), null, "geriflow@gmail.com", "Gergana", "Ivanova", "GeritoIv" },
                    { 1, new DateTime(2020, 4, 25, 12, 23, 50, 554, DateTimeKind.Utc).AddTicks(9464), null, "bvuchev@abv.bg", "Boyan", "Vuchev", "Boyanski" },
                    { 2, new DateTime(2020, 4, 25, 12, 23, 50, 555, DateTimeKind.Utc).AddTicks(357), null, "rsimeonovv@abv.bg", "Radoslav", "Simeonov", "RSimeonov" },
                    { 3, new DateTime(2020, 4, 25, 12, 23, 50, 555, DateTimeKind.Utc).AddTicks(401), null, "peshop@gmail.com", "Petur", "Petrov", "PeturPetrof" },
                    { 4, new DateTime(2020, 4, 25, 12, 23, 50, 555, DateTimeKind.Utc).AddTicks(424), null, "vankatas@gmail.com", "Ivan", "Stoyanov", "VankataV" },
                    { 6, new DateTime(2020, 4, 25, 12, 23, 50, 555, DateTimeKind.Utc).AddTicks(467), null, "mimiang@gmail.com", "Mariya", "Angelova", "MimiG" }
                });

            migrationBuilder.InsertData(
                table: "Breweries",
                columns: new[] { "Id", "CountryId", "DeletedOn", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1, null, "America", "Diamond Knot Brewery" },
                    { 2, 1, null, "American brewery", "Anheuser-Busch" },
                    { 8, 1, null, "American brewery", "Left Hand Brewing" },
                    { 10, 1, null, "American brewery", "Coors Brewing Company" },
                    { 5, 2, null, "Belge brewery", "Brouwerij van Hoegaarden" },
                    { 4, 3, null, "Dutch brewery", "Heineken International" },
                    { 3, 4, null, "English brewery", "Greene King" },
                    { 9, 4, null, "Chinese brewery", "Tsingtao Brewery" },
                    { 6, 7, null, "Mexican brewery", "Grupo Modelo" },
                    { 7, 9, null, "Chinese brewery", "CR Snow" }
                });

            migrationBuilder.InsertData(
                table: "Beers",
                columns: new[] { "Id", "AlcByVol", "BeerName", "BeerTypeId", "BreweryId", "DateUnlisted", "Description" },
                values: new object[,]
                {
                    { 1, 5.5999999999999996, "Possession Porter", 1, 1, null, "American beer" },
                    { 7, 5.0, "Budweiser", 2, 1, null, "American beer" },
                    { 8, 5.0, "Left Hand Milk Stout", 4, 8, null, "English beer" },
                    { 10, 4.2000000000000002, "Coors Light", 2, 10, null, "English beer" },
                    { 3, 4.9000000000000004, "Hoegaarden", 3, 5, null, "Belge beer" },
                    { 4, 5.0, "Heineken", 3, 4, null, "Dutch beer" },
                    { 2, 5.0, "Wexford Irish Cream Ale", 3, 3, null, "English beer" },
                    { 9, 5.0, "Tsingtao", 3, 3, null, "Chinese beer" },
                    { 5, 4.5, "Corona Extra", 2, 6, null, "Mexican-Belge beer" },
                    { 6, 4.0, "Snow", 2, 7, null, "Chinese beer" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BeerId", "DeletedOn", "RMessage", "Rating", "ReviewedOn", "UserId" },
                values: new object[,]
                {
                    { 1, 1, null, "Cool beer!", 5, new DateTime(2020, 4, 25, 12, 23, 50, 555, DateTimeKind.Utc).AddTicks(3726), 4 },
                    { 6, 5, null, "Not my taste.", 2, new DateTime(2020, 4, 25, 12, 23, 50, 555, DateTimeKind.Utc).AddTicks(4854), 4 },
                    { 10, 10, null, "My friend lied to me, its not that good.", 3, new DateTime(2020, 4, 25, 12, 23, 50, 555, DateTimeKind.Utc).AddTicks(5003), 3 },
                    { 2, 7, null, "Very fresh, would buy again!", 4, new DateTime(2020, 4, 25, 12, 23, 50, 555, DateTimeKind.Utc).AddTicks(4743), 3 },
                    { 11, 7, null, "Excellent!", 5, new DateTime(2020, 4, 25, 12, 23, 50, 555, DateTimeKind.Utc).AddTicks(5023), 2 },
                    { 7, 2, null, "Rip off!", 1, new DateTime(2020, 4, 25, 12, 23, 50, 555, DateTimeKind.Utc).AddTicks(4874), 4 },
                    { 5, 2, null, "Not great, not terrible.", 3, new DateTime(2020, 4, 25, 12, 23, 50, 555, DateTimeKind.Utc).AddTicks(4831), 1 },
                    { 9, 3, null, "Decent taste and price!", 4, new DateTime(2020, 4, 25, 12, 23, 50, 555, DateTimeKind.Utc).AddTicks(4981), 1 },
                    { 3, 8, null, "I don't recommend it!", 1, new DateTime(2020, 4, 25, 12, 23, 50, 555, DateTimeKind.Utc).AddTicks(4788), 6 },
                    { 4, 8, null, "Top class!", 5, new DateTime(2020, 4, 25, 12, 23, 50, 555, DateTimeKind.Utc).AddTicks(4811), 5 },
                    { 8, 4, null, "I already bought another 10 of those!", 5, new DateTime(2020, 4, 25, 12, 23, 50, 555, DateTimeKind.Utc).AddTicks(4957), 6 }
                });

            migrationBuilder.InsertData(
                table: "UserBeers",
                columns: new[] { "UserId", "BeerId", "DeletedOn", "DrankOn" },
                values: new object[,]
                {
                    { 3, 3, null, null },
                    { 2, 4, null, null },
                    { 4, 2, null, new DateTime(2020, 4, 25, 12, 23, 50, 555, DateTimeKind.Utc).AddTicks(7722) },
                    { 1, 2, null, new DateTime(2020, 4, 25, 12, 23, 50, 555, DateTimeKind.Utc).AddTicks(7949) },
                    { 6, 4, null, null },
                    { 6, 3, null, null },
                    { 3, 10, null, null },
                    { 3, 5, null, null },
                    { 6, 8, null, new DateTime(2020, 4, 25, 12, 23, 50, 555, DateTimeKind.Utc).AddTicks(7928) },
                    { 5, 8, null, new DateTime(2020, 4, 25, 12, 23, 50, 555, DateTimeKind.Utc).AddTicks(7909) },
                    { 4, 7, null, null },
                    { 3, 7, null, new DateTime(2020, 4, 25, 12, 23, 50, 555, DateTimeKind.Utc).AddTicks(7618) },
                    { 2, 7, null, new DateTime(2020, 4, 25, 12, 23, 50, 555, DateTimeKind.Utc).AddTicks(6737) },
                    { 2, 1, null, null },
                    { 6, 1, null, null },
                    { 4, 1, null, new DateTime(2020, 4, 25, 12, 23, 50, 555, DateTimeKind.Utc).AddTicks(7742) },
                    { 1, 3, null, new DateTime(2020, 4, 25, 12, 23, 50, 555, DateTimeKind.Utc).AddTicks(7699) },
                    { 4, 5, null, new DateTime(2020, 4, 25, 12, 23, 50, 555, DateTimeKind.Utc).AddTicks(7762) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Breweries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Breweries",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 10);

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
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 11);

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
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 3, 10 });

            migrationBuilder.DeleteData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 5, 8 });

            migrationBuilder.DeleteData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "UserBeers",
                keyColumns: new[] { "UserId", "BeerId" },
                keyValues: new object[] { 6, 8 });

            migrationBuilder.DeleteData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Breweries",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BeerTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BeerTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BeerTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BeerTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Breweries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Breweries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Breweries",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Breweries",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Breweries",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Breweries",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Breweries",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Beers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Beers_CountryId",
                table: "Beers",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beers_Countries_CountryId",
                table: "Beers",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
