using Microsoft.EntityFrameworkCore.Migrations;

namespace Tyczkarze.Migrations
{
    public partial class AllWithForegin3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Jump_IdJumpStatus1",
                table: "Jump",
                column: "IdJumpStatus1");

            migrationBuilder.CreateIndex(
                name: "IX_Jump_IdJumpStatus2",
                table: "Jump",
                column: "IdJumpStatus2");

            migrationBuilder.CreateIndex(
                name: "IX_Jump_IdJumpStatus3",
                table: "Jump",
                column: "IdJumpStatus3");

            migrationBuilder.CreateIndex(
                name: "IX_Jump_IdPole3",
                table: "Jump",
                column: "IdPole3");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseDictTypeParam_IdExerciseType",
                table: "ExerciseDictTypeParam",
                column: "IdExerciseType");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseDictTypeParam_ExerciseParamType_IdExerciseParamType",
                table: "ExerciseDictTypeParam",
                column: "IdExerciseParamType",
                principalTable: "ExerciseParamType",
                principalColumn: "IdParamType",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseDictTypeParam_ExerciseType_IdExerciseType",
                table: "ExerciseDictTypeParam",
                column: "IdExerciseType",
                principalTable: "ExerciseType",
                principalColumn: "IdExerciseType",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jump_JumpStatus_IdJumpStatus1",
                table: "Jump",
                column: "IdJumpStatus1",
                principalTable: "JumpStatus",
                principalColumn: "IdJumpStatus",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jump_JumpStatus_IdJumpStatus2",
                table: "Jump",
                column: "IdJumpStatus2",
                principalTable: "JumpStatus",
                principalColumn: "IdJumpStatus",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jump_JumpStatus_IdJumpStatus3",
                table: "Jump",
                column: "IdJumpStatus3",
                principalTable: "JumpStatus",
                principalColumn: "IdJumpStatus",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jump_Pole_IdPole3",
                table: "Jump",
                column: "IdPole3",
                principalTable: "Pole",
                principalColumn: "IdPole",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseDictTypeParam_ExerciseParamType_IdExerciseParamType",
                table: "ExerciseDictTypeParam");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseDictTypeParam_ExerciseType_IdExerciseType",
                table: "ExerciseDictTypeParam");

            migrationBuilder.DropForeignKey(
                name: "FK_Jump_JumpStatus_IdJumpStatus1",
                table: "Jump");

            migrationBuilder.DropForeignKey(
                name: "FK_Jump_JumpStatus_IdJumpStatus2",
                table: "Jump");

            migrationBuilder.DropForeignKey(
                name: "FK_Jump_JumpStatus_IdJumpStatus3",
                table: "Jump");

            migrationBuilder.DropForeignKey(
                name: "FK_Jump_Pole_IdPole3",
                table: "Jump");

            migrationBuilder.DropIndex(
                name: "IX_Jump_IdJumpStatus1",
                table: "Jump");

            migrationBuilder.DropIndex(
                name: "IX_Jump_IdJumpStatus2",
                table: "Jump");

            migrationBuilder.DropIndex(
                name: "IX_Jump_IdJumpStatus3",
                table: "Jump");

            migrationBuilder.DropIndex(
                name: "IX_Jump_IdPole3",
                table: "Jump");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseDictTypeParam_IdExerciseType",
                table: "ExerciseDictTypeParam");
        }
    }
}
