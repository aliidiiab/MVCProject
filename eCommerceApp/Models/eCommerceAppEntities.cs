﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Models
{
    
    public class eCommerceAppEntities:IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public eCommerceAppEntities() : base()
        {
        }
        public eCommerceAppEntities(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=eCommerceDBv;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }

    public class ApplicationUser : IdentityUser
    {
        
    }
}
