using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resorter.Domain.Entities;

namespace Resorter.Infrastructure.Persistance.Configuration;

public class AddressConfiguration : BaseConfiguration<Address>
{
    public override void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(e => e.Id);

        ConfigureBase(builder, x => x.Location, 200);
        ConfigureBase(builder, x => x.DeliveryTime, 200);

        builder.Property(e => e.DeliveryFee)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.HasMany(e => e.UserAddresses)
            .WithOne(e => e.Address)
            .HasForeignKey(e => e.AddressId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(a => a.City)
            .WithMany()
            .HasForeignKey(a => a.CityId);
    }
}
