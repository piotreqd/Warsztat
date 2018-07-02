using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Warsztat.Model;

namespace Warsztat
{
    public class WorkschopContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Owner> Owners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-GTPU7TI\SQLEXPRESS;Database=Workschop_copy;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
