using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerOverflow.Data.Migrations
{
    public partial class addedUserBeers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserBeers",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    BeerId = table.Column<int>(nullable: false),
                    DrankOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBeers", x => new { x.UserId, x.BeerId });
                    table.ForeignKey(
                        name: "FK_UserBeers_Beers_BeerId",
                        column: x => x.BeerId,
                        principalTable: "Beers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBeers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBeers_BeerId",
                table: "UserBeers",
                column: "BeerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserBeers");
        }
    }
}
