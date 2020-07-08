using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingMall.Models
{
    public class AppUser : IdentityUser
    {
        [Display(Name = "Улога")]
        public string Role { get; set; }
        public int? EmployeeId { get; set; }
        [Display(Name = "Вработен")]
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
    }
}
