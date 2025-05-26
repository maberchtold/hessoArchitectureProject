using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class PrintPaymentContext : DbContext
    {
        public DbSet<PrintQuota> PrintQuotas { get; set; }

        public PrintPaymentContext(DbContextOptions<PrintPaymentContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                // fallback, usually unused when configured in Program.cs
                builder.UseSqlServer("Server=192.168.1.166;Database=DigitecDB;User Id=sa;Password=Bfo12345;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Indexes for lookup performance
            modelBuilder.Entity<PrintQuota>()
                .HasIndex(p => p.UID);

            modelBuilder.Entity<PrintQuota>()
                .HasIndex(p => p.Username);
        }
    }
}
