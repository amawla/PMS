using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PMS.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Qty_In_Stock",
                table: "ProductDetails",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Active_Date_To",
                table: "ProductDetails",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Active_Date_From",
                table: "ProductDetails",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Qty_In_Stock",
                table: "ProductDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Active_Date_To",
                table: "ProductDetails",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Active_Date_From",
                table: "ProductDetails",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
