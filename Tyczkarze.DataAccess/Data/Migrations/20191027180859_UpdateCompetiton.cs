using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tyczkarze.Migrations
{
    public partial class UpdateCompetiton : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.AlterColumn<decimal>(
                name: "Length",
                table: "Pole",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Hardness",
                table: "Pole",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Height",
                table: "Jump",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Weight",
                table: "Athlete",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Height",
                table: "Athlete",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Competition_IdAgeCategory",
                table: "Competition",
                column: "IdAgeCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Competition_IdLevel",
                table: "Competition",
                column: "IdLevel");

            migrationBuilder.AddForeignKey(
                name: "FK_Competition_CompetitionAgeCategory_IdAgeCategory",
                table: "Competition",
                column: "IdAgeCategory",
                principalTable: "CompetitionAgeCategory",
                principalColumn: "IdAgeCategory",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Competition_CompetitionLevel_IdLevel",
                table: "Competition",
                column: "IdLevel",
                principalTable: "CompetitionLevel",
                principalColumn: "IdLevel",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competition_CompetitionAgeCategory_IdAgeCategory",
                table: "Competition");

            migrationBuilder.DropForeignKey(
                name: "FK_Competition_CompetitionLevel_IdLevel",
                table: "Competition");

            migrationBuilder.DropIndex(
                name: "IX_Competition_IdAgeCategory",
                table: "Competition");

            migrationBuilder.DropIndex(
                name: "IX_Competition_IdLevel",
                table: "Competition");

            migrationBuilder.AlterColumn<decimal>(
                name: "Length",
                table: "Pole",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Hardness",
                table: "Pole",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Height",
                table: "Jump",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Weight",
                table: "Athlete",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Height",
                table: "Athlete",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    IdExercise = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Distance = table.Column<int>(nullable: true),
                    ExerciseCount = table.Column<int>(nullable: true),
                    ExerciseName = table.Column<string>(nullable: true),
                    Height = table.Column<decimal>(nullable: true),
                    IdPole = table.Column<int>(nullable: true),
                    IdTraining = table.Column<int>(nullable: false),
                    JumpType = table.Column<int>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    SeriesCount = table.Column<int>(nullable: true),
                    Spikes = table.Column<bool>(nullable: true),
                    StepsCount = table.Column<int>(nullable: true),
                    Time = table.Column<int>(nullable: true),
                    Weight = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.IdExercise);
                });
        }
    }
}
