using PineappleSupermarket.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PineappleSupermarket.Data
{
    public class UserDbContext:DbContext
    {
            
        public UserDbContext() : base("KeyDB") { }
        public DbSet<User> Users { get; set; }

    }
}
