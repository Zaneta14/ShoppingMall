using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingMall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingMall.ViewModels
{
    public class EmployeesInShopFilterViewModel
    {
        public IList<Employment> Employments { get; set; }
        public List<SelectListItem> SelectList { get; set; }
        public string SelectListId { get; set; }
    }
}
