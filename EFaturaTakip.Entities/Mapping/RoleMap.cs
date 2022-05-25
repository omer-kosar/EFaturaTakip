using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Entities.Mapping
{
    internal class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name)
                .HasMaxLength(20).IsRequired();
            builder.ToTable("Role");

            builder.HasData(
               new Role
               {
                   Id = Guid.NewGuid(),
                   Name = "Admin"
               },
               new Role
               {
                   Id = Guid.NewGuid(),
                   Name = "TaxPayer"
               },
               new Role
               {
                   Id = Guid.NewGuid(),
                   Name = "Accountant"
               });
        }
    }
}
