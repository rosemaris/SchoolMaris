using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolMaris.Migrations
{
    public partial class AddedTeacherImagetoTeacherModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeachersImage",
                table: "Teacher",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeachersImage",
                table: "Teacher");
        }
    }
}
