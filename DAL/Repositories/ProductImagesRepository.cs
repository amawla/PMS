using DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Model.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DAL.Repositories
{
    public class ProductImagesRepository : Repository<ProductImagesModel>, IProductImagesRepository
    {
        public ProductImagesRepository(DbContext context) : base(context)
        {
        }
        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;

        public void CreateProductImages(ProductImagesModel model)
        {
            Add(model);
            _appContext.SaveChanges();
        }

        public void CreateProductImages(IEnumerable<ProductImagesModel> model)
        {
            AddRange(model);
            _appContext.SaveChanges();

        }

        public IEnumerable<ProductImagesModel> GetAllProductImagesByProductId(Guid productId)
        {
            List<ProductImagesModel> productImagesById = new List<ProductImagesModel>();
            productImagesById = (from productImages in _appContext.ProductImages
                                  where productImages.Product_Id == productId && productImages.Active
                                  select productImages).ToList();
            return productImagesById;
        }
    }
}
