using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resorter.Domain.Junctions;

namespace Resorter.Infrastructure.Persistance.Configuration;

public class UserCarConfiguration : BaseConfiguration<UserCar>
{
    public override void Configure(EntityTypeBuilder<UserCar> builder)
    {
        builder.HasKey(e => new { e.UserId, e.CarId });

        builder.HasOne(e => e.User)
            .WithMany(e => e.UserCars)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Car)
            .WithMany(e => e.UserCars)
            .HasForeignKey(e => e.CarId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
