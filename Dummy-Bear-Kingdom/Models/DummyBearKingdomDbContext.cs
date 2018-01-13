using System;
using Microsoft.EntityFrameworkCore;

namespace DummyBearKingdom.Models
{
    public class DummyBearKingdomDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DummyBearKingdomDbContext()
        {

        }

        public DummyBearKingdomDbContext(DbContextOptions<DummyBearKingdomDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(@"Server=localhost;Port=8889;database=dummybearkingdom;uid=root;pwd=root;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}