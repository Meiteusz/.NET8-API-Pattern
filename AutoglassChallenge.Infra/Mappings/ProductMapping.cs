using AutoglassChallenge.Domain.Entities;
using AutoglassChallenge.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoglassChallenge.Infra.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .UseIdentityColumn()
                   .HasColumnType("BIGINT")
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.Description)
                   .IsRequired()
                   .HasColumnName("Description")
                   .HasColumnType("VARCHAR(150)")
                   .HasMaxLength(150);

            builder.Property(x => x.Status)
                   .IsRequired()
                   .HasColumnName("Status")
                   .HasDefaultValue(eProductStatus.Active);

            builder.Property(x => x.ManufacturingDate)
                   .HasColumnName("ManufacturingDate")
                   .HasColumnType("datetime2");

            builder.Property(x => x.ExpirationDate)
                   .HasColumnName("ExpirationDate")
                   .HasColumnType("datetime2");

            builder.HasOne(a => a.Supplier)
                   .WithMany(b => b.Products)
                   .HasForeignKey(c => c.SupplierId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
