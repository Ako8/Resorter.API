using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resorter.Application.Entities;

namespace Resorter.Infrastructure.Persistance.Configuration;

public class TariffConfiguration : IEntityTypeConfiguration<Tariff>
{
    public void Configure(EntityTypeBuilder<Tariff> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.MinDays).IsRequired();
        builder.Property(x => x.MaxDays).IsRequired();

        builder
            .HasOne(x => x.User)
            .WithMany(u => u.Tariffs)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
