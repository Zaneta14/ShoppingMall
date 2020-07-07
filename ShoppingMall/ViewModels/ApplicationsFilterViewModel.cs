using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingMall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingMall.ViewModels
{
    public class ApplicationsFilterViewModel
    {
        public IList<Application> Applications { get; set; }
        public SelectList Shops { get; set; }
        public int ShopId { get; set; }
        public List<SelectListItem> Sorts { get; set; }
        public string SelectedSort { get; set; }
    }
}
