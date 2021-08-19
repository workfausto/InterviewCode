using Microsoft.EntityFrameworkCore;
using NetCore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Data
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options) { }

        public DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().HasData(
                new { Id = 1, Name = "Barbie Developer", AgeRestriction = 12, 
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt.",
                    Company = "Mattel",
                    Price = Convert.ToDecimal(25.99) },
                new { Id = 2, Name = "xyc", AgeRestriction = 4,
                    Description = "Ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation.", 
                    Company = "Marvel",
                    Price = Convert.ToDecimal(75.50) },
                new { Id = 3, Name = "abc", AgeRestriction = 18, 
                    Description = "Duis aute irure dolor in reprehenderit in voluptate.", 
                    Company = "Nintendo",
                    Price = Convert.ToDecimal(99.99)}
                );
        }

    }
}
