using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt_inz_backend.Migrations
{
    /// <inheritdoc />
    public partial class DeleteSpellForClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "spellsForClasses");

            migrationBuilder.DropTable(
                name: "spellsForSubclasses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "spellsForClasses",
                columns: table => new
                {
                    spellId = table.Column<int>(type: "int", nullable: false),
                    classId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spellsForClasses", x => new { x.spellId, x.classId });
                    table.ForeignKey(
                        name: "FK_spellsForClasses_Spells_spellId",
                        column: x => x.spellId,
                        principalTable: "Spells",
                        principalColumn: "spellId");
                    table.ForeignKey(
                        name: "FK_spellsForClasses_dndClasses_classId",
                        column: x => x.classId,
                        principalTable: "dndClasses",
                        principalColumn: "classId");
                });

            migrationBuilder.CreateTable(
                name: "spellsForSubclasses",
                columns: table => new
                {
                    spellId = table.Column<int>(type: "int", nullable: false),
                    subclassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spellsForSubclasses", x => new { x.spellId, x.subclassId });
                    table.ForeignKey(
                        name: "FK_spellsForSubclasses_Spells_spellId",
                        column: x => x.spellId,
                        principalTable: "Spells",
                        principalColumn: "spellId");
                    table.ForeignKey(
                        name: "FK_spellsForSubclasses_dndSubclasses_subclassId",
                        column: x => x.subclassId,
                        principalTable: "dndSubclasses",
                        principalColumn: "subclassId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_spellsForClasses_classId",
                table: "spellsForClasses",
                column: "classId");

            migrationBuilder.CreateIndex(
                name: "IX_spellsForSubclasses_subclassId",
                table: "spellsForSubclasses",
                column: "subclassId");
        }
    }
}
