using Microsoft.EntityFrameworkCore.Migrations;

namespace Tyczkarze.Migrations
{
    public partial class AllWithForegin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseParam_ExerciseParamType_ExerciseParamTypeIdParamType",
                table: "ExerciseParam");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseParam_ExerciseDone_IdExerciseDone",
                table: "ExerciseParam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseParam",
                table: "ExerciseParam");

            migrationBuilder.RenameTable(
                name: "ExerciseParam",
                newName: "ExerciseParamDone");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseParam_IdExerciseDone",
                table: "ExerciseParamDone",
                newName: "IX_ExerciseParamDone_IdExerciseDone");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseParam_ExerciseParamTypeIdParamType",
                table: "ExerciseParamDone",
                newName: "IX_ExerciseParamDone_ExerciseParamTypeIdParamType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseParamDone",
                table: "ExerciseParamDone",
                column: "IdExerciseParam");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseParamDone_ExerciseParamType_ExerciseParamTypeIdParamType",
                table: "ExerciseParamDone",
                column: "ExerciseParamTypeIdParamType",
                principalTable: "ExerciseParamType",
                principalColumn: "IdParamType",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseParamDone_ExerciseDone_IdExerciseDone",
                table: "ExerciseParamDone",
                column: "IdExerciseDone",
                principalTable: "ExerciseDone",
                principalColumn: "IdExerciseDone",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseParamDone_ExerciseParamType_ExerciseParamTypeIdParamType",
                table: "ExerciseParamDone");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseParamDone_ExerciseDone_IdExerciseDone",
                table: "ExerciseParamDone");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseParamDone",
                table: "ExerciseParamDone");

            migrationBuilder.RenameTable(
                name: "ExerciseParamDone",
                newName: "ExerciseParam");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseParamDone_IdExerciseDone",
                table: "ExerciseParam",
                newName: "IX_ExerciseParam_IdExerciseDone");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseParamDone_ExerciseParamTypeIdParamType",
                table: "ExerciseParam",
                newName: "IX_ExerciseParam_ExerciseParamTypeIdParamType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseParam",
                table: "ExerciseParam",
                column: "IdExerciseParam");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseParam_ExerciseParamType_ExerciseParamTypeIdParamType",
                table: "ExerciseParam",
                column: "ExerciseParamTypeIdParamType",
                principalTable: "ExerciseParamType",
                principalColumn: "IdParamType",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseParam_ExerciseDone_IdExerciseDone",
                table: "ExerciseParam",
                column: "IdExerciseDone",
                principalTable: "ExerciseDone",
                principalColumn: "IdExerciseDone",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
