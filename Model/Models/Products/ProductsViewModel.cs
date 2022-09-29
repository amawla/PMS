using Model.Models.Attributes;
using Model.Models.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models.Products
{
    public class ProductsViewModel
    {
        public ProductsModel Product { get; set; }
        public ProductDetailsModel ProductDetails { get; set; }
        public List<ProductAttributesModel> ProductAttributes { get; set; }
        public List<ProductImagesModel> ProductImages { get; set; }
        public List<AttributesGridViewModel> Attributes { get; set; }
        public List<CategoryGridViewModel> CategoriesList { get; set; }
        public object[] AttributeValues { get; set; }
        public string AttributeId { get; set; }



    }
}
