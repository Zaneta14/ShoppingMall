using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingMall.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required, Display(Name ="Име")]
        public string FirstName { get; set; }
        [Required, Display(Name = "Презиме")]
        public string LastName { get; set; }
        public string PictureUrl { get; set; }
        [Required, Url, Display(Name ="CV")]
        public string CVUrl { get; set; }
        [Required, Display(Name ="Email адреса")]
        public string Email { get; set; }
        public ICollection<Employment> Shops { get; set; }
    }
}
