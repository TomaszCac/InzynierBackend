using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt_inz_backend.Migrations
{
    /// <inheritdoc />
    public partial class ModelUpvotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "upvotes",
                table: "Spells",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "upvotes",
                table: "Races",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "upvotes",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "upvotes",
                table: "Enemies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "upvotes",
                table: "dndSubclasses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "upvotes",
                table: "dndClasses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "upvotes",
                table: "Spells");

            migrationBuilder.DropColumn(
                name: "upvotes",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "upvotes",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "upvotes",
                table: "Enemies");

            migrationBuilder.DropColumn(
                name: "upvotes",
                table: "dndSubclasses");

            migrationBuilder.DropColumn(
                name: "upvotes",
                table: "dndClasses");
        }
    }
}
