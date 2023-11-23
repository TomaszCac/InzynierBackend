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
                    classId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    className = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    classTableHeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    classTableData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    spellTableHeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    spellTableData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    inheritedClassID = table.Column<int>(type: "int", nullable: true),
                    classDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    classMulticlassReq = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    classHitDice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    classHitPointsAtFirst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    classHitPointsAtHigh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    classArmorProficency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    classWeaponProficency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    classToolsProficency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    classSavingThrows = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    classSkills = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    classEquipment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    owneruserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dndClasses", x => x.classId);
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
                    enemyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    enemyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enemySize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enemyRace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enemyArmorClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enemyHealth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enemyStrength = table.Column<int>(type: "int", nullable: false),
                    enemyDexterity = table.Column<int>(type: "int", nullable: false),
                    enemyConstitution = table.Column<int>(type: "int", nullable: false),
                    enemyInteligence = table.Column<int>(type: "int", nullable: false),
                    enemyWisdom = table.Column<int>(type: "int", nullable: false),
                    enemyCharisma = table.Column<int>(type: "int", nullable: false),
                    enemySpeed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enemySavingThrows = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enemySkills = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enemyImmunes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enemyResistances = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enemyVulnerabilities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enemySenses = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enemyLanguages = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enemyDangerLvl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enemyProficencyBonus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    owneruserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enemies", x => x.enemyId);
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
                    itemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    itemRarity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    itemDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    itemWeight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    owneruserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.itemId);
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
                    raceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    raceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    raceTableHeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    raceTableData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    inheritedRaceID = table.Column<int>(type: "int", nullable: true),
                    raceAbilityScoreIncrease = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    raceAge = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    raceAlignment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    raceSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    raceSpeed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    raceDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    raceLanguages = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    owneruserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.raceId);
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
                    spellId = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_Spells", x => x.spellId);
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
                    featureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usedByclassId = table.Column<int>(type: "int", nullable: false),
                    featureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    featureDesc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customDndClassFeatures", x => x.featureId);
                    table.ForeignKey(
                        name: "FK_customDndClassFeatures_dndClasses_usedByclassId",
                        column: x => x.usedByclassId,
                        principalTable: "dndClasses",
                        principalColumn: "classId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dndSubclasses",
                columns: table => new
                {
                    subclassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subclassName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subclassDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    inheritedClassclassId = table.Column<int>(type: "int", nullable: false),
                    owneruserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dndSubclasses", x => x.subclassId);
                    table.ForeignKey(
                        name: "FK_dndSubclasses_Users_owneruserID",
                        column: x => x.owneruserID,
                        principalTable: "Users",
                        principalColumn: "userID");
                    table.ForeignKey(
                        name: "FK_dndSubclasses_dndClasses_inheritedClassclassId",
                        column: x => x.inheritedClassclassId,
                        principalTable: "dndClasses",
                        principalColumn: "classId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "enemyActions",
                columns: table => new
                {
                    actionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usedByenemyId = table.Column<int>(type: "int", nullable: false),
                    actionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    actionDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    actionType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enemyActions", x => x.actionId);
                    table.ForeignKey(
                        name: "FK_enemyActions_Enemies_usedByenemyId",
                        column: x => x.usedByenemyId,
                        principalTable: "Enemies",
                        principalColumn: "enemyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "customRaceFeatures",
                columns: table => new
                {
                    featureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usedByraceId = table.Column<int>(type: "int", nullable: false),
                    featureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    featureDesc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customRaceFeatures", x => x.featureId);
                    table.ForeignKey(
                        name: "FK_customRaceFeatures_Races_usedByraceId",
                        column: x => x.usedByraceId,
                        principalTable: "Races",
                        principalColumn: "raceId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "customDndSubclassFeatures",
                columns: table => new
                {
                    featureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usedBysubclassId = table.Column<int>(type: "int", nullable: false),
                    featureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    featureDesc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customDndSubclassFeatures", x => x.featureId);
                    table.ForeignKey(
                        name: "FK_customDndSubclassFeatures_dndSubclasses_usedBysubclassId",
                        column: x => x.usedBysubclassId,
                        principalTable: "dndSubclasses",
                        principalColumn: "subclassId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_customDndClassFeatures_usedByclassId",
                table: "customDndClassFeatures",
                column: "usedByclassId");

            migrationBuilder.CreateIndex(
                name: "IX_customDndSubclassFeatures_usedBysubclassId",
                table: "customDndSubclassFeatures",
                column: "usedBysubclassId");

            migrationBuilder.CreateIndex(
                name: "IX_customRaceFeatures_usedByraceId",
                table: "customRaceFeatures",
                column: "usedByraceId");

            migrationBuilder.CreateIndex(
                name: "IX_dndClasses_owneruserID",
                table: "dndClasses",
                column: "owneruserID");

            migrationBuilder.CreateIndex(
                name: "IX_dndSubclasses_inheritedClassclassId",
                table: "dndSubclasses",
                column: "inheritedClassclassId");

            migrationBuilder.CreateIndex(
                name: "IX_dndSubclasses_owneruserID",
                table: "dndSubclasses",
                column: "owneruserID");

            migrationBuilder.CreateIndex(
                name: "IX_Enemies_owneruserID",
                table: "Enemies",
                column: "owneruserID");

            migrationBuilder.CreateIndex(
                name: "IX_enemyActions_usedByenemyId",
                table: "enemyActions",
                column: "usedByenemyId");

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
                name: "IX_spellsForClasses_classId",
                table: "spellsForClasses",
                column: "classId");

            migrationBuilder.CreateIndex(
                name: "IX_spellsForSubclasses_subclassId",
                table: "spellsForSubclasses",
                column: "subclassId");
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
                name: "spellsForSubclasses");

            migrationBuilder.DropTable(
                name: "Races");

            migrationBuilder.DropTable(
                name: "Enemies");

            migrationBuilder.DropTable(
                name: "Spells");

            migrationBuilder.DropTable(
                name: "dndSubclasses");

            migrationBuilder.DropTable(
                name: "dndClasses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
