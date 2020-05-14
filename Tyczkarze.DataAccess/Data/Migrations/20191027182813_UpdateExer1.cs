using Microsoft.EntityFrameworkCore.Migrations;

namespace Tyczkarze.Migrations
{
    public partial class UpdateExer1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExerciseParamTypeIdParamType",
                table: "ExerciseParam",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseParam_ExerciseParamTypeIdParamType",
                table: "ExerciseParam",
                column: "ExerciseParamTypeIdParamType");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseParam_ExerciseParamType_ExerciseParamTypeIdParamType",
                table: "ExerciseParam",
                column: "ExerciseParamTypeIdParamType",
                principalTable: "ExerciseParamType",
                principalColumn: "IdParamType",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseParam_ExerciseParamType_ExerciseParamTypeIdParamType",
                table: "ExerciseParam");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseParam_ExerciseParamTypeIdParamType",
                table: "ExerciseParam");

            migrationBuilder.DropColumn(
                name: "ExerciseParamTypeIdParamType",
                table: "ExerciseParam");
        }
    }
}
