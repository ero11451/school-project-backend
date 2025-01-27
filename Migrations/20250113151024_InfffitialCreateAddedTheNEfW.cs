using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_app.Migrations
{
    /// <inheritdoc />
    public partial class InfffitialCreateAddedTheNEfW : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_AspNetUsers_TeacherId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_TeacherId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Categories_TeacherId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "OptionId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Question",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "VideoUrl",
                table: "Courses",
                newName: "ThumbnailUrl");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Courses",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "CreatedTimestamp",
                table: "Courses",
                newName: "CreatedAt");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Status",
                keyValue: null,
                column: "Status",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Courses",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CourseName",
                table: "Courses",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "Courses",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Categories",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Categories",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ClassModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CourseId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    InstructorId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ClassName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ScheduleDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ScheduleTime = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    DurationMinutes = table.Column<int>(type: "int", nullable: false),
                    MaxStudents = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Content = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Summary = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImgUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VideoUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InstructorId1 = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassModel_AspNetUsers_InstructorId1",
                        column: x => x.InstructorId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClassModel_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    EnrollmentId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Grade = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    UserId1 = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClassModelId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.EnrollmentId);
                    table.ForeignKey(
                        name: "FK_Enrollments_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Enrollments_ClassModel_ClassModelId",
                        column: x => x.ClassModelId,
                        principalTable: "ClassModel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    TestId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ClassId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Question = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.TestId);
                    table.ForeignKey(
                        name: "FK_Test_ClassModel_ClassId",
                        column: x => x.ClassId,
                        principalTable: "ClassModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TestOptions",
                columns: table => new
                {
                    OptionId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TestId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    OptionText = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsCorrect = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestOptions", x => x.OptionId);
                    table.ForeignKey(
                        name: "FK_TestOptions_Test_TestId",
                        column: x => x.TestId,
                        principalTable: "Test",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CreatorId",
                table: "Courses",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassModel_CourseId",
                table: "ClassModel",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassModel_InstructorId1",
                table: "ClassModel",
                column: "InstructorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_ClassModelId",
                table: "Enrollments",
                column: "ClassModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseId",
                table: "Enrollments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_UserId1",
                table: "Enrollments",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Test_ClassId",
                table: "Test",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_TestOptions_TestId",
                table: "TestOptions",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_CreatorId",
                table: "Courses",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_CreatorId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "TestOptions");

            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.DropTable(
                name: "ClassModel");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CreatorId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseName",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "ThumbnailUrl",
                table: "Courses",
                newName: "VideoUrl");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Courses",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Courses",
                newName: "CreatedTimestamp");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Courses",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Courses",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Courses",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Courses",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "OptionId",
                table: "Courses",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "Question",
                table: "Courses",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Courses",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "TeacherId",
                table: "Courses",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Categories",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Categories",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "TeacherId",
                table: "Categories",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CourseId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IsCorrect = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    OptionText = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Options_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_TeacherId",
                table: "Categories",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_CourseId",
                table: "Options",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AspNetUsers_TeacherId",
                table: "Categories",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_TeacherId",
                table: "Courses",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
