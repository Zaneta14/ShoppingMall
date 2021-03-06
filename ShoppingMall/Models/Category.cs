﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingMall.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required, StringLength(15, MinimumLength =3), Display(Name="Категорија")]
        public string Name { get; set; }
        public ICollection<Subcategory> Subcategories { get; set; }
    }
}
