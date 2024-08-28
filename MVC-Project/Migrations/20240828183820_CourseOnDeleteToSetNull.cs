using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Project.Migrations
{
    /// <inheritdoc />
    public partial class CourseOnDeleteToSetNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrsResults_Courses_Crs_ID",
                table: "CrsResults");

            
            migrationBuilder.AddForeignKey(
                name: "FK_CrsResults_Courses_Crs_ID",
                table: "CrsResults",
                column: "Crs_ID",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrsResults_Courses_Crs_ID",
                table: "CrsResults");

       
            migrationBuilder.AddForeignKey(
                name: "FK_CrsResults_Courses_Crs_ID",
                table: "CrsResults",
                column: "Crs_ID",
                principalTable: "Courses",
                principalColumn: "ID");
        }
    }
}
