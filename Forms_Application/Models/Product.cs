using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forms_Application.Models
{
    public class Product
    {
        [Display(Name = "Ürün Id")]
        public int ProductId { get; set; }
        [Display(Name = "Ürün Adı")]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Ürün Fiyatı")]
        public decimal Price { get; set; }
        [Display(Name = "Ürün Resmi")]
        public string Image { get; set; } = string.Empty;
        public bool İsActive { get; set; }
        public int CategoryId { get; set; }
    }
}