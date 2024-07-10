using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pajophone.Migrations
{
    /// <inheritdoc />
    public partial class renamed_category_in_fieldKeyModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductFieldKeys_ProductCategories_CatgeoryId",
                table: "ProductFieldKeys");

            migrationBuilder.DropIndex(
                name: "IX_ProductFieldKeys_CatgeoryId",
                table: "ProductFieldKeys");

            migrationBuilder.DropColumn(
                name: "CatgeoryId",
                table: "ProductFieldKeys");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFieldKeys_CategoryId",
                table: "ProductFieldKeys",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFieldKeys_ProductCategories_CategoryId",
                table: "ProductFieldKeys",
                column: "CategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductFieldKeys_ProductCategories_CategoryId",
                table: "ProductFieldKeys");

            migrationBuilder.DropIndex(
                name: "IX_ProductFieldKeys_CategoryId",
                table: "ProductFieldKeys");

            migrationBuilder.AddColumn<int>(
                name: "CatgeoryId",
                table: "ProductFieldKeys",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductFieldKeys_CatgeoryId",
                table: "ProductFieldKeys",
                column: "CatgeoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductFieldKeys_ProductCategories_CatgeoryId",
                table: "ProductFieldKeys",
                column: "CatgeoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id");
        }
    }
}
