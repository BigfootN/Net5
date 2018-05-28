using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Login> Logins { get; set; }
    }
}
