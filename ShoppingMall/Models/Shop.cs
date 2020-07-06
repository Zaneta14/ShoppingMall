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
        [Required, StringLength(30, MinimumLength = 2), Display(Name="Име")]
        public string Name { get; set; }
        [Required, Display(Name = "Лого")]
        public string LogoUrl { get; set; }
        [Required, Display(Name = "Слика")]
        public string ImageUrl { get; set; }
        [Required, Display(Name="Локација")]
        public string Location { get; set; }
        [Required, Display(Name = "Работно време")]
        public string WorkingHours { get; set; }
        [Display(Name="Телефонски број")]
        public string TelephoneNumber { get; set; }
        [Display(Name = "Email адреса")]
        public string Email { get; set; }
        [Required, StringLength(2000, MinimumLength =20)]
        [Display(Name= "Опис")]
        public string Description { get; set; }
        [Display(Name="Подкатегорија")]
        public int SubCategoryId { get; set; }
        public Subcategory Subcategory { get; set; }
        [Display(Name="Вработени")]
        public ICollection<Employment> Employees { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}
