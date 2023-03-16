using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolMaris.Migrations
{
    public partial class AddRESTRICTIONonDeletion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnrolmentProfile_LevelSubjectTeacher_LevelSubjectTeacherID",
                table: "EnrolmentProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrolmentProfile_PupilsProfile_PupilsProfileID",
                table: "EnrolmentProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelSection_Level_LevelID",
                table: "LevelSection");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelSection_Section_SectionID",
                table: "LevelSection");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelSectionTeacher_LevelSection_LevelSectionID",
                table: "LevelSectionTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelSectionTeacher_Teacher_TeacherID",
                table: "LevelSectionTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelSubject_Level_LevelID",
                table: "LevelSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelSubject_Subject_SubjectID",
                table: "LevelSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelSubjectTeacher_LevelSubject_LevelSubjectID",
                table: "LevelSubjectTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelSubjectTeacher_Teacher_TeacherID",
                table: "LevelSubjectTeacher");

            migrationBuilder.AddForeignKey(
                name: "FK_EnrolmentProfile_LevelSubjectTeacher_LevelSubjectTeacherID",
                table: "EnrolmentProfile",
                column: "LevelSubjectTeacherID",
                principalTable: "LevelSubjectTeacher",
                principalColumn: "LevelSubjectTeacherID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EnrolmentProfile_PupilsProfile_PupilsProfileID",
                table: "EnrolmentProfile",
                column: "PupilsProfileID",
                principalTable: "PupilsProfile",
                principalColumn: "PupilsProfileID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelSection_Level_LevelID",
                table: "LevelSection",
                column: "LevelID",
                principalTable: "Level",
                principalColumn: "LevelID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelSection_Section_SectionID",
                table: "LevelSection",
                column: "SectionID",
                principalTable: "Section",
                principalColumn: "SectionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelSectionTeacher_LevelSection_LevelSectionID",
                table: "LevelSectionTeacher",
                column: "LevelSectionID",
                principalTable: "LevelSection",
                principalColumn: "LevelSectionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelSectionTeacher_Teacher_TeacherID",
                table: "LevelSectionTeacher",
                column: "TeacherID",
                principalTable: "Teacher",
                principalColumn: "TeacherID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelSubject_Level_LevelID",
                table: "LevelSubject",
                column: "LevelID",
                principalTable: "Level",
                principalColumn: "LevelID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelSubject_Subject_SubjectID",
                table: "LevelSubject",
                column: "SubjectID",
                principalTable: "Subject",
                principalColumn: "SubjectID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelSubjectTeacher_LevelSubject_LevelSubjectID",
                table: "LevelSubjectTeacher",
                column: "LevelSubjectID",
                principalTable: "LevelSubject",
                principalColumn: "LevelSubjectID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelSubjectTeacher_Teacher_TeacherID",
                table: "LevelSubjectTeacher",
                column: "TeacherID",
                principalTable: "Teacher",
                principalColumn: "TeacherID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnrolmentProfile_LevelSubjectTeacher_LevelSubjectTeacherID",
                table: "EnrolmentProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrolmentProfile_PupilsProfile_PupilsProfileID",
                table: "EnrolmentProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelSection_Level_LevelID",
                table: "LevelSection");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelSection_Section_SectionID",
                table: "LevelSection");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelSectionTeacher_LevelSection_LevelSectionID",
                table: "LevelSectionTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelSectionTeacher_Teacher_TeacherID",
                table: "LevelSectionTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelSubject_Level_LevelID",
                table: "LevelSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelSubject_Subject_SubjectID",
                table: "LevelSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelSubjectTeacher_LevelSubject_LevelSubjectID",
                table: "LevelSubjectTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelSubjectTeacher_Teacher_TeacherID",
                table: "LevelSubjectTeacher");

            migrationBuilder.AddForeignKey(
                name: "FK_EnrolmentProfile_LevelSubjectTeacher_LevelSubjectTeacherID",
                table: "EnrolmentProfile",
                column: "LevelSubjectTeacherID",
                principalTable: "LevelSubjectTeacher",
                principalColumn: "LevelSubjectTeacherID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnrolmentProfile_PupilsProfile_PupilsProfileID",
                table: "EnrolmentProfile",
                column: "PupilsProfileID",
                principalTable: "PupilsProfile",
                principalColumn: "PupilsProfileID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelSection_Level_LevelID",
                table: "LevelSection",
                column: "LevelID",
                principalTable: "Level",
                principalColumn: "LevelID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelSection_Section_SectionID",
                table: "LevelSection",
                column: "SectionID",
                principalTable: "Section",
                principalColumn: "SectionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelSectionTeacher_LevelSection_LevelSectionID",
                table: "LevelSectionTeacher",
                column: "LevelSectionID",
                principalTable: "LevelSection",
                principalColumn: "LevelSectionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelSectionTeacher_Teacher_TeacherID",
                table: "LevelSectionTeacher",
                column: "TeacherID",
                principalTable: "Teacher",
                principalColumn: "TeacherID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelSubject_Level_LevelID",
                table: "LevelSubject",
                column: "LevelID",
                principalTable: "Level",
                principalColumn: "LevelID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelSubject_Subject_SubjectID",
                table: "LevelSubject",
                column: "SubjectID",
                principalTable: "Subject",
                principalColumn: "SubjectID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelSubjectTeacher_LevelSubject_LevelSubjectID",
                table: "LevelSubjectTeacher",
                column: "LevelSubjectID",
                principalTable: "LevelSubject",
                principalColumn: "LevelSubjectID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelSubjectTeacher_Teacher_TeacherID",
                table: "LevelSubjectTeacher",
                column: "TeacherID",
                principalTable: "Teacher",
                principalColumn: "TeacherID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
