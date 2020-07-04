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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employment>()
            .HasOne<Shop>(p => p.Shop)
            .WithMany(p => p.Employees)
            .HasForeignKey(p => p.ShopId);
            //.HasPrincipalKey(p => p.Id);
            builder.Entity<Employment>()
            .HasOne<Employee>(p => p.Employee)
            .WithMany(p => p.Shops)
            .HasForeignKey(p => p.EmployeeId);
            //.HasPrincipalKey(p => p.Id);
            builder.Entity<Subcategory>()
            .HasOne<Category>(p => p.Category)
            .WithMany(p=>p.Subcategories)
            .HasForeignKey(p => p.CategoryId);
            builder.Entity<Shop>()
            .HasOne<Subcategory>(p => p.Subcategory)
            .WithMany(p => p.Shops)
            .HasForeignKey(p => p.SubCategoryId);
            //.HasPrincipalKey(p => p.Id);
        }
    }
}
