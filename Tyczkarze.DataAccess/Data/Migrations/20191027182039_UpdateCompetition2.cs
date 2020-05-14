using Microsoft.EntityFrameworkCore.Migrations;

namespace Tyczkarze.Migrations
{
    public partial class UpdateCompetition2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TrainingType_IdExerciseType",
                table: "TrainingType",
                column: "IdExerciseType");

            migrationBuilder.CreateIndex(
                name: "IX_Training_IdTrainingType",
                table: "Training",
                column: "IdTrainingType");

            migrationBuilder.CreateIndex(
                name: "IX_Jump_IdContest",
                table: "Jump",
                column: "IdContest");

            migrationBuilder.CreateIndex(
                name: "IX_Jump_IdElimination",
                table: "Jump",
                column: "IdElimination");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseDone_IdTraining",
                table: "ExerciseDone",
                column: "IdTraining");

            migrationBuilder.CreateIndex(
                name: "IX_Elimination_IdCompetition",
                table: "Elimination",
                column: "IdCompetition");

            migrationBuilder.CreateIndex(
                name: "IX_Contest_IdCompetition",
                table: "Contest",
                column: "IdCompetition");

            migrationBuilder.AddForeignKey(
                name: "FK_Contest_Competition_IdCompetition",
                table: "Contest",
                column: "IdCompetition",
                principalTable: "Competition",
                principalColumn: "IdCompetition",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Elimination_Competition_IdCompetition",
                table: "Elimination",
                column: "IdCompetition",
                principalTable: "Competition",
                principalColumn: "IdCompetition",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseDone_Training_IdTraining",
                table: "ExerciseDone",
                column: "IdTraining",
                principalTable: "Training",
                principalColumn: "IdTraining",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Jump_Contest_IdContest",
                table: "Jump",
                column: "IdContest",
                principalTable: "Contest",
                principalColumn: "IdContest",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jump_Elimination_IdElimination",
                table: "Jump",
                column: "IdElimination",
                principalTable: "Elimination",
                principalColumn: "IdElimination",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Training_TrainingType_IdTrainingType",
                table: "Training",
                column: "IdTrainingType",
                principalTable: "TrainingType",
                principalColumn: "IdTrainingType",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingType_ExerciseType_IdExerciseType",
                table: "TrainingType",
                column: "IdExerciseType",
                principalTable: "ExerciseType",
                principalColumn: "IdExerciseType",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contest_Competition_IdCompetition",
                table: "Contest");

            migrationBuilder.DropForeignKey(
                name: "FK_Elimination_Competition_IdCompetition",
                table: "Elimination");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseDone_Training_IdTraining",
                table: "ExerciseDone");

            migrationBuilder.DropForeignKey(
                name: "FK_Jump_Contest_IdContest",
                table: "Jump");

            migrationBuilder.DropForeignKey(
                name: "FK_Jump_Elimination_IdElimination",
                table: "Jump");

            migrationBuilder.DropForeignKey(
                name: "FK_Training_TrainingType_IdTrainingType",
                table: "Training");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingType_ExerciseType_IdExerciseType",
                table: "TrainingType");

            migrationBuilder.DropIndex(
                name: "IX_TrainingType_IdExerciseType",
                table: "TrainingType");

            migrationBuilder.DropIndex(
                name: "IX_Training_IdTrainingType",
                table: "Training");

            migrationBuilder.DropIndex(
                name: "IX_Jump_IdContest",
                table: "Jump");

            migrationBuilder.DropIndex(
                name: "IX_Jump_IdElimination",
                table: "Jump");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseDone_IdTraining",
                table: "ExerciseDone");

            migrationBuilder.DropIndex(
                name: "IX_Elimination_IdCompetition",
                table: "Elimination");

            migrationBuilder.DropIndex(
                name: "IX_Contest_IdCompetition",
                table: "Contest");
        }
    }
}
