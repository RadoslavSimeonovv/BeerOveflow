using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerOverflow.Data.Migrations
{
    public partial class addedBeerType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BeerTypeId",
                table: "Beers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BeerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeerTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beers_BeerTypeId",
                table: "Beers",
                column: "BeerTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beers_BeerTypes_BeerTypeId",
                table: "Beers",
                column: "BeerTypeId",
                principalTable: "BeerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beers_BeerTypes_BeerTypeId",
                table: "Beers");

            migrationBuilder.DropTable(
                name: "BeerTypes");

            migrationBuilder.DropIndex(
                name: "IX_Beers_BeerTypeId",
                table: "Beers");

            migrationBuilder.DropColumn(
                name: "BeerTypeId",
                table: "Beers");
        }
    }
}
