using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieReview.EfDataAccess.Migrations
{
    public partial class moviegenreconf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MovieGenres_GenreId",
                table: "MovieGenres");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_MovieGenres_GenreId_MovieId",
                table: "MovieGenres",
                columns: new[] { "GenreId", "MovieId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_MovieGenres_GenreId_MovieId",
                table: "MovieGenres");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_GenreId",
                table: "MovieGenres",
                column: "GenreId");
        }
    }
}
