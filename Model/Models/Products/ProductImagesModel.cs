using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Models.Products
{
    public class ProductImagesModel
    {
        [Key]
        public Guid Product_Images_Id { get; set; }
        public string Image_Path { get; set; }
        public bool Active { get; set; }
        public DateTime Creation_Date { get; set; }
        public DateTime Modification_Date { get; set; }

        public Guid Product_Id { get; set; }
        public ProductsModel Product { get; set; }
    }
}
