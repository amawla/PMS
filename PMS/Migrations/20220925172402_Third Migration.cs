using Microsoft.EntityFrameworkCore.Migrations;

namespace PMS.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Products_Category_Id",
                table: "Products",
                column: "Category_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Category_Category_Id",
                table: "Products",
                column: "Category_Id",
                principalTable: "Category",
                principalColumn: "Category_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Category_Category_Id",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Category_Id",
                table: "Products");
        }
    }
}
