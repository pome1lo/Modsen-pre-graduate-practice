using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.Configurations
{
    public class UserConfiguration : BaseEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(150);

           
            builder.HasIndex(u => u.Email).IsUnique();

         
        }
    }
}
