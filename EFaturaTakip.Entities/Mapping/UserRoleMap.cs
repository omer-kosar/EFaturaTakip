using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Entities.Mapping
{
    internal class UserRoleMap : IEntityTypeConfiguration<UserRole>
    {
        public UserRoleMap()
        {
            //HasKey(t => t.Id);
            //ToTable("UserRole");

            //HasRequired(ur => ur.User).WithMany(r => r.Roles)
            //    .HasForeignKey(us => us.UserId).WillCascadeOnDelete(true);

            //HasRequired(ur => ur.Role).WithMany(u => u.Users)
            //    .HasForeignKey(ur => ur.RoleId).WillCascadeOnDelete(true);
        }

        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(t => t.Id);
            builder.ToTable("UserRole");
            builder.HasOne(t => t.User).WithMany(t => t.Roles).HasForeignKey(t => t.UserId);
            builder.HasOne(t => t.Role).WithMany(t => t.Users).HasForeignKey(t => t.RoleId);
        }
    }
}
