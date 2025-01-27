using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_app.Migrations
{
    /// <inheritdoc />
    public partial class InikktialCsdhhgggfgreaggtejjjAddedTheNEfW : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_AspNetUsers_InstructorId1",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_InstructorId1",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "InstructorId1",
                table: "Classes");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Courses",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<Guid>(
                name: "InstructorId",
                table: "Classes",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "InstructorId1",
                table: "Classes",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_InstructorId1",
                table: "Classes",
                column: "InstructorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_AspNetUsers_InstructorId1",
                table: "Classes",
                column: "InstructorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
