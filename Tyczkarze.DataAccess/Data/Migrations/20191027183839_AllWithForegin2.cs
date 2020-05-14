using Microsoft.EntityFrameworkCore.Migrations;

namespace Tyczkarze.Migrations
{
    public partial class AllWithForegin2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Jump_IdPole1",
                table: "Jump",
                column: "IdPole1");

            migrationBuilder.CreateIndex(
                name: "IX_Jump_IdPole2",
                table: "Jump",
                column: "IdPole2");

            migrationBuilder.AddForeignKey(
                name: "FK_Jump_Pole_IdPole1",
                table: "Jump",
                column: "IdPole1",
                principalTable: "Pole",
                principalColumn: "IdPole",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jump_Pole_IdPole2",
                table: "Jump",
                column: "IdPole2",
                principalTable: "Pole",
                principalColumn: "IdPole",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jump_Pole_IdPole1",
                table: "Jump");

            migrationBuilder.DropForeignKey(
                name: "FK_Jump_Pole_IdPole2",
                table: "Jump");

            migrationBuilder.DropIndex(
                name: "IX_Jump_IdPole1",
                table: "Jump");

            migrationBuilder.DropIndex(
                name: "IX_Jump_IdPole2",
                table: "Jump");
        }
    }
}
