using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieReview.EfDataAccess.Migrations
{
    public partial class updatedtablemovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Movies",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "Movies");
        }
    }
}
