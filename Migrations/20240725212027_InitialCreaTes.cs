using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_app.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreaTes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "title",
                table: "PostModel",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "content",
                table: "PostModel",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "PostModel",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "TestId",
                table: "PostModel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TestModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Question = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestModel", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TestOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Option = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsCorrect = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TestModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestOptions_TestModel_TestModelId",
                        column: x => x.TestModelId,
                        principalTable: "TestModel",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PostModel_TestId",
                table: "PostModel",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_TestOptions_TestModelId",
                table: "TestOptions",
                column: "TestModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostModel_TestModel_TestId",
                table: "PostModel",
                column: "TestId",
                principalTable: "TestModel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostModel_TestModel_TestId",
                table: "PostModel");

            migrationBuilder.DropTable(
                name: "TestOptions");

            migrationBuilder.DropTable(
                name: "TestModel");

            migrationBuilder.DropIndex(
                name: "IX_PostModel_TestId",
                table: "PostModel");

            migrationBuilder.DropColumn(
                name: "TestId",
                table: "PostModel");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "PostModel",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "PostModel",
                newName: "content");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PostModel",
                newName: "id");
        }
    }
}
