using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductApp.Domain.Entities;

namespace ProductApp.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = Guid.NewGuid(), Name = "Kalem", Quantity = 300, Value=10 },
                new Product() { Id = Guid.NewGuid(), Name = "Kağıt", Quantity = 350, Value = 3 },
                new Product() { Id = Guid.NewGuid(), Name = "Kitap", Quantity = 500, Value = 5 }

            );

            base.OnModelCreating(modelBuilder);
        }
    }
}