using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_app.Migrations
{
    /// <inheritdoc />
    public partial class InikktialCkkggggreatejjjAddedTheNEfW : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestOptions_Test_TestId",
                table: "TestOptions");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.DropColumn(
                name: "ScheduleDate",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "ScheduleTime",
                table: "Classes");

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    TestId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ClassId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Question = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.TestId);
                    table.ForeignKey(
                        name: "FK_Tests_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_ClassId",
                table: "Tests",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestOptions_Tests_TestId",
                table: "TestOptions",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "TestId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestOptions_Tests_TestId",
                table: "TestOptions");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.AddColumn<DateTime>(
                name: "ScheduleDate",
                table: "Classes",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ScheduleTime",
                table: "Classes",
                type: "time(6)",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    EnrollmentId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CourseId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId1 = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClassModelId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Grade = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    IsCompleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_Enrollments_Classes_ClassModelId",
                        column: x => x.ClassModelId,
                        principalTable: "Classes",
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
                        name: "FK_Test_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TestOptions_Test_TestId",
                table: "TestOptions",
                column: "TestId",
                principalTable: "Test",
                principalColumn: "TestId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
