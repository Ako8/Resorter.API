using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resorter.Domain.Entities;

namespace Resorter.Infrastructure.Persistance.Configuration;

public class DiscountConfiguration : BaseConfiguration<Discount>
{
    public override void Configure(EntityTypeBuilder<Discount> builder)
    {
        builder.HasKey(e => e.Id);

        ConfigureBase(builder, x => x.Name, 100);

        builder.Property(e => e.PercentageAmount)
            .IsRequired();

        builder.Property(e => e.StartDate)
            .IsRequired();

        builder.Property(e => e.EndDate)
            .IsRequired();

        builder.Property(e => e.IsDiscount)
            .IsRequired();

        builder.HasOne(e => e.Car)
            .WithMany(e => e.Discounts)
            .HasForeignKey(e => e.CarId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
