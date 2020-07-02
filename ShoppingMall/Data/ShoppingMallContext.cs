using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingMall.Models;

namespace ShoppingMall.Data
{
    public class ShoppingMallContext : DbContext
    {
        public ShoppingMallContext (DbContextOptions<ShoppingMallContext> options)
            : base(options)
        {
        }

        public DbSet<ShoppingMall.Models.Category> Category { get; set; }

        public DbSet<ShoppingMall.Models.Subcategory> Subcategory { get; set; }

        public DbSet<ShoppingMall.Models.Shop> Shop { get; set; }

        public DbSet<ShoppingMall.Models.Employee> Employee { get; set; }

        public DbSet<ShoppingMall.Models.Employment> Employment { get; set; }

        public DbSet<ShoppingMall.Models.Application> Application { get; set; }
    }
}
