using LaLiga.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaLiga.Infrastructure.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(d => d.Id).IsRequired();
            builder.Property(d => d.CategoryName).IsRequired()
                                          .HasMaxLength(30);

            builder.Property(d => d.Description).IsRequired()
                                      .HasMaxLength(100);
        }
    }
}
