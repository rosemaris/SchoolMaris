using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolMaris.Migrations
{
    public partial class AddedEnrolmentProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnrolmentProfile",
                columns: table => new
                {
                    EnrolmentProfileID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    SchoolYear = table.Column<int>(nullable: false),
                    PupilsProfileID = table.Column<int>(nullable: false),
                    LevelSubjectTeacherID = table.Column<int>(nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrolmentProfile", x => x.EnrolmentProfileID);
                    table.ForeignKey(
                        name: "FK_EnrolmentProfile_LevelSubjectTeacher_LevelSubjectTeacherID",
                        column: x => x.LevelSubjectTeacherID,
                        principalTable: "LevelSubjectTeacher",
                        principalColumn: "LevelSubjectTeacherID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnrolmentProfile_PupilsProfile_PupilsProfileID",
                        column: x => x.PupilsProfileID,
                        principalTable: "PupilsProfile",
                        principalColumn: "PupilsProfileID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnrolmentProfile_LevelSubjectTeacherID",
                table: "EnrolmentProfile",
                column: "LevelSubjectTeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_EnrolmentProfile_PupilsProfileID",
                table: "EnrolmentProfile",
                column: "PupilsProfileID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnrolmentProfile");
        }
    }
}
