using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.Configurations
{
    public class OrderConfiguration : BaseEntityConfiguration<Orders>
    {
        public override void Configure(EntityTypeBuilder<Orders> builder)
        {
            base.Configure(builder);

            builder.Property(o => o.OrderDate)
                .IsRequired();

            builder.Property(o => o.TotalAmount)
                .IsRequired();

            builder.HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
