using LManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LManagement.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Lead> Leads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Lead>(entity =>
            {
                entity.ToTable("leads");
                entity.HasKey(e => e.Id);

                // Required fields
                entity.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(10);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(25);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(25);
                entity.Property(e => e.Status).IsRequired().HasMaxLength(25);
                entity.Property(e => e.Source).IsRequired().HasMaxLength(25);
                entity.Property(e => e.CreatedAt).IsRequired();

                // Optional fields with max length
                entity.Property(e => e.Email).HasMaxLength(50);
                entity.Property(e => e.Company).HasMaxLength(100);
                entity.Property(e => e.ZohoBiginId).HasMaxLength(100);

                // Index
                entity.HasIndex(e => e.PhoneNumber);
                entity.HasIndex(e => e.Source);
            });
        }
    }
}
