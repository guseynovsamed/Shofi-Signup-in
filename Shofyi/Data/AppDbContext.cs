using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shofyi.Models;

namespace Shofyi.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
           .HasData(
            new Category
{
    Id = 1,
    Name = "Headphones",
    Image = "headphone-category.png"
},
            new Category
{
    Id = 2,
    Name = "Mobile Tablets",
    Image = "mobile-category.png"
},
            new Category
{
    Id = 3,
    Name = "CPU Heat Pipes",
    Image = "pc-category.png"
},  
            new Category
{
    Id = 4,
    Name = "Smart Watch",
    Image = "watch-category.png"
},
            new Category
{
    Id = 5,
    Name = "Bluetooth",
    Image = "acces-category.png"
}
            );
            base.OnModelCreating(modelBuilder);
        }

           

    }
}

