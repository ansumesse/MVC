using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Project.Migrations
{
    /// <inheritdoc />
    public partial class TrainingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MangerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Degree = table.Column<int>(type: "int", nullable: false),
                    MinDegree = table.Column<int>(type: "int", nullable: false),
                    Dep_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Course_Department_Dep_ID",
                        column: x => x.Dep_ID,
                        principalTable: "Department",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Trainee",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Degree = table.Column<int>(type: "int", nullable: false),
                    Dep_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainee", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Trainee_Department_Dep_ID",
                        column: x => x.Dep_ID,
                        principalTable: "Department",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dep_ID = table.Column<int>(type: "int", nullable: true),
                    Crs_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Instructor_Course_Crs_ID",
                        column: x => x.Crs_ID,
                        principalTable: "Course",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Instructor_Department_Dep_ID",
                        column: x => x.Dep_ID,
                        principalTable: "Department",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CrsResult",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Degree = table.Column<int>(type: "int", nullable: false),
                    Trainee_ID = table.Column<int>(type: "int", nullable: true),
                    Crs_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrsResult", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CrsResult_Course_Crs_ID",
                        column: x => x.Crs_ID,
                        principalTable: "Course",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CrsResult_Trainee_Trainee_ID",
                        column: x => x.Trainee_ID,
                        principalTable: "Trainee",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_Dep_ID",
                table: "Course",
                column: "Dep_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CrsResult_Crs_ID",
                table: "CrsResult",
                column: "Crs_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CrsResult_Trainee_ID",
                table: "CrsResult",
                column: "Trainee_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_Crs_ID",
                table: "Instructor",
                column: "Crs_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_Dep_ID",
                table: "Instructor",
                column: "Dep_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Trainee_Dep_ID",
                table: "Trainee",
                column: "Dep_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrsResult");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "Trainee");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
