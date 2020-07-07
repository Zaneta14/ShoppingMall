using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingMall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingMall.ViewModels
{
    public class EmploymentsFilterViewModel
    {
        public IList<Employment> Employments { get; set; }
        public SelectList Shops { get; set; }
        public int ShopId { get; set; }
        public SelectList Employees { get; set; }
        public int EmployeeId { get; set; }
    }
}
