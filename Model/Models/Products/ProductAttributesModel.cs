using Model.Models.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Models.Products
{
    public class ProductAttributesModel
    {
        [Key]
        public Guid Product_Attributes_Id { get; set; }
        public string Values { get; set; }
        public bool Active { get; set; }
        public DateTime Creation_Date { get; set; }
        public DateTime Modification_Date { get; set; }

        public Guid Product_Id { get; set; }
        public ProductsModel Product { get; set; }

        public Guid Attribute_Id { get; set; }
        public AttributesModel Attributes { get; set; }
    }
}
