using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class PrintPaymentContext : DbContext
    {
        public DbSet<PrintQuota> PrintQuotas { get; set; }
        public DbSet<Student> Students { get; set; }


        public PrintPaymentContext(DbContextOptions<PrintPaymentContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                // fallback, usually unused when configured in Program.cs
                builder.UseSqlServer("Server=192.168.1.166;Database=PrintDB;User Id=sa;Password=Bfo12345;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasIndex(s => s.UID)
                .IsUnique();

            modelBuilder.Entity<Student>()
                .HasIndex(s => s.Username)
                .IsUnique();

            modelBuilder.Entity<PrintQuota>()
                .HasOne(pq => pq.Student)
                .WithMany(s => s.PrintQuotas)
                .HasForeignKey(pq => pq.StudentId);
        }
    }
}
