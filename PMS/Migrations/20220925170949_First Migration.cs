using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PMS.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    Attribute_Id = table.Column<Guid>(nullable: false),
                    Attribiute_Name = table.Column<string>(maxLength: 500, nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Creation_Date = table.Column<DateTime>(nullable: false),
                    Modification_Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.Attribute_Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Category_Id = table.Column<Guid>(nullable: false),
                    Category_Name = table.Column<string>(maxLength: 500, nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Creation_Date = table.Column<DateTime>(nullable: false),
                    Modification_Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Category_Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttributes",
                columns: table => new
                {
                    Product_Attributes_Id = table.Column<Guid>(nullable: false),
                    Product_Id = table.Column<Guid>(nullable: false),
                    Attribute_Id = table.Column<Guid>(nullable: false),
                    Values = table.Column<string>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Creation_Date = table.Column<DateTime>(nullable: false),
                    Modification_Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributes", x => x.Product_Attributes_Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    Product_Details_Id = table.Column<Guid>(nullable: false),
                    Product_Id = table.Column<Guid>(nullable: false),
                    Qty_In_Stock = table.Column<int>(nullable: false),
                    Tax = table.Column<string>(maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(maxLength: 500, nullable: false),
                    Discount = table.Column<int>(nullable: false),
                    Active_Date_From = table.Column<DateTime>(nullable: false),
                    Active_Date_To = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Creation_Date = table.Column<DateTime>(nullable: false),
                    Modification_Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.Product_Details_Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Product_Images_Id = table.Column<Guid>(nullable: false),
                    Product_Id = table.Column<Guid>(nullable: false),
                    Image_Path = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Creation_Date = table.Column<DateTime>(nullable: false),
                    Modification_Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Product_Images_Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Product_Id = table.Column<Guid>(nullable: false),
                    Category_Id = table.Column<Guid>(nullable: false),
                    Product_Name = table.Column<string>(maxLength: 500, nullable: false),
                    Product_Description = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Creation_Date = table.Column<DateTime>(nullable: false),
                    Modification_Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Product_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "ProductAttributes");

            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
