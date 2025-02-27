using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataAccessLayer.Models;

namespace DataAccessLayer.Data.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Categories>
{
    public void Configure(EntityTypeBuilder<Categories> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
               .ValueGeneratedOnAdd();

        builder.Property(c => c.Name)
               .IsRequired()
               .HasMaxLength(255);

        builder.HasIndex(c => c.Name)
               .IsUnique();
    }
}