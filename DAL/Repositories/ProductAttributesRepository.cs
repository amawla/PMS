using DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Model.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DAL.Repositories
{
    public class ProductAttributesRepository : Repository<ProductAttributesModel>, IProductAttributesRepository
    {
        public ProductAttributesRepository(DbContext context) : base(context)
        {
        }
        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;

        public void CreateProductAttributes(ProductAttributesModel model)
        {
            Add(model);
            _appContext.SaveChanges();
        }

        public IEnumerable<ProductAttributesModel> GetAllProductAttributesByProductId(Guid productId)
        {
            List<ProductAttributesModel> productAttributesById = new List<ProductAttributesModel>();
            productAttributesById = (from productAttributes in _appContext.ProductAttributes
                                 where productAttributes.Product_Id == productId && productAttributes.Active
                                 select productAttributes).ToList();
            return productAttributesById;
        }
    }
}
