using DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Model.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DAL.Repositories
{
    public class ProductsRepository : Repository<ProductsModel>, IProductsRepository
    {
        public ProductsRepository(DbContext context) : base(context)
        {
        }
        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
        public void CreateProduct(ProductsModel model)
        {
            Add(model);
            _appContext.SaveChanges();
        }
        public void UpdateProduct(ProductsModel model)
        {
            Update(model);
            _appContext.SaveChanges();
        }
        public void DeleteProduct(ProductsModel model)
        {
            Remove(model);
            _appContext.SaveChanges();
        }

        public IEnumerable<ProductsGridViewModel> GetAllProducts()
        {
            List<ProductsGridViewModel> allProducts = new List<ProductsGridViewModel>();
            allProducts = (from products in _appContext.Products
                           join productDetails in _appContext.ProductDetails on products.Product_Id equals productDetails.Product_Id
                           join categories in _appContext.Category on products.Category_Id equals categories.Category_Id
                             select new ProductsGridViewModel
                             {
                                 Product_Id = products.Product_Id,
                                 Product_Name = products.Product_Name,
                                 Category_Id = categories.Category_Id,
                                 Category_Name = categories.Category_Name,
                                 Price = productDetails.Price,
                                 Status = products.Active,
                                 Creation_Date = products.Creation_Date

                             }).OrderByDescending(pr => pr.Creation_Date).Distinct().ToList();
            return allProducts;
        }

        public ProductsModel GetProductById(Guid productId)
        {
            ProductsModel productById = new ProductsModel();
            productById = (from products in _appContext.Products
                           where products.Product_Id == productId
                           select products).FirstOrDefault();
            return productById;
        }

  
    }
}
