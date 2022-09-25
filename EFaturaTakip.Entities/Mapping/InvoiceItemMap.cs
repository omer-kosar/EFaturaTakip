using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFaturaTakip.Entities.Mapping
{
    public class InvoiceItemMap : IEntityTypeConfiguration<InvoiceItem>
    {
        public void Configure(EntityTypeBuilder<InvoiceItem> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.StockId).IsRequired();
            builder.Property(t => t.InvoiceId).IsRequired();
            builder.Property(t => t.Comment).IsRequired(false).HasMaxLength(250);
            builder.Property(t => t.Price).HasColumnType("money").IsRequired(true);
            builder.Property(t => t.PriceWithTax).HasColumnType("money").IsRequired(true);
            builder.Property(t => t.TotalPrice).HasColumnType("money").IsRequired(true);
            builder.Property(t => t.TotalPriceWithTax).HasColumnType("money").IsRequired(true);
        }
    }
}
