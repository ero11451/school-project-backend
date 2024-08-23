using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_app.Migrations
{
    /// <inheritdoc />
    public partial class FixCategoryModelRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostModel_AspNetUsers_TeacherId1",
                table: "PostModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PostModel_LocationModel_LocationId",
                table: "PostModel");

            migrationBuilder.DropForeignKey(
                name: "FK_TestOptions_PostModel_PostModelId",
                table: "TestOptions");

            migrationBuilder.DropIndex(
                name: "IX_PostModel_LocationId",
                table: "PostModel");

            migrationBuilder.DropIndex(
                name: "IX_PostModel_TeacherId1",
                table: "PostModel");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "PostModel");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "PostModel");

            migrationBuilder.DropColumn(
                name: "TeacherId1",
                table: "PostModel");

            migrationBuilder.AlterColumn<int>(
                name: "PostModelId",
                table: "TestOptions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AlterColumn<int>(
                name: "PostModelId",
                table: "TestOptions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "PostModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "PostModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherId1",
                table: "PostModel",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PostModel_LocationId",
                table: "PostModel",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PostModel_TeacherId1",
                table: "PostModel",
                column: "TeacherId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PostModel_AspNetUsers_TeacherId1",
                table: "PostModel",
                column: "TeacherId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostModel_LocationModel_LocationId",
                table: "PostModel",
                column: "LocationId",
                principalTable: "LocationModel",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestOptions_PostModel_PostModelId",
                table: "TestOptions",
                column: "PostModelId",
                principalTable: "PostModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
