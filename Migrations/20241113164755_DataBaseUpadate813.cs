using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_app.Migrations
{
    /// <inheritdoc />
    public partial class DataBaseUpadate813 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_AspNetUsers_UsersModelId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_UserModelId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Categories_categoryId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_UserModelId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Categories_UsersModelId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UserModelId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "UsersModelId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "courseId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "teacherId",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "videoUrl",
                table: "Courses",
                newName: "VideoUrl");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Courses",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "teacherId",
                table: "Courses",
                newName: "TeacherId");

            migrationBuilder.RenameColumn(
                name: "summary",
                table: "Courses",
                newName: "Summary");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Courses",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "question",
                table: "Courses",
                newName: "Question");

            migrationBuilder.RenameColumn(
                name: "optionId",
                table: "Courses",
                newName: "OptionId");

            migrationBuilder.RenameColumn(
                name: "imgUrl",
                table: "Courses",
                newName: "ImgUrl");

            migrationBuilder.RenameColumn(
                name: "content",
                table: "Courses",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "Courses",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "Courses",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_categoryId",
                table: "Courses",
                newName: "IX_Courses_CategoryId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Categories",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Categories",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherId",
                table: "Courses",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "Courses",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_TeacherId",
                table: "Courses",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Categories_CategoryId",
                table: "Courses",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_TeacherId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Categories_CategoryId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "VideoUrl",
                table: "Courses",
                newName: "videoUrl");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Courses",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Courses",
                newName: "teacherId");

            migrationBuilder.RenameColumn(
                name: "Summary",
                table: "Courses",
                newName: "summary");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Courses",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Question",
                table: "Courses",
                newName: "question");

            migrationBuilder.RenameColumn(
                name: "OptionId",
                table: "Courses",
                newName: "optionId");

            migrationBuilder.RenameColumn(
                name: "ImgUrl",
                table: "Courses",
                newName: "imgUrl");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Courses",
                newName: "content");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Courses",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Courses",
                newName: "categoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                newName: "IX_Courses_categoryId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Categories",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "teacherId",
                table: "Courses",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<Guid>(
                name: "categoryId",
                table: "Courses",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "UserModelId",
                table: "Courses",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UsersModelId",
                table: "Categories",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "courseId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "teacherId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_UserModelId",
                table: "Courses",
                column: "UserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UsersModelId",
                table: "Categories",
                column: "UsersModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AspNetUsers_UsersModelId",
                table: "Categories",
                column: "UsersModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

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
        }
    }
}
