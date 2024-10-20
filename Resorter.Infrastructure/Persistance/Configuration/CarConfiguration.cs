using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resorter.Application.Entities;

namespace Resorter.Infrastructure.Persistance.Configuration;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.RegistrationCertificate).IsRequired();
        builder.Property(e => e.Brand).IsRequired();
        builder.Property(e => e.Model).IsRequired();
        builder.Property(e => e.LicensePlate).IsRequired();
        builder.Property(e => e.YearOfManufacturer).IsRequired();
        builder.Property(e => e.BodyColor).IsRequired();
        builder.Property(e => e.BodyType).IsRequired();

        builder
            .HasOne(e => e.User)
            .WithMany(u => u.Cars)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.OwnsOne(e => e.Insurance, ins =>
        {
            ins.Property(i => i.DepositAmount).HasPrecision(18, 2);
            ins.Property(i => i.FranchiseAmount).HasPrecision(18, 2);

        });
        builder.OwnsOne(e => e.Engine);
        builder.OwnsOne(e => e.Specifications);
        builder.OwnsOne(e => e.Chassis);

        builder
            .HasMany(e => e.PriceConditions)
            .WithOne()
            .HasForeignKey(fk => fk.CarId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(e => e.Discounts)
            .WithOne()
            .HasForeignKey(fk => fk.CarId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
