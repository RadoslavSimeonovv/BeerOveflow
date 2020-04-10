using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerOverflow.Data.Migrations
{
    public partial class addedUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beers_BeerType_BeerTypeId",
                table: "Beers");

            migrationBuilder.DropForeignKey(
                name: "FK_Beers_Brewery_BreweryId",
                table: "Beers");

            migrationBuilder.DropForeignKey(
                name: "FK_Brewery_Countries_CountryId",
                table: "Brewery");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brewery",
                table: "Brewery");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BeerType",
                table: "BeerType");

            migrationBuilder.RenameTable(
                name: "Brewery",
                newName: "Breweries");

            migrationBuilder.RenameTable(
                name: "BeerType",
                newName: "BeerTypes");

            migrationBuilder.RenameIndex(
                name: "IX_Brewery_CountryId",
                table: "Breweries",
                newName: "IX_Breweries_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Breweries",
                table: "Breweries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BeerTypes",
                table: "BeerTypes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beers_BeerTypes_BeerTypeId",
                table: "Beers",
                column: "BeerTypeId",
                principalTable: "BeerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Beers_Breweries_BreweryId",
                table: "Beers",
                column: "BreweryId",
                principalTable: "Breweries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Breweries_Countries_CountryId",
                table: "Breweries",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beers_BeerTypes_BeerTypeId",
                table: "Beers");

            migrationBuilder.DropForeignKey(
                name: "FK_Beers_Breweries_BreweryId",
                table: "Beers");

            migrationBuilder.DropForeignKey(
                name: "FK_Breweries_Countries_CountryId",
                table: "Breweries");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Breweries",
                table: "Breweries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BeerTypes",
                table: "BeerTypes");

            migrationBuilder.RenameTable(
                name: "Breweries",
                newName: "Brewery");

            migrationBuilder.RenameTable(
                name: "BeerTypes",
                newName: "BeerType");

            migrationBuilder.RenameIndex(
                name: "IX_Breweries_CountryId",
                table: "Brewery",
                newName: "IX_Brewery_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brewery",
                table: "Brewery",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BeerType",
                table: "BeerType",
                column: "Id");

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
                name: "FK_Brewery_Countries_CountryId",
                table: "Brewery",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
