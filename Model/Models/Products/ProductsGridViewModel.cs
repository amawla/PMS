using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models.Products
{
    public class ProductsGridViewModel : ProductsModel
    {
        public string Category_Name { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }
    }
}
