using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resorter.Domain.Junctions;

namespace Resorter.Infrastructure.Persistance.Configuration;

public class UserTariffConfiguration : BaseConfiguration<UserTariff>
{
    public override void Configure(EntityTypeBuilder<UserTariff> builder)
    {
        builder.HasKey(e => new { e.UserId, e.TariffId });

        builder.HasOne(e => e.User)
            .WithMany(e => e.UserTariffs)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Tariff)
            .WithMany(e => e.UserTariffs)
            .HasForeignKey(e => e.TariffId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
