using Microsoft.EntityFrameworkCore;
using Resorter.Domain.Entities;
using Resorter.Domain.Repositories;
using Resorter.Infrastructure.Persistance;

namespace Resorter.Infrastructure.Repositories;

internal class SeasonRepository(ResorterDbContext dbContext) : IBulkRepository<Season>
{
    public async Task AddAllAsync(IEnumerable<Season> objs)
    {
        await dbContext.Seasons.AddRangeAsync(objs);
    }

    public async Task DeleteAllAsync(IEnumerable<Season> objs)
    {
        dbContext.Seasons.RemoveRange(objs);
    }

    public async Task<IReadOnlyList<Season>> GetAllAsync()
    {
        return await dbContext.Seasons.ToListAsync();
    }

    public async Task SaveChanges() 
        =>  await dbContext.SaveChangesAsync();
}
