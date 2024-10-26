using Microsoft.EntityFrameworkCore;
using Resorter.Domain.Entities;
using Resorter.Domain.Repositories;
using Resorter.Infrastructure.Persistance;

namespace Resorter.Infrastructure.Repositories;

internal class PriceConditionRepository(ResorterDbContext dbContext) : ICrudRepository<PriceCondition>
{
    public Task AddAsync(PriceCondition entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(PriceCondition entity)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<PriceCondition>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PriceCondition>> GetAllFilteredAsync<TFilter>(TFilter filter) where TFilter : class
    {
        throw new NotImplementedException();
    }

    public async Task<PriceCondition> GetByIdAsync(int id)
    {
        var priceCond = await dbContext.PriceConditions
            .SingleOrDefaultAsync(e => e.Id == id);
        return priceCond;
    }

    public Task SaveChanges()
    {
        throw new NotImplementedException();
    }
}
