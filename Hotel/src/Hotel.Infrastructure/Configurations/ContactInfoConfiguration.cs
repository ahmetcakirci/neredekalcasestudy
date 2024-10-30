using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ContactInfoConfiguration : IEntityTypeConfiguration<ContactInfo>
{
    public void Configure(EntityTypeBuilder<ContactInfo> builder)
    {
        builder.ToTable("ContactInfo");
        builder.HasKey(ci => ci.Id);
        
        builder.Property(ci => ci.InfoContent)
            .IsRequired() 
            .HasMaxLength(500);

        builder.Property(ci => ci.InfoType)
            .IsRequired();

        builder.HasOne(ci => ci.Hotel)
            .WithMany(h => h.ContactInfos)
            .HasForeignKey(ci => ci.HotelId);
    }
}