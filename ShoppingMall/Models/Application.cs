using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingMall.Models
{
    public class Application
    {
        public int Id { get; set; }
        [Required, Display(Name = "Име")]
        public string FirstName { get; set; }
        [Required, Display(Name = "Презиме")]
        public string LastName { get; set; }
        [Required, Url, Display(Name = "CV")]
        public string CVUrl { get; set; }
        [DataType(DataType.Date), Display(Name = "Датум на аплицирање")]
        public DateTime ApplicationDate { get; set; }
        public int ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}
