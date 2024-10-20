using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Resorter.Application.Entities;
using Resorter.Infrastructure.Persistance.Configuration;

namespace Resorter.Infrastructure.Persistance;

internal class ResorterDbContext(DbContextOptions<ResorterDbContext> options) : IdentityDbContext(options)
{
    internal DbSet<Car> Cars { get; set; }
    internal DbSet<Season> Seasons { get; set; }
    internal DbSet<Tariff> Tariffs { get; set; }
    internal DbSet<PriceCondition> PriceConditions { get; set; }
    internal DbSet<Discount> Discounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SeasonConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TariffConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PriceConditionConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DiscountConfiguration).Assembly);
    }
}
