using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt_inz_backend.Migrations
{
    /// <inheritdoc />
    public partial class OwnerUsername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ownerName",
                table: "Spells",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ownerName",
                table: "Races",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ownerName",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ownerName",
                table: "Enemies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ownerName",
                table: "dndSubclasses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ownerName",
                table: "dndClasses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ownerName",
                table: "Spells");

            migrationBuilder.DropColumn(
                name: "ownerName",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "ownerName",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ownerName",
                table: "Enemies");

            migrationBuilder.DropColumn(
                name: "ownerName",
                table: "dndSubclasses");

            migrationBuilder.DropColumn(
                name: "ownerName",
                table: "dndClasses");
        }
    }
}
