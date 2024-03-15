using AutoglassChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoglassChallenge.Infra.Mappings
{
    public class SupplierMapping : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers");

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

            builder.Property(x => x.Cnpj)
                   .IsRequired()
                   .HasColumnName("Cnpj")
                   .HasColumnType("VARCHAR(18)")
                   .HasMaxLength(18);
        }
    }
}
