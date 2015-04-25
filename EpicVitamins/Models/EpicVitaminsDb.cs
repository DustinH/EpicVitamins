using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EpicVitamins.Models
{
    public class EpicVitaminsDb : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder mb)
        {
            mb.Entity<Order>().HasKey(m => m.OrderID)
                .ToTable("Orders");

            mb.Entity<OrderDetail>().HasKey(m => m.OrderDetailID)
                .ToTable("OrderDetails");
            
        }
    }
}