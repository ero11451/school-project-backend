using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_app.Migrations
{
    /// <inheritdoc />
    public partial class AddedTheUserModelToTheCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeacherId",
                table: "Categories",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_TeacherId",
                table: "Categories",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AspNetUsers_TeacherId",
                table: "Categories",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_AspNetUsers_TeacherId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_TeacherId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Categories");
        }
    }
}
