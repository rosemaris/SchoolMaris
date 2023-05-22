using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolMaris.Migrations
{
    public partial class AddedanswerKeyToQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AKeyID",
                table: "QuizQuestion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnswerKeyAKeyID",
                table: "QuizQuestion",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestion_AnswerKeyAKeyID",
                table: "QuizQuestion",
                column: "AnswerKeyAKeyID");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestion_AnswerKey_AnswerKeyAKeyID",
                table: "QuizQuestion",
                column: "AnswerKeyAKeyID",
                principalTable: "AnswerKey",
                principalColumn: "AKeyID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestion_AnswerKey_AnswerKeyAKeyID",
                table: "QuizQuestion");

            migrationBuilder.DropIndex(
                name: "IX_QuizQuestion_AnswerKeyAKeyID",
                table: "QuizQuestion");

            migrationBuilder.DropColumn(
                name: "AKeyID",
                table: "QuizQuestion");

            migrationBuilder.DropColumn(
                name: "AnswerKeyAKeyID",
                table: "QuizQuestion");
        }
    }
}
