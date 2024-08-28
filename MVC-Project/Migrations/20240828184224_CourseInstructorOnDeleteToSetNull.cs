using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Project.Migrations
{
    /// <inheritdoc />
    public partial class CourseInstructorOnDeleteToSetNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Courses_Crs_ID",
                table: "Instructors");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Courses_Crs_ID",
                table: "Instructors",
                column: "Crs_ID",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Courses_Crs_ID",
                table: "Instructors");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Courses_Crs_ID",
                table: "Instructors",
                column: "Crs_ID",
                principalTable: "Courses",
                principalColumn: "ID");
        }
    }
}
