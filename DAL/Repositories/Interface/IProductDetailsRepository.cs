using Model.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories.Interface
{
    public interface IProductDetailsRepository
    {
        ProductDetailsModel GetProductDetailsByProductId(Guid productId);
        void CreateProductDetail(ProductDetailsModel model);
        void UpdateProductDetail(ProductDetailsModel model);
    }
}
