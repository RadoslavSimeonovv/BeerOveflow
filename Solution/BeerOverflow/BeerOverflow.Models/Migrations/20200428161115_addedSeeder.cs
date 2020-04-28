using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerOverflow.Data.Migrations
{
    public partial class addedSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { 1, null, "United States" },
                    { 2, null, "Belgium" },
                    { 3, null, "Germany" },
                    { 4, null, "United Kingdom" },
                    { 5, null, "Canada" },
                    { 6, null, "Netherlands" },
                    { 7, null, "Mexico" },
                    { 8, null, "Switzerland" },
                    { 9, null, "China" },
                    { 10, null, "Norway" }
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                keyValue: 6);

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
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: 10);

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
                keyValue: 7);

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

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
