using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingMall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingMall.ViewModels
{
    public class ShopsFilterViewModel
    {
        public IList<Shop> Shops { get; set; }
        public SelectList Subcategories { get; set; }
        public int SubcategoryId { get; set; }
        public string SearchString { get; set; }
    }
}
