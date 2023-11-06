using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt_inz_backend.Migrations
{
    /// <inheritdoc />
    public partial class LanguagesRaceFeatures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "languages",
                table: "raceFeatures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "languages",
                table: "raceFeatures");
        }
    }
}
