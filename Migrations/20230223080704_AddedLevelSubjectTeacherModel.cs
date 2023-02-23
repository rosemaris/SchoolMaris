using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolMaris.Migrations
{
    public partial class AddedLevelSubjectTeacherModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LevelSectionTeacher",
                columns: table => new
                {
                    LevelSectionTeacherID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LevelSectionID = table.Column<int>(nullable: false),
                    TeacherID = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelSectionTeacher", x => x.LevelSectionTeacherID);
                    table.ForeignKey(
                        name: "FK_LevelSectionTeacher_LevelSection_LevelSectionID",
                        column: x => x.LevelSectionID,
                        principalTable: "LevelSection",
                        principalColumn: "LevelSectionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LevelSectionTeacher_Teacher_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teacher",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LevelSubjectTeacher",
                columns: table => new
                {
                    LevelSubjectTeacherID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LevelSubjectID = table.Column<int>(nullable: false),
                    TeacherID = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelSubjectTeacher", x => x.LevelSubjectTeacherID);
                    table.ForeignKey(
                        name: "FK_LevelSubjectTeacher_LevelSubject_LevelSubjectID",
                        column: x => x.LevelSubjectID,
                        principalTable: "LevelSubject",
                        principalColumn: "LevelSubjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LevelSubjectTeacher_Teacher_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teacher",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LevelSectionTeacher_LevelSectionID",
                table: "LevelSectionTeacher",
                column: "LevelSectionID");

            migrationBuilder.CreateIndex(
                name: "IX_LevelSectionTeacher_TeacherID",
                table: "LevelSectionTeacher",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_LevelSubjectTeacher_LevelSubjectID",
                table: "LevelSubjectTeacher",
                column: "LevelSubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_LevelSubjectTeacher_TeacherID",
                table: "LevelSubjectTeacher",
                column: "TeacherID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LevelSectionTeacher");

            migrationBuilder.DropTable(
                name: "LevelSubjectTeacher");
        }
    }
}
