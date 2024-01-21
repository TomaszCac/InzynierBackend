using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt_inz_backend.Migrations
{
    /// <inheritdoc />
    public partial class ModelCharacter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "characters",
                columns: table => new
                {
                    characterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    characterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    characterLevel = table.Column<int>(type: "int", nullable: false),
                    characterExperience = table.Column<int>(type: "int", nullable: false),
                    characterAlignment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    characterBackground = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    characterStrength = table.Column<int>(type: "int", nullable: false),
                    characterDexterity = table.Column<int>(type: "int", nullable: false),
                    characterConstitution = table.Column<int>(type: "int", nullable: false),
                    characterInteligence = table.Column<int>(type: "int", nullable: false),
                    characterWisdom = table.Column<int>(type: "int", nullable: false),
                    characterCharisma = table.Column<int>(type: "int", nullable: false),
                    characterInspiration = table.Column<int>(type: "int", nullable: false),
                    characterProficencyBonus = table.Column<int>(type: "int", nullable: false),
                    characterSavingThrowStrength = table.Column<int>(type: "int", nullable: false),
                    characterSavingThrowDexterity = table.Column<int>(type: "int", nullable: false),
                    characterSavingThrowConstitution = table.Column<int>(type: "int", nullable: false),
                    characterSavingThrowInteligence = table.Column<int>(type: "int", nullable: false),
                    characterSavingThrowWisdom = table.Column<int>(type: "int", nullable: false),
                    characterSavingThrowCharisma = table.Column<int>(type: "int", nullable: false),
                    characterSkillAcrobatics = table.Column<int>(type: "int", nullable: false),
                    characterSkillAnimalHandling = table.Column<int>(type: "int", nullable: false),
                    characterSkillArcana = table.Column<int>(type: "int", nullable: false),
                    characterSkillAthletics = table.Column<int>(type: "int", nullable: false),
                    characterSkillDeception = table.Column<int>(type: "int", nullable: false),
                    characterSkillHistory = table.Column<int>(type: "int", nullable: false),
                    characterSkillInsight = table.Column<int>(type: "int", nullable: false),
                    characterSkillIntimidation = table.Column<int>(type: "int", nullable: false),
                    characterSkillInvestigation = table.Column<int>(type: "int", nullable: false),
                    characterSkillMedicine = table.Column<int>(type: "int", nullable: false),
                    characterSkillNature = table.Column<int>(type: "int", nullable: false),
                    characterSkillPerception = table.Column<int>(type: "int", nullable: false),
                    characterSkillPerformance = table.Column<int>(type: "int", nullable: false),
                    characterSkillPersuation = table.Column<int>(type: "int", nullable: false),
                    characterSkillReligion = table.Column<int>(type: "int", nullable: false),
                    characterSkillSleightOfHand = table.Column<int>(type: "int", nullable: false),
                    characterSkillStealth = table.Column<int>(type: "int", nullable: false),
                    characterSkillSurvival = table.Column<int>(type: "int", nullable: false),
                    characterSkills = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    characterArmorClass = table.Column<int>(type: "int", nullable: false),
                    characterInitiative = table.Column<int>(type: "int", nullable: false),
                    characterSpeed = table.Column<int>(type: "int", nullable: false),
                    characterHealthMax = table.Column<int>(type: "int", nullable: false),
                    characterHealthCurrent = table.Column<int>(type: "int", nullable: false),
                    characterHealthTemp = table.Column<int>(type: "int", nullable: false),
                    characterHitDiceTotal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    characterHitDice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    characterDeathSuccess = table.Column<int>(type: "int", nullable: false),
                    characterDeathFail = table.Column<int>(type: "int", nullable: false),
                    characterPersonalityTraits = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    characterIdeals = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    characterBonds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    characterFlaws = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    owneruserID = table.Column<int>(type: "int", nullable: false),
                    DndClassclassId = table.Column<int>(type: "int", nullable: true),
                    raceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_characters", x => x.characterId);
                    table.ForeignKey(
                        name: "FK_characters_Races_raceId",
                        column: x => x.raceId,
                        principalTable: "Races",
                        principalColumn: "raceId");
                    table.ForeignKey(
                        name: "FK_characters_Users_owneruserID",
                        column: x => x.owneruserID,
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_characters_dndClasses_DndClassclassId",
                        column: x => x.DndClassclassId,
                        principalTable: "dndClasses",
                        principalColumn: "classId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_characters_DndClassclassId",
                table: "characters",
                column: "DndClassclassId");

            migrationBuilder.CreateIndex(
                name: "IX_characters_owneruserID",
                table: "characters",
                column: "owneruserID");

            migrationBuilder.CreateIndex(
                name: "IX_characters_raceId",
                table: "characters",
                column: "raceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "characters");
        }
    }
}
