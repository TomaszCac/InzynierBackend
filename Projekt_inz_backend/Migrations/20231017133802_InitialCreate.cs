using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt_inz_backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userID);
                });

            migrationBuilder.CreateTable(
                name: "dndClasses",
                columns: table => new
                {
                    classID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    className = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tableData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    inheritedClassID = table.Column<int>(type: "int", nullable: true),
                    owneruserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dndClasses", x => x.classID);
                    table.ForeignKey(
                        name: "FK_dndClasses_Users_owneruserID",
                        column: x => x.owneruserID,
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    raceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    raceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tableData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    inheritedRaceID = table.Column<int>(type: "int", nullable: true),
                    owneruserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.raceID);
                    table.ForeignKey(
                        name: "FK_Races_Users_owneruserID",
                        column: x => x.owneruserID,
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Spells",
                columns: table => new
                {
                    spellID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    spellName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    spellSchool = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    spellCasting = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    spellRange = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    spellDuration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    spellComponents = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    spellLevel = table.Column<int>(type: "int", nullable: false),
                    spellDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    spellAHL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    owneruserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spells", x => x.spellID);
                    table.ForeignKey(
                        name: "FK_Spells_Users_owneruserID",
                        column: x => x.owneruserID,
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "customDndClassFeatures",
                columns: table => new
                {
                    featureID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usedByclassID = table.Column<int>(type: "int", nullable: false),
                    featureDesc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customDndClassFeatures", x => x.featureID);
                    table.ForeignKey(
                        name: "FK_customDndClassFeatures_dndClasses_usedByclassID",
                        column: x => x.usedByclassID,
                        principalTable: "dndClasses",
                        principalColumn: "classID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dndClassFeatures",
                columns: table => new
                {
                    featureID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    classDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    multiclassReq = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hitDice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hitPointsAtFirst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hitPointsAtHigh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    armorProficency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    weaponProficency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    toolsProficency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    savingThrows = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    skills = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    equipment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DndClassID = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "customRaceFeatures",
                columns: table => new
                {
                    featureID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usedByraceID = table.Column<int>(type: "int", nullable: false),
                    featureDesc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customRaceFeatures", x => x.featureID);
                    table.ForeignKey(
                        name: "FK_customRaceFeatures_Races_usedByraceID",
                        column: x => x.usedByraceID,
                        principalTable: "Races",
                        principalColumn: "raceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "raceFeatures",
                columns: table => new
                {
                    featureID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    abilityScoreIncrease = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    alignment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    speed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    raceDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    raceID = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "spellsForClasses",
                columns: table => new
                {
                    spellID = table.Column<int>(type: "int", nullable: false),
                    classID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spellsForClasses", x => new { x.spellID, x.classID });
                    table.ForeignKey(
                        name: "FK_spellsForClasses_Spells_spellID",
                        column: x => x.spellID,
                        principalTable: "Spells",
                        principalColumn: "spellID");
                    table.ForeignKey(
                        name: "FK_spellsForClasses_dndClasses_classID",
                        column: x => x.classID,
                        principalTable: "dndClasses",
                        principalColumn: "classID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_customDndClassFeatures_usedByclassID",
                table: "customDndClassFeatures",
                column: "usedByclassID");

            migrationBuilder.CreateIndex(
                name: "IX_customRaceFeatures_usedByraceID",
                table: "customRaceFeatures",
                column: "usedByraceID");

            migrationBuilder.CreateIndex(
                name: "IX_dndClasses_owneruserID",
                table: "dndClasses",
                column: "owneruserID");

            migrationBuilder.CreateIndex(
                name: "IX_dndClassFeatures_DndClassID",
                table: "dndClassFeatures",
                column: "DndClassID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_raceFeatures_raceID",
                table: "raceFeatures",
                column: "raceID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Races_owneruserID",
                table: "Races",
                column: "owneruserID");

            migrationBuilder.CreateIndex(
                name: "IX_Spells_owneruserID",
                table: "Spells",
                column: "owneruserID");

            migrationBuilder.CreateIndex(
                name: "IX_spellsForClasses_classID",
                table: "spellsForClasses",
                column: "classID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customDndClassFeatures");

            migrationBuilder.DropTable(
                name: "customRaceFeatures");

            migrationBuilder.DropTable(
                name: "dndClassFeatures");

            migrationBuilder.DropTable(
                name: "raceFeatures");

            migrationBuilder.DropTable(
                name: "spellsForClasses");

            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropTable(
                name: "Spells");

            migrationBuilder.DropTable(
                name: "dndClasses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
