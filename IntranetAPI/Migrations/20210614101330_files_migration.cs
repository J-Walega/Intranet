using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntranetAPI.Migrations
{
    public partial class files_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Path",
                table: "Links",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Links",
                newName: "Description");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Links",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Links");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Links",
                newName: "Path");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Links",
                newName: "Name");
        }
    }
}
