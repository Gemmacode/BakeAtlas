using BakeAtlas.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeAtlas.Persistence.Context
{
    public class BakeAtlasDbContext : IdentityDbContext<Customer>
    {
        public BakeAtlasDbContext(DbContextOptions<BakeAtlasDbContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; } 
        public DbSet<BakeryProduct> BakeryProducts { get; set;}
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
