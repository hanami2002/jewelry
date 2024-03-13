using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class JewelryContext : IdentityDbContext<Account>
    {
        public JewelryContext(DbContextOptions<JewelryContext> options)
            : base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Activity> Activitie { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CheckLog> CheckLogs { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CheckLog>()
                .HasKey(od => new { od.LogId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
