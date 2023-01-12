using LaLiga.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaLiga.Infrastructure.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(d => d.Id).IsRequired();
            builder.Property(d => d.Name).IsRequired()
                                         .HasMaxLength(30);

            builder.Property(d => d.UnitPrice).HasColumnType("decimal(18,2)");

            //builder.HasOne(d => d.Category)
            //       .WithMany()
            //       .HasForeignKey(d => d.CategoryId);

        }
    }
}
