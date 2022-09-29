using Model.Models.Category;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Models.Products
{
    public class ProductsModel
    {
        [Key]
        public Guid Product_Id { get; set; }
        public string Product_Name { get; set; }
        public string Product_Description { get; set; }
        public bool Active { get; set; }
        public DateTime Creation_Date { get; set; }
        public DateTime Modification_Date { get; set; }

        public Guid Category_Id { get; set; }
        public CategoryModel Category { get; set; }

        ICollection<ProductImagesModel> Images { get; set; }
        ICollection<ProductAttributesModel> Attributes { get; set; }
        public ProductDetailsModel ProductDetails { get; set; }
    }
}
