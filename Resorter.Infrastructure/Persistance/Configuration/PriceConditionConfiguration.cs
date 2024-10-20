using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resorter.Application.Entities;

namespace Resorter.Infrastructure.Persistance.Configuration;

public class PriceConditionConfiguration : IEntityTypeConfiguration<PriceCondition>
{
    public void Configure(EntityTypeBuilder<PriceCondition> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Price).HasPrecision(18, 2).IsRequired();

        builder.HasOne(x => x.Car)
            .WithMany(x => x.PriceConditions)
            .HasForeignKey(x => x.CarId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Season)
            .WithMany()
            .HasForeignKey(x => x.SeasonId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Tariff)
            .WithMany()
            .HasForeignKey(x => x.TariffId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
