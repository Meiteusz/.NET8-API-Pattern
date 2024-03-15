using AutoglassChallenge.Domain.Entities;
using AutoglassChallenge.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace AutoglassChallenge.Infra
{
    public class AutoglassChallengeContext : DbContext
    {
        public AutoglassChallengeContext(DbContextOptions<AutoglassChallengeContext> options)
            : base(options)
        { }

        public AutoglassChallengeContext()
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new SupplierMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
