using Microsoft.EntityFrameworkCore.Migrations;

namespace Tyczkarze.Migrations
{
    public partial class AllWithForegin1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jump_JumpType_JumpTypeIdJumpType",
                table: "Jump");

            migrationBuilder.DropIndex(
                name: "IX_Jump_JumpTypeIdJumpType",
                table: "Jump");

            migrationBuilder.DropColumn(
                name: "JumpTypeIdJumpType",
                table: "Jump");

            migrationBuilder.RenameColumn(
                name: "JumpType",
                table: "Jump",
                newName: "IdJumpType");

            migrationBuilder.CreateIndex(
                name: "IX_Jump_IdJumpType",
                table: "Jump",
                column: "IdJumpType");

            migrationBuilder.AddForeignKey(
                name: "FK_Jump_JumpType_IdJumpType",
                table: "Jump",
                column: "IdJumpType",
                principalTable: "JumpType",
                principalColumn: "IdJumpType",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jump_JumpType_IdJumpType",
                table: "Jump");

            migrationBuilder.DropIndex(
                name: "IX_Jump_IdJumpType",
                table: "Jump");

            migrationBuilder.RenameColumn(
                name: "IdJumpType",
                table: "Jump",
                newName: "JumpType");

            migrationBuilder.AddColumn<int>(
                name: "JumpTypeIdJumpType",
                table: "Jump",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jump_JumpTypeIdJumpType",
                table: "Jump",
                column: "JumpTypeIdJumpType");

            migrationBuilder.AddForeignKey(
                name: "FK_Jump_JumpType_JumpTypeIdJumpType",
                table: "Jump",
                column: "JumpTypeIdJumpType",
                principalTable: "JumpType",
                principalColumn: "IdJumpType",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
