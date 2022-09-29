using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Models.Products
{
    public class ProductDetailsModel
    {
        [Key]
        public Guid Product_Details_Id { get; set; }
        public int? Qty_In_Stock { get; set; }
        public string Tax { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public DateTime? Active_Date_From{ get; set; }
        public DateTime? Active_Date_To { get; set; }
        public bool Active { get; set; }
        public DateTime Creation_Date { get; set; }
        public DateTime Modification_Date { get; set; }

        public Guid Product_Id { get; set; }
        public ProductsModel Product { get; set; }
    }
}
