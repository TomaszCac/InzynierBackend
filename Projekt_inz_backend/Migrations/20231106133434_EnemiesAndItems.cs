using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt_inz_backend.Migrations
{
    /// <inheritdoc />
    public partial class EnemiesAndItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enemies",
                columns: table => new
                {
                    EnemyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnemyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    owneruserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enemies", x => x.EnemyID);
                    table.ForeignKey(
                        name: "FK_Enemies_Users_owneruserID",
                        column: x => x.owneruserID,
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    itemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rarity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    weight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    owneruserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.itemID);
                    table.ForeignKey(
                        name: "FK_Item_Users_owneruserID",
                        column: x => x.owneruserID,
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "enemyActions",
                columns: table => new
                {
                    actionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usedByEnemyID = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "enemyFeatures",
                columns: table => new
                {
                    featureID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    race = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    armorClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    health = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    strength = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dexterity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    constitution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    inteligence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    wisdom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    charisma = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    enemyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enemyFeatures", x => x.featureID);
                    table.ForeignKey(
                        name: "FK_enemyFeatures_Enemies_enemyID",
                        column: x => x.enemyID,
                        principalTable: "Enemies",
                        principalColumn: "EnemyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enemies_owneruserID",
                table: "Enemies",
                column: "owneruserID");

            migrationBuilder.CreateIndex(
                name: "IX_enemyActions_usedByEnemyID",
                table: "enemyActions",
                column: "usedByEnemyID");

            migrationBuilder.CreateIndex(
                name: "IX_enemyFeatures_enemyID",
                table: "enemyFeatures",
                column: "enemyID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_owneruserID",
                table: "Item",
                column: "owneruserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "enemyActions");

            migrationBuilder.DropTable(
                name: "enemyFeatures");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Enemies");
        }
    }
}
