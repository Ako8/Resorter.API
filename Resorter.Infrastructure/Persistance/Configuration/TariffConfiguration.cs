using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resorter.Domain.Entities;

namespace Resorter.Infrastructure.Persistance.Configuration;

public class TariffConfiguration : BaseConfiguration<Tariff>
{
    public override void Configure(EntityTypeBuilder<Tariff> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.MinDays)
            .IsRequired();

        builder.Property(e => e.MaxDays)
            .IsRequired();

        builder.HasMany(e => e.UserTariffs)
            .WithOne(e => e.Tariff)
            .HasForeignKey(e => e.TariffId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
