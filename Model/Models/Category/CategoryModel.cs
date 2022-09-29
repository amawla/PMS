using Model.Models.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Models.Category
{
    public class CategoryModel
    {
        [Key]
        public Guid Category_Id { get; set; }
        public string Category_Name { get; set; }
        public bool Active { get; set; }
        public DateTime Creation_Date { get; set; }
        public DateTime Modification_Date { get; set; }

        public ICollection<ProductsModel> Products { get; set; }
    }
}
