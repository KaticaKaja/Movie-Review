using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieReview.EfDataAccess.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "UserUseCases");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "UserUseCases");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "UserUseCases");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserUseCases");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "UserUseCases");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "UserUseCases",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "UserUseCases",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "UserUseCases",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserUseCases",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "UserUseCases",
                type: "datetime2",
                nullable: true);
        }
    }
}
