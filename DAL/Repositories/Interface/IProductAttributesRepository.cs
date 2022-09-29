using Model.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories.Interface
{
    public interface IProductAttributesRepository
    {
        IEnumerable<ProductAttributesModel> GetAllProductAttributesByProductId(Guid productId);
        void CreateProductAttributes(ProductAttributesModel model);
    }
}
