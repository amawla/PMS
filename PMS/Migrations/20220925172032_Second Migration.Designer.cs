﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PMS.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220925172032_Second Migration")]
    partial class SecondMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Model.Models.Attributes.AttributesModel", b =>
                {
                    b.Property<Guid>("Attribute_Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Attribiute_Name")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<DateTime>("Creation_Date");

                    b.Property<DateTime>("Modification_Date");

                    b.HasKey("Attribute_Id");

                    b.ToTable("Attributes");
                });

            modelBuilder.Entity("Model.Models.Category.CategoryModel", b =>
                {
                    b.Property<Guid>("Category_Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Category_Name")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<DateTime>("Creation_Date");

                    b.Property<DateTime>("Modification_Date");

                    b.HasKey("Category_Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Model.Models.Products.ProductAttributesModel", b =>
                {
                    b.Property<Guid>("Product_Attributes_Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<Guid>("Attribute_Id");

                    b.Property<DateTime>("Creation_Date");

                    b.Property<DateTime>("Modification_Date");

                    b.Property<Guid>("Product_Id");

                    b.Property<string>("Values")
                        .IsRequired();

                    b.HasKey("Product_Attributes_Id");

                    b.ToTable("ProductAttributes");
                });

            modelBuilder.Entity("Model.Models.Products.ProductDetailsModel", b =>
                {
                    b.Property<Guid>("Product_Details_Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime?>("Active_Date_From");

                    b.Property<DateTime?>("Active_Date_To");

                    b.Property<DateTime>("Creation_Date");

                    b.Property<int>("Discount");

                    b.Property<DateTime>("Modification_Date");

                    b.Property<decimal>("Price");

                    b.Property<Guid>("Product_Id");

                    b.Property<int?>("Qty_In_Stock");

                    b.Property<string>("Tax")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Product_Details_Id");

                    b.ToTable("ProductDetails");
                });

            modelBuilder.Entity("Model.Models.Products.ProductImagesModel", b =>
                {
                    b.Property<Guid>("Product_Images_Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("Creation_Date");

                    b.Property<string>("Image_Path");

                    b.Property<DateTime>("Modification_Date");

                    b.Property<Guid>("Product_Id");

                    b.HasKey("Product_Images_Id");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("Model.Models.Products.ProductsModel", b =>
                {
                    b.Property<Guid>("Product_Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<Guid>("Category_Id");

                    b.Property<DateTime>("Creation_Date");

                    b.Property<DateTime>("Modification_Date");

                    b.Property<string>("Product_Description");

                    b.Property<string>("Product_Name")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.HasKey("Product_Id");

                    b.ToTable("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
