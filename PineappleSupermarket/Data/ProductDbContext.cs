using PineappleSupermarket.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PineappleSupermarket.Data
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext() : base("KeyDB") { }
        public DbSet<Product> Products { get; set; }

    }
}