using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFaturaTakip.Entities.Mapping
{
    public class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(t => t.Title).HasMaxLength(255).IsRequired(false);
            builder.Property(t => t.TcKimlikNo).HasMaxLength(11).IsRequired(false);
            builder.Property(t => t.FirstName).HasMaxLength(50).IsRequired(false);
            builder.Property(t => t.LastName).HasMaxLength(50).IsRequired(false);
            builder.Property(t => t.VergiNo).HasMaxLength(10).IsRequired(false);
            builder.Property(t => t.TaxOffice).HasMaxLength(100).IsRequired(false);
            builder.Property(t => t.Province).HasMaxLength(20).IsRequired(false);
            builder.Property(t => t.District).HasMaxLength(20).IsRequired(false);
            builder.Property(t => t.ApartmentNumber).HasMaxLength(20).IsRequired(false);
            builder.Property(t => t.FlatNumber).HasMaxLength(20).IsRequired(false);
            builder.Property(t => t.Country).HasMaxLength(20).IsRequired(false);
            builder.Property(t => t.FaxNumber).HasMaxLength(17).IsRequired(false);
            builder.Property(t => t.MobilePhone).HasMaxLength(17).IsRequired(true);
            builder.Property(t => t.ServiceUserName).HasMaxLength(50).IsRequired(false);
            builder.Property(t => t.ServicePassword).HasMaxLength(50).IsRequired(false);
            builder.Property(t => t.CommercialRegistrationNumber).HasMaxLength(50);
            builder.Property(t => t.CentralRegistrationNumber).HasMaxLength(50);

            builder.HasMany(t => t.Users).WithOne(t => t.Company).IsRequired(false);
            builder.HasMany(t => t.Stocks).WithOne(t => t.Company).IsRequired();
            builder.HasOne(t => t.CompanyParent).WithMany(t => t.Companies).HasForeignKey(t => t.CompanyId)
                .IsRequired(false).OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Company");
        }

    }
}
