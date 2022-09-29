using DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Model.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DAL.Repositories
{
    public class ProductDetailsRepository : Repository<ProductDetailsModel>, IProductDetailsRepository
    {
        public ProductDetailsRepository(DbContext context) : base(context)
        {
        }
        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;

        public void CreateProductDetail(ProductDetailsModel model)
        {
            Add(model);
            _appContext.SaveChanges();
        }

        public ProductDetailsModel GetProductDetailsByProductId(Guid productId)
        {
            ProductDetailsModel productDetailsById = new ProductDetailsModel();
            productDetailsById = (from productDetails in _appContext.ProductDetails
                           where productDetails.Product_Id == productId && productDetails.Active
                           select productDetails).FirstOrDefault();
            return productDetailsById;
        }

        public void UpdateProductDetail(ProductDetailsModel model)
        {
            Update(model);
            _appContext.SaveChanges();
        }
    }
}
