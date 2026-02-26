using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RouterShop.Migrations
{
    /// <inheritdoc />
    public partial class ProductImageOneDefaultValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages");

            migrationBuilder.RenameColumn(
                name: "defaultImage",
                table: "ProductImages",
                newName: "DefaultImage");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId",
                unique: true,
                filter: "[DefaultImage] = 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages");

            migrationBuilder.RenameColumn(
                name: "DefaultImage",
                table: "ProductImages",
                newName: "defaultImage");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");
        }
    }
}
