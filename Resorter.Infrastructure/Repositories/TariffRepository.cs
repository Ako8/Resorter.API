using Microsoft.EntityFrameworkCore;
using Resorter.Domain.Entities;
using Resorter.Domain.Repositories;
using Resorter.Infrastructure.Persistance;

namespace Resorter.Infrastructure.Repositories;

internal class TariffRepository(ResorterDbContext dbContext) : IBulkRepository<Tariff>
{
    public async Task AddAllAsync(IEnumerable<Tariff> objs)
    {
        await dbContext.Tariffs.AddRangeAsync(objs);
    }

    public async Task DeleteAllAsync(IEnumerable<Tariff> objs)
    {
        dbContext.Tariffs.RemoveRange(objs);
    }

    public async Task<IReadOnlyList<Tariff>> GetAllAsync()
    {
        return await dbContext.Tariffs.ToListAsync();
    }

    public async Task SaveChanges()
        => await dbContext.SaveChangesAsync();
}
