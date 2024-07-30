using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class up1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Degree = table.Column<int>(type: "int", nullable: false),
                    MinDegree = table.Column<int>(type: "int", nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    dept_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_courses_Departments_dept_id",
                        column: x => x.dept_id,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "trainees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    grade = table.Column<int>(type: "int", nullable: false),
                    ImgURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dept_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trainees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trainees_Departments_dept_id",
                        column: x => x.dept_id,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    dept_id = table.Column<int>(type: "int", nullable: false),
                    Crs_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructors_Departments_dept_id",
                        column: x => x.dept_id,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Instructors_courses_Crs_id",
                        column: x => x.Crs_id,
                        principalTable: "courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "crsResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Degree = table.Column<int>(type: "int", nullable: false),
                    crs_id = table.Column<int>(type: "int", nullable: false),
                    Trainee_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_crsResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_crsResults_courses_crs_id",
                        column: x => x.crs_id,
                        principalTable: "courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_crsResults_trainees_Trainee_id",
                        column: x => x.Trainee_id,
                        principalTable: "trainees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Manager", "Name" },
                values: new object[,]
                {
                    { 1, "Eng.AhmedMamdouh", "PWD" },
                    { 2, "Eng.Christen", "OS" }
                });

            migrationBuilder.InsertData(
                table: "courses",
                columns: new[] { "Id", "Degree", "Hours", "MinDegree", "Name", "dept_id" },
                values: new object[,]
                {
                    { 1, 100, 30, 60, "HTML", 1 },
                    { 2, 100, 40, 60, "CSS", 2 },
                    { 3, 100, 35, 60, "JS", 1 },
                    { 4, 100, 20, 60, "ES6", 2 }
                });

            migrationBuilder.InsertData(
                table: "trainees",
                columns: new[] { "Id", "Address", "ImgURL", "Name", "dept_id", "grade" },
                values: new object[,]
                {
                    { 1, "Assiut", "F.jpeg", "Manar", 1, 1 },
                    { 2, "Assiut", "F.jpeg", "Asmaa", 1, 1 },
                    { 3, "Assiut", "F.jpeg", "Zahraa", 2, 1 },
                    { 4, "Assiut", "F.jpeg", "Fatma", 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "Address", "Crs_id", "ImgURL", "Name", "Salary", "dept_id" },
                values: new object[,]
                {
                    { 1, "Alex", 1, "m.jpeg", "mohamed", 5000, 1 },
                    { 2, "Assiut", 2, "m.jpeg", "Ahmed", 6000, 2 },
                    { 3, "Asswan", 3, "f.jpeg", "mai", 7000, 1 },
                    { 4, "Sohag", 4, "f.jpeg", "aya", 9000, 2 }
                });

            migrationBuilder.InsertData(
                table: "crsResults",
                columns: new[] { "Id", "Degree", "Trainee_id", "crs_id" },
                values: new object[,]
                {
                    { 1, 95, 1, 1 },
                    { 2, 90, 2, 2 },
                    { 3, 80, 3, 3 },
                    { 4, 70, 4, 4 },
                    { 5, 50, 1, 2 },
                    { 6, 85, 3, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_courses_dept_id",
                table: "courses",
                column: "dept_id");

            migrationBuilder.CreateIndex(
                name: "IX_crsResults_crs_id",
                table: "crsResults",
                column: "crs_id");

            migrationBuilder.CreateIndex(
                name: "IX_crsResults_Trainee_id",
                table: "crsResults",
                column: "Trainee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_Crs_id",
                table: "Instructors",
                column: "Crs_id");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_dept_id",
                table: "Instructors",
                column: "dept_id");

            migrationBuilder.CreateIndex(
                name: "IX_trainees_dept_id",
                table: "trainees",
                column: "dept_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "crsResults");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "trainees");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
