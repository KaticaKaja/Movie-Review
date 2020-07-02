using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieReview.EfDataAccess.Migrations
{
    public partial class actormovieconf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ActorMovies_ActorId",
                table: "ActorMovies");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ActorMovies_ActorId_MovieId",
                table: "ActorMovies",
                columns: new[] { "ActorId", "MovieId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_ActorMovies_ActorId_MovieId",
                table: "ActorMovies");

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovies_ActorId",
                table: "ActorMovies",
                column: "ActorId");
        }
    }
}
