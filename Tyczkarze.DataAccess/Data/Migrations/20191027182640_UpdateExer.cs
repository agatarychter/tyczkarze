using Microsoft.EntityFrameworkCore.Migrations;

namespace Tyczkarze.Migrations
{
    public partial class UpdateExer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdTrainer",
                table: "Training");

            migrationBuilder.AddColumn<int>(
                name: "JumpTypeIdJumpType",
                table: "Jump",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jump_JumpTypeIdJumpType",
                table: "Jump",
                column: "JumpTypeIdJumpType");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseParam_IdExerciseDone",
                table: "ExerciseParam",
                column: "IdExerciseDone");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseParam_ExerciseDone_IdExerciseDone",
                table: "ExerciseParam",
                column: "IdExerciseDone",
                principalTable: "ExerciseDone",
                principalColumn: "IdExerciseDone",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jump_JumpType_JumpTypeIdJumpType",
                table: "Jump",
                column: "JumpTypeIdJumpType",
                principalTable: "JumpType",
                principalColumn: "IdJumpType",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseParam_ExerciseDone_IdExerciseDone",
                table: "ExerciseParam");

            migrationBuilder.DropForeignKey(
                name: "FK_Jump_JumpType_JumpTypeIdJumpType",
                table: "Jump");

            migrationBuilder.DropIndex(
                name: "IX_Jump_JumpTypeIdJumpType",
                table: "Jump");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseParam_IdExerciseDone",
                table: "ExerciseParam");

            migrationBuilder.DropColumn(
                name: "JumpTypeIdJumpType",
                table: "Jump");

            migrationBuilder.AddColumn<int>(
                name: "IdTrainer",
                table: "Training",
                nullable: false,
                defaultValue: 0);
        }
    }
}
