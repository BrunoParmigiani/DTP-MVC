using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTP.Migrations
{
    public partial class Updated_DTPs_And_RDMs_Fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RDM_RDM_ParentId",
                table: "RDM");

            migrationBuilder.DropForeignKey(
                name: "FK_RDM_RDM_ParentRDMId",
                table: "RDM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RDM",
                table: "RDM");

            migrationBuilder.DropIndex(
                name: "IX_RDM_ParentId",
                table: "RDM");

            migrationBuilder.DropIndex(
                name: "IX_RDM_ParentRDMId",
                table: "RDM");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "RDM");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "RDM");

            migrationBuilder.DropColumn(
                name: "ParentRDMId",
                table: "RDM");

            migrationBuilder.DropColumn(
                name: "Ticket",
                table: "RDM");

            migrationBuilder.RenameTable(
                name: "RDM",
                newName: "ParentRDMs");

            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "ParentRDMs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParentRDMs",
                table: "ParentRDMs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ChildrenRDMs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: true),
                    User = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Requester = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Environment = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    System = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Unavailable = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    Summary = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RequiredTo = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    OpenDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildrenRDMs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildrenRDMs_DTPs_TicketId",
                        column: x => x.TicketId,
                        principalTable: "DTPs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChildrenRDMs_ParentRDMs_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ParentRDMs",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ParentRDMs_TicketId",
                table: "ParentRDMs",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildrenRDMs_ParentId",
                table: "ChildrenRDMs",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildrenRDMs_TicketId",
                table: "ChildrenRDMs",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParentRDMs_DTPs_TicketId",
                table: "ParentRDMs",
                column: "TicketId",
                principalTable: "DTPs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParentRDMs_DTPs_TicketId",
                table: "ParentRDMs");

            migrationBuilder.DropTable(
                name: "ChildrenRDMs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParentRDMs",
                table: "ParentRDMs");

            migrationBuilder.DropIndex(
                name: "IX_ParentRDMs_TicketId",
                table: "ParentRDMs");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "ParentRDMs");

            migrationBuilder.RenameTable(
                name: "ParentRDMs",
                newName: "RDM");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "RDM",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "RDM",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentRDMId",
                table: "RDM",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ticket",
                table: "RDM",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RDM",
                table: "RDM",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RDM_ParentId",
                table: "RDM",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_RDM_ParentRDMId",
                table: "RDM",
                column: "ParentRDMId");

            migrationBuilder.AddForeignKey(
                name: "FK_RDM_RDM_ParentId",
                table: "RDM",
                column: "ParentId",
                principalTable: "RDM",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RDM_RDM_ParentRDMId",
                table: "RDM",
                column: "ParentRDMId",
                principalTable: "RDM",
                principalColumn: "Id");
        }
    }
}
