using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resorter.Domain.Junctions;

namespace Resorter.Infrastructure.Persistance.Configuration;

public class UserAddressConfiguration : BaseConfiguration<UserAddress>
{
    public override void Configure(EntityTypeBuilder<UserAddress> builder)
    {
        builder.HasKey(e => new { e.UserId, e.AddressId });

        builder.HasOne(e => e.User)
            .WithMany(e => e.UserAddresses)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Address)
            .WithMany(e => e.UserAddresses)
            .HasForeignKey(e => e.AddressId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
