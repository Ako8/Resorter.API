using Microsoft.EntityFrameworkCore;
using Resorter.Domain.Entities;
using Resorter.Domain.Exceptions;
using Resorter.Domain.Repositories;
using Resorter.Infrastructure.Persistance;

namespace Resorter.Infrastructure.Repositories;

internal class TariffRepository(ResorterDbContext dbContext) : ITariffRepository
{
    public Task AddAsync(Tariff entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Tariff>> AddRangeAsync(IEnumerable<Tariff> tariffs)
    {
        dbContext.AddRange(tariffs);
        return tariffs;
    }

    public Task DeleteAsync(Tariff entity)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Tariff>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Tariff> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyList<Tariff>> GetByIdsAndUserAsync(List<int> ids, int userId)
    {
        var tariffs = await dbContext.Tariffs
            .Include(t => t.UserTariffs)
            .Where(t => ids.Contains(t.Id) &&
                       t.UserTariffs.Any(ut => ut.UserId == userId))
            .ToListAsync();

        if (tariffs.Count != ids.Count)
            throw new NotFoundException(nameof(Tariff), $"{userId}");

        return tariffs;
    }

    public async Task SaveChanges()
        => await dbContext.SaveChangesAsync();
}
