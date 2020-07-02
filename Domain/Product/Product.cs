using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Product : Entity<short>
    {
        /// <summary>
        /// نام محصول
        /// </summary>
        [Display(Name = "نام")]
        public string Name { get; set; }
        /// <summary>
        /// کد محصول
        /// </summary>
        [Display(Name ="کد")]
        public string Code { get; set; }
        [Display(Name = "قیمت")]
        public int Price { get; set; }
        [Display(Name = "مقدار")]
        public int Quantity { get; set; }
        [ForeignKey(nameof(ProductCategoryId))]
        public ProductCategory ProductCategory { get; set; }
       
        public short ProductCategoryId { get; set; }
        public string ImageName { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

    }
}
