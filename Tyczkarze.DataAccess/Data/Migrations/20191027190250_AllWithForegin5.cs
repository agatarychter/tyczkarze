using Microsoft.EntityFrameworkCore.Migrations;

namespace Tyczkarze.Migrations
{
    public partial class AllWithForegin5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseParamDone_ExerciseParamType_ExerciseParamTypeIdParamType",
                table: "ExerciseParamDone");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseParamDone_ExerciseParamTypeIdParamType",
                table: "ExerciseParamDone");

            migrationBuilder.DropColumn(
                name: "ExerciseParamTypeIdParamType",
                table: "ExerciseParamDone");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseParamDone_IdExerciseParamType",
                table: "ExerciseParamDone",
                column: "IdExerciseParamType");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseParamDone_ExerciseParamType_IdExerciseParamType",
                table: "ExerciseParamDone",
                column: "IdExerciseParamType",
                principalTable: "ExerciseParamType",
                principalColumn: "IdParamType",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseParamDone_ExerciseParamType_IdExerciseParamType",
                table: "ExerciseParamDone");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseParamDone_IdExerciseParamType",
                table: "ExerciseParamDone");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseParamTypeIdParamType",
                table: "ExerciseParamDone",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseParamDone_ExerciseParamTypeIdParamType",
                table: "ExerciseParamDone",
                column: "ExerciseParamTypeIdParamType");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseParamDone_ExerciseParamType_ExerciseParamTypeIdParamType",
                table: "ExerciseParamDone",
                column: "ExerciseParamTypeIdParamType",
                principalTable: "ExerciseParamType",
                principalColumn: "IdParamType",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
