using Microsoft.EntityFrameworkCore;
using Resorter.Domain.Entities;
using Resorter.Domain.Exceptions;
using Resorter.Domain.Repositories;
using Resorter.Infrastructure.Persistance;

namespace Resorter.Infrastructure.Repositories;

internal class SeasonRepository(ResorterDbContext dbContext) : ISeasonRepository
{
    public Task AddAsync(Season entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Season>> AddRangeAsync(IEnumerable<Season> seasons)
    {
        dbContext.Seasons.AddRange(seasons);
        return seasons;
    }

    public Task DeleteAsync(Season entity)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Season>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Season> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyList<Season>> GetByIdsAndUserAsync(List<int> ids, int userId)
    {
        var seasons = await dbContext.Seasons
            .Include(s => s.UserSeasons)
            .Where(s => ids.Contains(s.Id) &&
                       s.UserSeasons.Any(us => us.UserId == userId))
            .ToListAsync();

        if (seasons.Count != ids.Count)
            throw new NotFoundException(nameof(Season),$"{userId}");

        return seasons;
    }

    public async Task SaveChanges() 
        =>  await dbContext.SaveChangesAsync();
}
