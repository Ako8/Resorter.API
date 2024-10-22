using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resorter.Domain.Entities;

namespace Resorter.Infrastructure.Persistance.Configuration;

public class CarConfiguration : BaseConfiguration<Car>
{
    public override void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasKey(e => e.Id);

        ConfigureBase(builder, x => x.Brand, 50);
        ConfigureBase(builder, x => x.Model, 50);
        ConfigureBase(builder, x => x.LicensePlate, 20);

        builder.Property(e => e.YearOfManufacture).IsRequired();
        builder.Property(e => e.BodyColor).IsRequired();
        builder.Property(e => e.BodyType).IsRequired();


        builder.OwnsOne(car => car.Insurance);
        builder.OwnsOne(car => car.Engine);
        builder.OwnsOne(car => car.Specifications);
        builder.OwnsOne(car => car.Chassis);



        builder.HasMany(e => e.Discounts)
            .WithOne(e => e.Car)
            .HasForeignKey(e => e.CarId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(e => e.PriceConditions)
            .WithOne(e => e.Car)
            .HasForeignKey(e => e.CarId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
