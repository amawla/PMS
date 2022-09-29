using Model.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories.Interface
{
    public interface IProductsRepository
    {
        void CreateProduct(ProductsModel model);
        void UpdateProduct(ProductsModel model);
        void DeleteProduct(ProductsModel model);
        IEnumerable<ProductsGridViewModel> GetAllProducts();
        ProductsModel GetProductById(Guid productId);
    }
}
