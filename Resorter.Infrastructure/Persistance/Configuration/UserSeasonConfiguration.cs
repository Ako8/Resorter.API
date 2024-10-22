using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resorter.Domain.Junctions;

namespace Resorter.Infrastructure.Persistance.Configuration;

public class UserSeasonConfiguration : BaseConfiguration<UserSeason>
{
    public override void Configure(EntityTypeBuilder<UserSeason> builder)
    {
        builder.HasKey(e => new { e.UserId, e.SeasonId });

        builder.HasOne(e => e.User)
            .WithMany(e => e.UserSeasons)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Season)
            .WithMany(e => e.UserSeasons)
            .HasForeignKey(e => e.SeasonId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
