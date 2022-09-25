using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Entities.Mapping
{
    public class InvoiceMap : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Date).IsRequired();
            builder.Property(t => t.Comment).IsRequired(false).HasMaxLength(250);
            builder.Property(x => x.CompanyId).IsRequired();

            builder.HasMany(x => x.InvoiceItems).WithOne(x => x.Invoice).IsRequired();
        }
    }
}
