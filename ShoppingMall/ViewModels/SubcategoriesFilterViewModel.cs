using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingMall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingMall.ViewModels
{
    public class SubcategoriesFilterViewModel
    {
        public IList<Subcategory> Subcategories { get; set; }
        public SelectList Categories { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
