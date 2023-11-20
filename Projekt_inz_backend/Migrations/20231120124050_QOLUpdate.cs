using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt_inz_backend.Migrations
{
    /// <inheritdoc />
    public partial class QOLUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customDndClassFeatures_dndClasses_usedByclassID",
                table: "customDndClassFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_customDndSubclassFeatures_dndSubclasses_usedBysubclassID",
                table: "customDndSubclassFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_customRaceFeatures_Races_usedByraceID",
                table: "customRaceFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_dndSubclasses_dndClasses_inheritedClassclassID",
                table: "dndSubclasses");

            migrationBuilder.DropForeignKey(
                name: "FK_enemyActions_Enemies_usedByEnemyID",
                table: "enemyActions");

            migrationBuilder.RenameColumn(
                name: "enemySpeed",
                table: "Races",
                newName: "raceTableHeader");

            migrationBuilder.RenameColumn(
                name: "enemySize",
                table: "Races",
                newName: "raceTableData");

            migrationBuilder.RenameColumn(
                name: "enemyLanguages",
                table: "Races",
                newName: "raceSpeed");

            migrationBuilder.RenameColumn(
                name: "classTableHeader",
                table: "Races",
                newName: "raceSize");

            migrationBuilder.RenameColumn(
                name: "classTableData",
                table: "Races",
                newName: "raceLanguages");

            migrationBuilder.RenameColumn(
                name: "usedByEnemyID",
                table: "enemyActions",
                newName: "usedByenemyId");

            migrationBuilder.RenameIndex(
                name: "IX_enemyActions_usedByEnemyID",
                table: "enemyActions",
                newName: "IX_enemyActions_usedByenemyId");

            migrationBuilder.RenameColumn(
                name: "enemyace",
                table: "Enemies",
                newName: "enemySkills");

            migrationBuilder.RenameColumn(
                name: "classSkills",
                table: "Enemies",
                newName: "enemySavingThrows");

            migrationBuilder.RenameColumn(
                name: "classSavingThrows",
                table: "Enemies",
                newName: "enemyRace");

            migrationBuilder.RenameColumn(
                name: "inheritedClassclassID",
                table: "dndSubclasses",
                newName: "inheritedClassclassId");

            migrationBuilder.RenameIndex(
                name: "IX_dndSubclasses_inheritedClassclassID",
                table: "dndSubclasses",
                newName: "IX_dndSubclasses_inheritedClassclassId");

            migrationBuilder.RenameColumn(
                name: "usedByraceID",
                table: "customRaceFeatures",
                newName: "usedByraceId");

            migrationBuilder.RenameIndex(
                name: "IX_customRaceFeatures_usedByraceID",
                table: "customRaceFeatures",
                newName: "IX_customRaceFeatures_usedByraceId");

            migrationBuilder.RenameColumn(
                name: "usedBysubclassID",
                table: "customDndSubclassFeatures",
                newName: "usedBysubclassId");

            migrationBuilder.RenameIndex(
                name: "IX_customDndSubclassFeatures_usedBysubclassID",
                table: "customDndSubclassFeatures",
                newName: "IX_customDndSubclassFeatures_usedBysubclassId");

            migrationBuilder.RenameColumn(
                name: "usedByclassID",
                table: "customDndClassFeatures",
                newName: "usedByclassId");

            migrationBuilder.RenameIndex(
                name: "IX_customDndClassFeatures_usedByclassID",
                table: "customDndClassFeatures",
                newName: "IX_customDndClassFeatures_usedByclassId");

            migrationBuilder.AddForeignKey(
                name: "FK_customDndClassFeatures_dndClasses_usedByclassId",
                table: "customDndClassFeatures",
                column: "usedByclassId",
                principalTable: "dndClasses",
                principalColumn: "classId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_customDndSubclassFeatures_dndSubclasses_usedBysubclassId",
                table: "customDndSubclassFeatures",
                column: "usedBysubclassId",
                principalTable: "dndSubclasses",
                principalColumn: "subclassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_customRaceFeatures_Races_usedByraceId",
                table: "customRaceFeatures",
                column: "usedByraceId",
                principalTable: "Races",
                principalColumn: "raceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dndSubclasses_dndClasses_inheritedClassclassId",
                table: "dndSubclasses",
                column: "inheritedClassclassId",
                principalTable: "dndClasses",
                principalColumn: "classId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_enemyActions_Enemies_usedByenemyId",
                table: "enemyActions",
                column: "usedByenemyId",
                principalTable: "Enemies",
                principalColumn: "enemyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customDndClassFeatures_dndClasses_usedByclassId",
                table: "customDndClassFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_customDndSubclassFeatures_dndSubclasses_usedBysubclassId",
                table: "customDndSubclassFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_customRaceFeatures_Races_usedByraceId",
                table: "customRaceFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_dndSubclasses_dndClasses_inheritedClassclassId",
                table: "dndSubclasses");

            migrationBuilder.DropForeignKey(
                name: "FK_enemyActions_Enemies_usedByenemyId",
                table: "enemyActions");

            migrationBuilder.RenameColumn(
                name: "raceTableHeader",
                table: "Races",
                newName: "enemySpeed");

            migrationBuilder.RenameColumn(
                name: "raceTableData",
                table: "Races",
                newName: "enemySize");

            migrationBuilder.RenameColumn(
                name: "raceSpeed",
                table: "Races",
                newName: "enemyLanguages");

            migrationBuilder.RenameColumn(
                name: "raceSize",
                table: "Races",
                newName: "classTableHeader");

            migrationBuilder.RenameColumn(
                name: "raceLanguages",
                table: "Races",
                newName: "classTableData");

            migrationBuilder.RenameColumn(
                name: "usedByenemyId",
                table: "enemyActions",
                newName: "usedByEnemyID");

            migrationBuilder.RenameIndex(
                name: "IX_enemyActions_usedByenemyId",
                table: "enemyActions",
                newName: "IX_enemyActions_usedByEnemyID");

            migrationBuilder.RenameColumn(
                name: "enemySkills",
                table: "Enemies",
                newName: "enemyace");

            migrationBuilder.RenameColumn(
                name: "enemySavingThrows",
                table: "Enemies",
                newName: "classSkills");

            migrationBuilder.RenameColumn(
                name: "enemyRace",
                table: "Enemies",
                newName: "classSavingThrows");

            migrationBuilder.RenameColumn(
                name: "inheritedClassclassId",
                table: "dndSubclasses",
                newName: "inheritedClassclassID");

            migrationBuilder.RenameIndex(
                name: "IX_dndSubclasses_inheritedClassclassId",
                table: "dndSubclasses",
                newName: "IX_dndSubclasses_inheritedClassclassID");

            migrationBuilder.RenameColumn(
                name: "usedByraceId",
                table: "customRaceFeatures",
                newName: "usedByraceID");

            migrationBuilder.RenameIndex(
                name: "IX_customRaceFeatures_usedByraceId",
                table: "customRaceFeatures",
                newName: "IX_customRaceFeatures_usedByraceID");

            migrationBuilder.RenameColumn(
                name: "usedBysubclassId",
                table: "customDndSubclassFeatures",
                newName: "usedBysubclassID");

            migrationBuilder.RenameIndex(
                name: "IX_customDndSubclassFeatures_usedBysubclassId",
                table: "customDndSubclassFeatures",
                newName: "IX_customDndSubclassFeatures_usedBysubclassID");

            migrationBuilder.RenameColumn(
                name: "usedByclassId",
                table: "customDndClassFeatures",
                newName: "usedByclassID");

            migrationBuilder.RenameIndex(
                name: "IX_customDndClassFeatures_usedByclassId",
                table: "customDndClassFeatures",
                newName: "IX_customDndClassFeatures_usedByclassID");

            migrationBuilder.AddForeignKey(
                name: "FK_customDndClassFeatures_dndClasses_usedByclassID",
                table: "customDndClassFeatures",
                column: "usedByclassID",
                principalTable: "dndClasses",
                principalColumn: "classId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_customDndSubclassFeatures_dndSubclasses_usedBysubclassID",
                table: "customDndSubclassFeatures",
                column: "usedBysubclassID",
                principalTable: "dndSubclasses",
                principalColumn: "subclassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_customRaceFeatures_Races_usedByraceID",
                table: "customRaceFeatures",
                column: "usedByraceID",
                principalTable: "Races",
                principalColumn: "raceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dndSubclasses_dndClasses_inheritedClassclassID",
                table: "dndSubclasses",
                column: "inheritedClassclassID",
                principalTable: "dndClasses",
                principalColumn: "classId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_enemyActions_Enemies_usedByEnemyID",
                table: "enemyActions",
                column: "usedByEnemyID",
                principalTable: "Enemies",
                principalColumn: "enemyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
