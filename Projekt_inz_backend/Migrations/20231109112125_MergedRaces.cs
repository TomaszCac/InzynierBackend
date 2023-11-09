using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt_inz_backend.Migrations
{
    /// <inheritdoc />
    public partial class MergedRaces : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "raceFeatures");

            migrationBuilder.AddColumn<string>(
                name: "abilityScoreIncrease",
                table: "Races",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "age",
                table: "Races",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "alignment",
                table: "Races",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "languages",
                table: "Races",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "raceDescription",
                table: "Races",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "size",
                table: "Races",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "speed",
                table: "Races",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "abilityScoreIncrease",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "age",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "alignment",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "languages",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "raceDescription",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "size",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "speed",
                table: "Races");

            migrationBuilder.CreateTable(
                name: "raceFeatures",
                columns: table => new
                {
                    featureID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    raceID = table.Column<int>(type: "int", nullable: false),
                    abilityScoreIncrease = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    alignment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    languages = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    raceDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    speed = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_raceFeatures", x => x.featureID);
                    table.ForeignKey(
                        name: "FK_raceFeatures_Races_raceID",
                        column: x => x.raceID,
                        principalTable: "Races",
                        principalColumn: "raceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_raceFeatures_raceID",
                table: "raceFeatures",
                column: "raceID",
                unique: true);
        }
    }
}
