using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class HotelConfiguration: IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
        builder.ToTable("Hotel");
        builder.HasKey(h => h.Id);
        builder.Property(h => h.AuthorizedFirstName)
            .IsRequired() 
            .HasMaxLength(100);

        builder.Property(h => h.AuthorizedLastName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(h => h.CompanyTitle)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasMany(h => h.ContactInfos)
            .WithOne(ci => ci.Hotel)
            .HasForeignKey(ci => ci.HotelId); 
    }
}