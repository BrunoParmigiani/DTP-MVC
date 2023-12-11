using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTP.Migrations
{
    public partial class NewFieldsForDTPs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Analyst",
                table: "DTPs",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Demandant",
                table: "DTPs",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Leader",
                table: "DTPs",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Analyst",
                table: "DTPs");

            migrationBuilder.DropColumn(
                name: "Demandant",
                table: "DTPs");

            migrationBuilder.DropColumn(
                name: "Leader",
                table: "DTPs");
        }
    }
}
