using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_app.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreaffgvfffgg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostModel_TestModel_TestId",
                table: "PostModel");

            migrationBuilder.DropIndex(
                name: "IX_PostModel_TestId",
                table: "PostModel");

            migrationBuilder.DropColumn(
                name: "TestId",
                table: "PostModel");

            migrationBuilder.AddColumn<int>(
                name: "PostModelId",
                table: "TestOptions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Question",
                table: "PostModel",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TestOptions_PostModelId",
                table: "TestOptions",
                column: "PostModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestOptions_PostModel_PostModelId",
                table: "TestOptions",
                column: "PostModelId",
                principalTable: "PostModel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestOptions_PostModel_PostModelId",
                table: "TestOptions");

            migrationBuilder.DropIndex(
                name: "IX_TestOptions_PostModelId",
                table: "TestOptions");

            migrationBuilder.DropColumn(
                name: "PostModelId",
                table: "TestOptions");

            migrationBuilder.DropColumn(
                name: "Question",
                table: "PostModel");

            migrationBuilder.AddColumn<int>(
                name: "TestId",
                table: "PostModel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostModel_TestId",
                table: "PostModel",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostModel_TestModel_TestId",
                table: "PostModel",
                column: "TestId",
                principalTable: "TestModel",
                principalColumn: "Id");
        }
    }
}
