using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_crsResults_courses_crs_id",
                table: "crsResults");

            migrationBuilder.AlterColumn<string>(
                name: "ImgURL",
                table: "Instructors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_crsResults_courses_crs_id",
                table: "crsResults",
                column: "crs_id",
                principalTable: "courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_crsResults_courses_crs_id",
                table: "crsResults");

            migrationBuilder.AlterColumn<string>(
                name: "ImgURL",
                table: "Instructors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_crsResults_courses_crs_id",
                table: "crsResults",
                column: "crs_id",
                principalTable: "courses",
                principalColumn: "Id");
        }
    }
}
