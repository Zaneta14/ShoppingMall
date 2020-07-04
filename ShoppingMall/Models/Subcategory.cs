using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingMall.Models
{
    public class Subcategory
    {
        public int Id { get; set; }
        [Required, StringLength(25, MinimumLength = 3), Display(Name = "Подкатегорија")]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        [Display(Name="Категорија")]    
        public Category Category { get; set; }
        public ICollection<Shop> Shops { get; set; }
    }
}
