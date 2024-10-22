using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resorter.Domain.Entities;

namespace Resorter.Infrastructure.Persistance.Configuration;

public class SeasonConfiguration : BaseConfiguration<Season>
{
    public override void Configure(EntityTypeBuilder<Season> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(e => e.StartDate).IsRequired();
        builder.Property(e => e.EndDate).IsRequired();

        builder.HasMany(e => e.UserSeasons)
            .WithOne(e => e.Season)
            .HasForeignKey(e => e.SeasonId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}