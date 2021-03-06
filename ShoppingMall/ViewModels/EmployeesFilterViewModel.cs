﻿using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingMall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingMall.ViewModels
{
    public class EmployeesFilterViewModel
    {
        public IList<Employee> Employees { get; set; }
        public SelectList Shops { get; set; }
        public int ShopId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
