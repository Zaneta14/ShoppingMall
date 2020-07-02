using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingMall.Models
{
    public class Shop
    {
        public int Id { get; set; }
        [Required, StringLength(15, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        public string LogoUrl { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required, Display(Name="Локација")]
        public string Location { get; set; }
        [Required, Display(Name = "Работно време")]
        public string WorkingHours { get; set; }
        [Display(Name="Телефонски број")]
        public string TelephoneNumber { get; set; }
        [Display(Name = "Email адреса")]
        public string Email { get; set; }
        [Required, StringLength(400, MinimumLength =20)]
        public string Description { get; set; }
        public int SubCategoryId { get; set; }
        public Subcategory Subcategory { get; set; }
        [Display(Name="Вработени")]
        public ICollection<Employment> Employees { get; set; }
    }
}
