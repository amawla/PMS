using Model.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories.Interface
{
    public interface IProductImagesRepository
    {
        IEnumerable<ProductImagesModel> GetAllProductImagesByProductId(Guid productId);
        void CreateProductImages(ProductImagesModel model);
        void CreateProductImages(IEnumerable<ProductImagesModel> model);
    }
}
