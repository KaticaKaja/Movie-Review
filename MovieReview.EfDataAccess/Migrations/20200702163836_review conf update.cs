using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieReview.EfDataAccess.Migrations
{
    public partial class reviewconfupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reviews_MovieId",
                table: "Reviews");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Reviews_MovieId_UserId",
                table: "Reviews",
                columns: new[] { "MovieId", "UserId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Reviews_MovieId_UserId",
                table: "Reviews");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MovieId",
                table: "Reviews",
                column: "MovieId");
        }
    }
}
