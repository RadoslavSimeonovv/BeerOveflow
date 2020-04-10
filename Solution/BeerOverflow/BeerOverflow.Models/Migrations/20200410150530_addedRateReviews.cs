using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerOverflow.Data.Migrations
{
    public partial class addedRateReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Beers_BeerId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Users_UserId",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

            migrationBuilder.RenameTable(
                name: "Review",
                newName: "Reviews");

            migrationBuilder.RenameIndex(
                name: "IX_Review_UserId_BeerId",
                table: "Reviews",
                newName: "IX_Reviews_UserId_BeerId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_BeerId",
                table: "Reviews",
                newName: "IX_Reviews_BeerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RateReviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LikeReview = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    IsInapropriate = table.Column<bool>(nullable: false),
                    ReviewId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RateReviews_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RateReviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RateReviews_ReviewId",
                table: "RateReviews",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_RateReviews_UserId",
                table: "RateReviews",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Beers_BeerId",
                table: "Reviews",
                column: "BeerId",
                principalTable: "Beers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Beers_BeerId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_UserId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "RateReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Review");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_UserId_BeerId",
                table: "Review",
                newName: "IX_Review_UserId_BeerId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_BeerId",
                table: "Review",
                newName: "IX_Review_BeerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Beers_BeerId",
                table: "Review",
                column: "BeerId",
                principalTable: "Beers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Users_UserId",
                table: "Review",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
