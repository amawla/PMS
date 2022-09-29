using Microsoft.EntityFrameworkCore;
using Model.Models.Products;
using Model.Models.Attributes;
using Model.Models.Category;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ProductsModel> Products { get; set; }
        public DbSet<AttributesModel> Attributes { get; set; }
        public DbSet<CategoryModel> Category { get; set; }
        public DbSet<ProductDetailsModel> ProductDetails { get; set; }
        public DbSet<ProductAttributesModel> ProductAttributes { get; set; }
        public DbSet<ProductImagesModel> ProductImages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ProductsModel>().Property(c => c.Product_Id).IsRequired();
            builder.Entity<ProductsModel>().Property(c => c.Category_Id).IsRequired();
            builder.Entity<ProductsModel>().Property(c => c.Product_Name).IsRequired().HasMaxLength(500);
            builder.Entity<ProductsModel>().Property(c => c.Product_Description).IsRequired(false);

            builder.Entity<AttributesModel>().Property(c => c.Attribute_Id).IsRequired();
            builder.Entity<AttributesModel>().Property(c => c.Attribiute_Name).IsRequired().HasMaxLength(500);

            builder.Entity<CategoryModel>().Property(c => c.Category_Id).IsRequired();
            builder.Entity<CategoryModel>().Property(c => c.Category_Name).IsRequired().HasMaxLength(500);

            builder.Entity<ProductDetailsModel>().Property(c => c.Product_Details_Id).IsRequired();
            builder.Entity<ProductDetailsModel>().Property(c => c.Product_Id).IsRequired();
            builder.Entity<ProductDetailsModel>().Property(c => c.Tax).IsRequired().HasMaxLength(200);
            builder.Entity<ProductDetailsModel>().Property(c => c.Price).IsRequired();
            builder.Entity<ProductDetailsModel>().Property(c => c.Qty_In_Stock).IsRequired(false);
            builder.Entity<ProductDetailsModel>().Property(c => c.Active_Date_From).IsRequired(false);
            builder.Entity<ProductDetailsModel>().Property(c => c.Active_Date_To).IsRequired(false);


            builder.Entity<ProductAttributesModel>().Property(c => c.Product_Attributes_Id).IsRequired();
            builder.Entity<ProductAttributesModel>().Property(c => c.Product_Id).IsRequired();
            builder.Entity<ProductAttributesModel>().Property(c => c.Attribute_Id).IsRequired();
            builder.Entity<ProductAttributesModel>().Property(c => c.Values).IsRequired();

            builder.Entity<ProductImagesModel>().Property(c => c.Product_Images_Id).IsRequired();
            builder.Entity<ProductImagesModel>().Property(c => c.Product_Id).IsRequired();
           
        }



        public override int SaveChanges()
        {

            return base.SaveChanges();
        }


        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {

            return base.SaveChangesAsync(cancellationToken);
        }


        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
