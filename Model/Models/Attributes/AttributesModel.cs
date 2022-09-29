using Model.Models.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Models.Attributes
{
    public class AttributesModel
    {
        [Key]
        public Guid Attribute_Id { get; set; }
        public string Attribiute_Name { get; set; }
        public bool Active { get; set; }
        public DateTime Creation_Date { get; set; }
        public DateTime Modification_Date { get; set; }

        ICollection<ProductAttributesModel> ProductAttributes { get; set; }
    }
}
