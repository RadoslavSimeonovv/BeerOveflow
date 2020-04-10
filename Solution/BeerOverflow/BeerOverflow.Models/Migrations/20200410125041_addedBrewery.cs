using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerOverflow.Data.Migrations
{
    public partial class addedBrewery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beers_BeerTypes_BeerTypeId",
                table: "Beers");

            migrationBuilder.DropForeignKey(
                name: "FK_Beers_Countries_CountryId",
                table: "Beers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BeerTypes",
                table: "BeerTypes");

            migrationBuilder.RenameTable(
                name: "BeerTypes",
                newName: "BeerType");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Beers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BreweryId",
                table: "Beers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BeerType",
                table: "BeerType",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Brewery",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brewery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Brewery_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beers_BreweryId",
                table: "Beers",
                column: "BreweryId");

            migrationBuilder.CreateIndex(
                name: "IX_Brewery_CountryId",
                table: "Brewery",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beers_BeerType_BeerTypeId",
                table: "Beers",
                column: "BeerTypeId",
                principalTable: "BeerType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Beers_Brewery_BreweryId",
                table: "Beers",
                column: "BreweryId",
                principalTable: "Brewery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Beers_Countries_CountryId",
                table: "Beers",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beers_BeerType_BeerTypeId",
                table: "Beers");

            migrationBuilder.DropForeignKey(
                name: "FK_Beers_Brewery_BreweryId",
                table: "Beers");

            migrationBuilder.DropForeignKey(
                name: "FK_Beers_Countries_CountryId",
                table: "Beers");

            migrationBuilder.DropTable(
                name: "Brewery");

            migrationBuilder.DropIndex(
                name: "IX_Beers_BreweryId",
                table: "Beers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BeerType",
                table: "BeerType");

            migrationBuilder.DropColumn(
                name: "BreweryId",
                table: "Beers");

            migrationBuilder.RenameTable(
                name: "BeerType",
                newName: "BeerTypes");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Beers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BeerTypes",
                table: "BeerTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Beers_BeerTypes_BeerTypeId",
                table: "Beers",
                column: "BeerTypeId",
                principalTable: "BeerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Beers_Countries_CountryId",
                table: "Beers",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
