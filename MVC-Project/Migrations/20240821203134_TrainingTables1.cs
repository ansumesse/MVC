using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Project.Migrations
{
    /// <inheritdoc />
    public partial class TrainingTables1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Department_Dep_ID",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_CrsResult_Course_Crs_ID",
                table: "CrsResult");

            migrationBuilder.DropForeignKey(
                name: "FK_CrsResult_Trainee_Trainee_ID",
                table: "CrsResult");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_Course_Crs_ID",
                table: "Instructor");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_Department_Dep_ID",
                table: "Instructor");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainee_Department_Dep_ID",
                table: "Trainee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trainee",
                table: "Trainee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructor",
                table: "Instructor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CrsResult",
                table: "CrsResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.RenameTable(
                name: "Trainee",
                newName: "Trainees");

            migrationBuilder.RenameTable(
                name: "Instructor",
                newName: "Instructors");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Departments");

            migrationBuilder.RenameTable(
                name: "CrsResult",
                newName: "CrsResults");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.RenameIndex(
                name: "IX_Trainee_Dep_ID",
                table: "Trainees",
                newName: "IX_Trainees_Dep_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Instructor_Dep_ID",
                table: "Instructors",
                newName: "IX_Instructors_Dep_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Instructor_Crs_ID",
                table: "Instructors",
                newName: "IX_Instructors_Crs_ID");

            migrationBuilder.RenameIndex(
                name: "IX_CrsResult_Trainee_ID",
                table: "CrsResults",
                newName: "IX_CrsResults_Trainee_ID");

            migrationBuilder.RenameIndex(
                name: "IX_CrsResult_Crs_ID",
                table: "CrsResults",
                newName: "IX_CrsResults_Crs_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Course_Dep_ID",
                table: "Courses",
                newName: "IX_Courses_Dep_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trainees",
                table: "Trainees",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructors",
                table: "Instructors",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CrsResults",
                table: "CrsResults",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_Dep_ID",
                table: "Courses",
                column: "Dep_ID",
                principalTable: "Departments",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CrsResults_Courses_Crs_ID",
                table: "CrsResults",
                column: "Crs_ID",
                principalTable: "Courses",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CrsResults_Trainees_Trainee_ID",
                table: "CrsResults",
                column: "Trainee_ID",
                principalTable: "Trainees",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Courses_Crs_ID",
                table: "Instructors",
                column: "Crs_ID",
                principalTable: "Courses",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Departments_Dep_ID",
                table: "Instructors",
                column: "Dep_ID",
                principalTable: "Departments",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_Departments_Dep_ID",
                table: "Trainees",
                column: "Dep_ID",
                principalTable: "Departments",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_Dep_ID",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_CrsResults_Courses_Crs_ID",
                table: "CrsResults");

            migrationBuilder.DropForeignKey(
                name: "FK_CrsResults_Trainees_Trainee_ID",
                table: "CrsResults");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Courses_Crs_ID",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Departments_Dep_ID",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainees_Departments_Dep_ID",
                table: "Trainees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trainees",
                table: "Trainees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructors",
                table: "Instructors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CrsResults",
                table: "CrsResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Trainees",
                newName: "Trainee");

            migrationBuilder.RenameTable(
                name: "Instructors",
                newName: "Instructor");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Department");

            migrationBuilder.RenameTable(
                name: "CrsResults",
                newName: "CrsResult");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.RenameIndex(
                name: "IX_Trainees_Dep_ID",
                table: "Trainee",
                newName: "IX_Trainee_Dep_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Instructors_Dep_ID",
                table: "Instructor",
                newName: "IX_Instructor_Dep_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Instructors_Crs_ID",
                table: "Instructor",
                newName: "IX_Instructor_Crs_ID");

            migrationBuilder.RenameIndex(
                name: "IX_CrsResults_Trainee_ID",
                table: "CrsResult",
                newName: "IX_CrsResult_Trainee_ID");

            migrationBuilder.RenameIndex(
                name: "IX_CrsResults_Crs_ID",
                table: "CrsResult",
                newName: "IX_CrsResult_Crs_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_Dep_ID",
                table: "Course",
                newName: "IX_Course_Dep_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trainee",
                table: "Trainee",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructor",
                table: "Instructor",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CrsResult",
                table: "CrsResult",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Department_Dep_ID",
                table: "Course",
                column: "Dep_ID",
                principalTable: "Department",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CrsResult_Course_Crs_ID",
                table: "CrsResult",
                column: "Crs_ID",
                principalTable: "Course",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CrsResult_Trainee_Trainee_ID",
                table: "CrsResult",
                column: "Trainee_ID",
                principalTable: "Trainee",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_Course_Crs_ID",
                table: "Instructor",
                column: "Crs_ID",
                principalTable: "Course",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_Department_Dep_ID",
                table: "Instructor",
                column: "Dep_ID",
                principalTable: "Department",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainee_Department_Dep_ID",
                table: "Trainee",
                column: "Dep_ID",
                principalTable: "Department",
                principalColumn: "ID");
        }
    }
}
