using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Entities.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(t => t.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(t => t.LastName).IsRequired()
               .HasMaxLength(50);
            builder.Property(t => t.Phone).IsRequired().HasMaxLength(14);
            builder.Property(t => t.Password).IsRequired().HasMaxLength(10);
            builder.Property(t => t.Email).HasMaxLength(50);
            builder.Property(t => t.ServiceUserName).HasMaxLength(50).IsRequired();
            builder.Property(t => t.ServicePassword).HasMaxLength(50).IsRequired();
            builder.ToTable("User");
        }
    }
}
