using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kirilanatur.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddProductsAndProductImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SandalImages_Sandals_ProductId",
                table: "SandalImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sandals",
                table: "Sandals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SandalImages",
                table: "SandalImages");

            migrationBuilder.RenameTable(
                name: "Sandals",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "SandalImages",
                newName: "ProductImages");

            migrationBuilder.RenameIndex(
                name: "IX_SandalImages_ProductId",
                table: "ProductImages",
                newName: "IX_ProductImages_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductImages",
                table: "ProductImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductImages",
                table: "ProductImages");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Sandals");

            migrationBuilder.RenameTable(
                name: "ProductImages",
                newName: "SandalImages");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImages_ProductId",
                table: "SandalImages",
                newName: "IX_SandalImages_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sandals",
                table: "Sandals",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SandalImages",
                table: "SandalImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SandalImages_Sandals_ProductId",
                table: "SandalImages",
                column: "ProductId",
                principalTable: "Sandals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
