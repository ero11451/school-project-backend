using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_app.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatejjjAddedTheNEfW : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassModel_AspNetUsers_InstructorId1",
                table: "ClassModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassModel_Courses_CourseId",
                table: "ClassModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_ClassModel_ClassModelId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Test_ClassModel_ClassId",
                table: "Test");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassModel",
                table: "ClassModel");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "ClassModel",
                newName: "Classes");

            migrationBuilder.RenameIndex(
                name: "IX_ClassModel_InstructorId1",
                table: "Classes",
                newName: "IX_Classes_InstructorId1");

            migrationBuilder.RenameIndex(
                name: "IX_ClassModel_CourseId",
                table: "Classes",
                newName: "IX_Classes_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classes",
                table: "Classes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_AspNetUsers_InstructorId1",
                table: "Classes",
                column: "InstructorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Courses_CourseId",
                table: "Classes",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Classes_ClassModelId",
                table: "Enrollments",
                column: "ClassModelId",
                principalTable: "Classes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Test_Classes_ClassId",
                table: "Test",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_AspNetUsers_InstructorId1",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Courses_CourseId",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Classes_ClassModelId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Test_Classes_ClassId",
                table: "Test");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classes",
                table: "Classes");

            migrationBuilder.RenameTable(
                name: "Classes",
                newName: "ClassModel");

            migrationBuilder.RenameIndex(
                name: "IX_Classes_InstructorId1",
                table: "ClassModel",
                newName: "IX_ClassModel_InstructorId1");

            migrationBuilder.RenameIndex(
                name: "IX_Classes_CourseId",
                table: "ClassModel",
                newName: "IX_ClassModel_CourseId");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Categories",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassModel",
                table: "ClassModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassModel_AspNetUsers_InstructorId1",
                table: "ClassModel",
                column: "InstructorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassModel_Courses_CourseId",
                table: "ClassModel",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_ClassModel_ClassModelId",
                table: "Enrollments",
                column: "ClassModelId",
                principalTable: "ClassModel",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Test_ClassModel_ClassId",
                table: "Test",
                column: "ClassId",
                principalTable: "ClassModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
