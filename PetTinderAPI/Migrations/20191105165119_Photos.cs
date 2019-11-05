using Microsoft.EntityFrameworkCore.Migrations;

namespace PetTinderAPI.Migrations
{
    public partial class Photos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo1",
                table: "Pets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo2",
                table: "Pets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo3",
                table: "Pets",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo4",
                table: "Pets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo1",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Photo2",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Photo3",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "Photo4",
                table: "Pets");
        }
    }
}
