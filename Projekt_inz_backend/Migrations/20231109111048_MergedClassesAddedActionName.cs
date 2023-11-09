using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt_inz_backend.Migrations
{
    /// <inheritdoc />
    public partial class MergedClassesAddedActionName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dndClassFeatures");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "enemyActions",
                newName: "actionName");

            migrationBuilder.AddColumn<string>(
                name: "actionDesc",
                table: "enemyActions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "armorProficency",
                table: "dndClasses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "classDescription",
                table: "dndClasses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "equipment",
                table: "dndClasses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "hitDice",
                table: "dndClasses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "hitPointsAtFirst",
                table: "dndClasses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "hitPointsAtHigh",
                table: "dndClasses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "multiclassReq",
                table: "dndClasses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "savingThrows",
                table: "dndClasses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "skills",
                table: "dndClasses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "toolsProficency",
                table: "dndClasses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "weaponProficency",
                table: "dndClasses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "actionDesc",
                table: "enemyActions");

            migrationBuilder.DropColumn(
                name: "armorProficency",
                table: "dndClasses");

            migrationBuilder.DropColumn(
                name: "classDescription",
                table: "dndClasses");

            migrationBuilder.DropColumn(
                name: "equipment",
                table: "dndClasses");

            migrationBuilder.DropColumn(
                name: "hitDice",
                table: "dndClasses");

            migrationBuilder.DropColumn(
                name: "hitPointsAtFirst",
                table: "dndClasses");

            migrationBuilder.DropColumn(
                name: "hitPointsAtHigh",
                table: "dndClasses");

            migrationBuilder.DropColumn(
                name: "multiclassReq",
                table: "dndClasses");

            migrationBuilder.DropColumn(
                name: "savingThrows",
                table: "dndClasses");

            migrationBuilder.DropColumn(
                name: "skills",
                table: "dndClasses");

            migrationBuilder.DropColumn(
                name: "toolsProficency",
                table: "dndClasses");

            migrationBuilder.DropColumn(
                name: "weaponProficency",
                table: "dndClasses");

            migrationBuilder.RenameColumn(
                name: "actionName",
                table: "enemyActions",
                newName: "description");

            migrationBuilder.CreateTable(
                name: "dndClassFeatures",
                columns: table => new
                {
                    featureID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DndClassID = table.Column<int>(type: "int", nullable: false),
                    armorProficency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    classDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    equipment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hitDice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hitPointsAtFirst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hitPointsAtHigh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    multiclassReq = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    savingThrows = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    skills = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    toolsProficency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    weaponProficency = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dndClassFeatures", x => x.featureID);
                    table.ForeignKey(
                        name: "FK_dndClassFeatures_dndClasses_DndClassID",
                        column: x => x.DndClassID,
                        principalTable: "dndClasses",
                        principalColumn: "classID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dndClassFeatures_DndClassID",
                table: "dndClassFeatures",
                column: "DndClassID",
                unique: true);
        }
    }
}
