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
                    tableHeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tableData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    spellTableHeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    spellTableData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    inheritedClassID = table.Column<int>(type: "int", nullable: true),
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
                    owneruserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dndClasses", x => x.classID);
                    table.ForeignKey(
                        name: "FK_dndClasses_Users_owneruserID",
                        column: x => x.owneruserID,
                        principalTable: "Users",
                        principalColumn: "userID");
                });

            migrationBuilder.CreateTable(
                name: "Enemies",
                columns: table => new
                {
                    EnemyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnemyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    race = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    armorClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    health = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    strength = table.Column<int>(type: "int", nullable: false),
                    dexterity = table.Column<int>(type: "int", nullable: false),
                    constitution = table.Column<int>(type: "int", nullable: false),
                    inteligence = table.Column<int>(type: "int", nullable: false),
                    wisdom = table.Column<int>(type: "int", nullable: false),
                    charisma = table.Column<int>(type: "int", nullable: false),
                    speed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    savingThrows = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    skills = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    immunes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    resistances = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vulnerabilities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    senses = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    languages = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dangerLvl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    proficencyBonus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    owneruserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enemies", x => x.EnemyID);
                    table.ForeignKey(
                        name: "FK_Enemies_Users_owneruserID",
                        column: x => x.owneruserID,
                        principalTable: "Users",
                        principalColumn: "userID");
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    itemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rarity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    weight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    owneruserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.itemID);
                    table.ForeignKey(
                        name: "FK_Items_Users_owneruserID",
                        column: x => x.owneruserID,
                        principalTable: "Users",
                        principalColumn: "userID");
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    raceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    raceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tableHeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tableData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    inheritedRaceID = table.Column<int>(type: "int", nullable: true),
                    abilityScoreIncrease = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    alignment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    speed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    raceDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    languages = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    owneruserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.raceID);
                    table.ForeignKey(
                        name: "FK_Races_Users_owneruserID",
                        column: x => x.owneruserID,
                        principalTable: "Users",
                        principalColumn: "userID");
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
                    owneruserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spells", x => x.spellID);
                    table.ForeignKey(
                        name: "FK_Spells_Users_owneruserID",
                        column: x => x.owneruserID,
                        principalTable: "Users",
                        principalColumn: "userID");
                });

            migrationBuilder.CreateTable(
                name: "customDndClassFeatures",
                columns: table => new
                {
                    featureID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usedByclassID = table.Column<int>(type: "int", nullable: false),
                    featureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "dndSubclasses",
                columns: table => new
                {
                    subclassID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subclassName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubclassDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    inheritedClassclassID = table.Column<int>(type: "int", nullable: false),
                    owneruserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dndSubclasses", x => x.subclassID);
                    table.ForeignKey(
                        name: "FK_dndSubclasses_Users_owneruserID",
                        column: x => x.owneruserID,
                        principalTable: "Users",
                        principalColumn: "userID");
                    table.ForeignKey(
                        name: "FK_dndSubclasses_dndClasses_inheritedClassclassID",
                        column: x => x.inheritedClassclassID,
                        principalTable: "dndClasses",
                        principalColumn: "classID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "enemyActions",
                columns: table => new
                {
                    actionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usedByEnemyID = table.Column<int>(type: "int", nullable: false),
                    actionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    actionDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    actionType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enemyActions", x => x.actionID);
                    table.ForeignKey(
                        name: "FK_enemyActions_Enemies_usedByEnemyID",
                        column: x => x.usedByEnemyID,
                        principalTable: "Enemies",
                        principalColumn: "EnemyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "customRaceFeatures",
                columns: table => new
                {
                    featureID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usedByraceID = table.Column<int>(type: "int", nullable: false),
                    featureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "customDndSubclassFeatures",
                columns: table => new
                {
                    featureID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usedBysubclassID = table.Column<int>(type: "int", nullable: false),
                    featureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    featureDesc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customDndSubclassFeatures", x => x.featureID);
                    table.ForeignKey(
                        name: "FK_customDndSubclassFeatures_dndSubclasses_usedBysubclassID",
                        column: x => x.usedBysubclassID,
                        principalTable: "dndSubclasses",
                        principalColumn: "subclassID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_customDndClassFeatures_usedByclassID",
                table: "customDndClassFeatures",
                column: "usedByclassID");

            migrationBuilder.CreateIndex(
                name: "IX_customDndSubclassFeatures_usedBysubclassID",
                table: "customDndSubclassFeatures",
                column: "usedBysubclassID");

            migrationBuilder.CreateIndex(
                name: "IX_customRaceFeatures_usedByraceID",
                table: "customRaceFeatures",
                column: "usedByraceID");

            migrationBuilder.CreateIndex(
                name: "IX_dndClasses_owneruserID",
                table: "dndClasses",
                column: "owneruserID");

            migrationBuilder.CreateIndex(
                name: "IX_dndSubclasses_inheritedClassclassID",
                table: "dndSubclasses",
                column: "inheritedClassclassID");

            migrationBuilder.CreateIndex(
                name: "IX_dndSubclasses_owneruserID",
                table: "dndSubclasses",
                column: "owneruserID");

            migrationBuilder.CreateIndex(
                name: "IX_Enemies_owneruserID",
                table: "Enemies",
                column: "owneruserID");

            migrationBuilder.CreateIndex(
                name: "IX_enemyActions_usedByEnemyID",
                table: "enemyActions",
                column: "usedByEnemyID");

            migrationBuilder.CreateIndex(
                name: "IX_Items_owneruserID",
                table: "Items",
                column: "owneruserID");

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
                name: "customDndSubclassFeatures");

            migrationBuilder.DropTable(
                name: "customRaceFeatures");

            migrationBuilder.DropTable(
                name: "enemyActions");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "spellsForClasses");

            migrationBuilder.DropTable(
                name: "dndSubclasses");

            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropTable(
                name: "Enemies");

            migrationBuilder.DropTable(
                name: "Spells");

            migrationBuilder.DropTable(
                name: "dndClasses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
