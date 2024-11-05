using Resorter.Domain.Entities;
using Resorter.Domain.Repositories;
using Resorter.Infrastructure.Persistance;

namespace Resorter.Infrastructure.Repositories;

internal class PriceConditionRepository(ResorterDbContext dbContext) : IPriceConditionRepository
{
    public Task AddAsync(PriceCondition entity)
    {
        throw new NotImplementedException();
    }

    public async Task AddRangeAsync(IEnumerable<PriceCondition> priceConditions)
    {
        dbContext.PriceConditions.AddRangeAsync(priceConditions);
    }

    public Task DeleteAsync(PriceCondition entity)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<PriceCondition>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<PriceCondition> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task SaveChanges()
        => await dbContext.SaveChangesAsync();
}
