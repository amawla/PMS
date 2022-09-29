using Microsoft.EntityFrameworkCore.Migrations;

namespace PMS.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_Product_Id",
                table: "ProductImages",
                column: "Product_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_Product_Id",
                table: "ProductDetails",
                column: "Product_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributes_Attribute_Id",
                table: "ProductAttributes",
                column: "Attribute_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributes_Product_Id",
                table: "ProductAttributes",
                column: "Product_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributes_Attributes_Attribute_Id",
                table: "ProductAttributes",
                column: "Attribute_Id",
                principalTable: "Attributes",
                principalColumn: "Attribute_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributes_Products_Product_Id",
                table: "ProductAttributes",
                column: "Product_Id",
                principalTable: "Products",
                principalColumn: "Product_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_Products_Product_Id",
                table: "ProductDetails",
                column: "Product_Id",
                principalTable: "Products",
                principalColumn: "Product_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_Product_Id",
                table: "ProductImages",
                column: "Product_Id",
                principalTable: "Products",
                principalColumn: "Product_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributes_Attributes_Attribute_Id",
                table: "ProductAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributes_Products_Product_Id",
                table: "ProductAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_Products_Product_Id",
                table: "ProductDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_Product_Id",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_Product_Id",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_ProductDetails_Product_Id",
                table: "ProductDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProductAttributes_Attribute_Id",
                table: "ProductAttributes");

            migrationBuilder.DropIndex(
                name: "IX_ProductAttributes_Product_Id",
                table: "ProductAttributes");
        }
    }
}
