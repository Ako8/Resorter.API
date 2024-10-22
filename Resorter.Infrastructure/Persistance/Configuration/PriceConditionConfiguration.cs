using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resorter.Domain.Entities;

namespace Resorter.Infrastructure.Persistance.Configuration;

public class PriceConditionConfiguration : BaseConfiguration<PriceCondition>
{
    public override void Configure(EntityTypeBuilder<PriceCondition> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Price)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.HasOne(e => e.Car)
            .WithMany(e => e.PriceConditions)
            .HasForeignKey(e => e.CarId);

        builder.HasOne(e => e.Season)
            .WithMany()
            .HasForeignKey(e => e.SeasonId);

        builder.HasOne(e => e.Tariff)
            .WithMany()
            .HasForeignKey(e => e.TariffId);
    }
}
