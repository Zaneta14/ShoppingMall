using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingMall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingMall.ViewModels
{
    public class ShopEmployeesEditViewModel
    {
        public Shop Shop { get; set; }
        public IEnumerable<int> SelectedEmployees { get; set; }
        public IEnumerable<SelectListItem> EmployeeList { get; set; }
    }
}
