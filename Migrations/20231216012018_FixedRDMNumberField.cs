using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTP.Migrations
{
    public partial class FixedRDMNumberField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "RDM",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "RDM");
        }
    }
}
