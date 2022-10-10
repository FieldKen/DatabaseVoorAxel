using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseVoorAxel.Migrations
{
    public partial class relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                table: "Personen",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Personen_GradeId",
                table: "Personen",
                column: "GradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personen_Grades_GradeId",
                table: "Personen",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personen_Grades_GradeId",
                table: "Personen");

            migrationBuilder.DropIndex(
                name: "IX_Personen_GradeId",
                table: "Personen");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "Personen");
        }
    }
}
