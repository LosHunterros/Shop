using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Models;
using System.Collections.Generic;

namespace Shop.Database
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext() : base() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
            //Database.Migrate();
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStock> OrderStocks { get; set; }
        public DbSet<StockOnHold> StocksOnHold { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Konfiguracja klucza głównego dla encji OrderStock
            builder.Entity<OrderStock>()
                .HasKey(x => new { x.StockId, x.OrderId });

            // Wstawienie danych do tabeli Product
            builder.Entity<Product>().HasData(new List<Product>
    {
        new Product
        {
            Id = 1,
            Description = "Bardzo ładna koszulka",
            Name = "T-shirt",
            Value = 25.99M
        },
        new Product
        {
            Id = 2,
            Description = "Ciepła i wygodna kurtka",
            Name = "Kurtka",
            Value = 104.99M
        },
        new Product
        {
            Id = 3,
            Description = "Wygodne buty",
            Name = "Buty",
            Value = 89.99M
        }
    });

            builder.Entity<Stock>().HasData(new List<Stock> {
                new Stock
                {
                    Id=1,
                    Description = "Coś tam",
                    ProductId = 1,
                    Qty = 3,

                },
                new Stock
                {
                    Id=2,
                    Description = "Coś tam",
                    ProductId = 2,
                    Qty = 10,

                },
                new Stock
                {
                    Id=3,
                    Description = "Coś tam",
                    ProductId = 3,
                    Qty = 10,

                }

                });

            // Wywołanie bazowej metody OnModelCreating
            base.OnModelCreating(builder);


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(System.Console.WriteLine);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MyShop;Trusted_Connection=true;MultipleActiveResultSets=true");
            }


            base.OnConfiguring(optionsBuilder);
        }


    }
}
