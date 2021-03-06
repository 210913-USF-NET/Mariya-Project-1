using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DL
    {
    public class StoreDBContext : DbContext
{
        public StoreDBContext() : base() {}

        public StoreDBContext(DbContextOptions<StoreDBContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<LineItem> LineItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<StoreFront> StoreFronts { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        }
    }
