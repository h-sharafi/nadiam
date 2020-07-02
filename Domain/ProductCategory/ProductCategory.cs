using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class ProductCategory:Entity<short>
    {
        [Display(Name ="نام")]
        [Required(ErrorMessage ="{0} ضروری می باشد")]
        public string Name { get; set; }
        public ProductCategory Parent { get; set; }
        [Display(Name="پدر")]
        public short? ParentId { get; set; }
        public ICollection<ProductCategory> Children { get; set; }
        public ICollection<Product> Products{ get; set; }

    }
}
