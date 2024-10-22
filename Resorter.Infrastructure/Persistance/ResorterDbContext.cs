using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Resorter.Application.Entities;
using Resorter.Domain.Entities;
using System.Reflection;

namespace Resorter.Infrastructure.Persistance;

public class ResorterDbContext(DbContextOptions<ResorterDbContext> options) : IdentityDbContext<User, UserRole, int>(options)
{
    internal DbSet<Car> Cars { get; set; }
    internal DbSet<Season> Seasons { get; set; }
    internal DbSet<Tariff> Tariffs { get; set; }
    internal DbSet<City> Cities { get; set; }
    internal DbSet<Address> Addresses { get; set; }
    internal DbSet<Discount> Discounts { get; set; }
    internal DbSet<PriceCondition> PriceConditions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
