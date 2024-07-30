using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class dsfs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_Departments_dept_id",
                table: "courses");

            migrationBuilder.DropForeignKey(
                name: "FK_crsResults_courses_crs_id",
                table: "crsResults");

            migrationBuilder.DropForeignKey(
                name: "FK_crsResults_trainees_Trainee_id",
                table: "crsResults");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Departments_dept_id",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_courses_Crs_id",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_trainees_Departments_dept_id",
                table: "trainees");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "courses",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_Departments_dept_id",
                table: "courses",
                column: "dept_id",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_crsResults_courses_crs_id",
                table: "crsResults",
                column: "crs_id",
                principalTable: "courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_crsResults_trainees_Trainee_id",
                table: "crsResults",
                column: "Trainee_id",
                principalTable: "trainees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Departments_dept_id",
                table: "Instructors",
                column: "dept_id",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_courses_Crs_id",
                table: "Instructors",
                column: "Crs_id",
                principalTable: "courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_trainees_Departments_dept_id",
                table: "trainees",
                column: "dept_id",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_Departments_dept_id",
                table: "courses");

            migrationBuilder.DropForeignKey(
                name: "FK_crsResults_courses_crs_id",
                table: "crsResults");

            migrationBuilder.DropForeignKey(
                name: "FK_crsResults_trainees_Trainee_id",
                table: "crsResults");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Departments_dept_id",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_courses_Crs_id",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_trainees_Departments_dept_id",
                table: "trainees");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "courses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddForeignKey(
                name: "FK_courses_Departments_dept_id",
                table: "courses",
                column: "dept_id",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_crsResults_courses_crs_id",
                table: "crsResults",
                column: "crs_id",
                principalTable: "courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_crsResults_trainees_Trainee_id",
                table: "crsResults",
                column: "Trainee_id",
                principalTable: "trainees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Departments_dept_id",
                table: "Instructors",
                column: "dept_id",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_courses_Crs_id",
                table: "Instructors",
                column: "Crs_id",
                principalTable: "courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_trainees_Departments_dept_id",
                table: "trainees",
                column: "dept_id",
                principalTable: "Departments",
                principalColumn: "Id");
        }
    }
}
