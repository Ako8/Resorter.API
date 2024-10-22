using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resorter.Domain.Junctions;

namespace Resorter.Infrastructure.Persistance.Configuration;

public class UserCityConfiguration : BaseConfiguration<UserCity>
{
    public override void Configure(EntityTypeBuilder<UserCity> builder)
    {
        builder.HasKey(e => new { e.UserId, e.CityId });

        builder.HasOne(e => e.User)
            .WithMany(e => e.UserCities)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.City)
            .WithMany(e => e.UserCities)
            .HasForeignKey(e => e.CityId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
