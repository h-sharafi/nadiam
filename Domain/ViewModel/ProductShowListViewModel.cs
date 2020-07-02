using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ProductShowListViewModel
    {
        public string ProductCategoryName { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
