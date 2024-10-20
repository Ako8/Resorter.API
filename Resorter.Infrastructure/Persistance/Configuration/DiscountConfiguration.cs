
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resorter.Application.Entities;

namespace Resorter.Infrastructure.Persistance.Configuration;

public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.StartDate).IsRequired();
        builder.Property(x => x.EndDate).IsRequired();
        builder.Property(x => x.IsDiscount).IsRequired();
        builder.Property(x => x.PrecentageAmount).IsRequired();

        builder
            .HasOne(e => e.Car)
            .WithMany(c => c.Discounts)
            .HasForeignKey(e => e.CarId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
