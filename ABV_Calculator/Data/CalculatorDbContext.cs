using ABV_Calculator.Models;

namespace ABV_Calculator.Data;
using Microsoft.EntityFrameworkCore;



    public class CalculatorDbContext : DbContext
    {
        public CalculatorDbContext(DbContextOptions<CalculatorDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Calculation> Calculations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the Conversion entity
            modelBuilder.Entity<Calculation>()
                .HasKey(c => c.Id);
        }
    }
