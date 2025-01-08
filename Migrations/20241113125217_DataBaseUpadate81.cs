using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_app.Migrations
{
    /// <inheritdoc />
    public partial class DataBaseUpadate81 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_AspNetUsers_UserModelId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Categories_categoryId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Options_Course_CourseId",
                table: "Options");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.RenameIndex(
                name: "IX_Course_UserModelId",
                table: "Courses",
                newName: "IX_Courses_UserModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Course_categoryId",
                table: "Courses",
                newName: "IX_Courses_categoryId");

            migrationBuilder.AddColumn<int>(
                name: "Phone",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "optionId",
                table: "Courses",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_UserModelId",
                table: "Courses",
                column: "UserModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Categories_categoryId",
                table: "Courses",
                column: "categoryId",
                principalTable: "Categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Courses_CourseId",
                table: "Options",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_UserModelId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Categories_categoryId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Options_Courses_CourseId",
                table: "Options");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "optionId",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_UserModelId",
                table: "Course",
                newName: "IX_Course_UserModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_categoryId",
                table: "Course",
                newName: "IX_Course_categoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_AspNetUsers_UserModelId",
                table: "Course",
                column: "UserModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Categories_categoryId",
                table: "Course",
                column: "categoryId",
                principalTable: "Categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Course_CourseId",
                table: "Options",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
