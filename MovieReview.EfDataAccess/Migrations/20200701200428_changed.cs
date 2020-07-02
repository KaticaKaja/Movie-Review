using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieReview.EfDataAccess.Migrations
{
    public partial class changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortInfo",
                table: "Genres");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortInfo",
                table: "Genres",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
