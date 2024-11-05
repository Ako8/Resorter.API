using Microsoft.EntityFrameworkCore;
using Resorter.Domain.Entities;
using Resorter.Domain.Repositories;
using Resorter.Infrastructure.Persistance;

namespace Resorter.Infrastructure.Repositories;

internal class DiscountRepository(ResorterDbContext dbContext) : ICrudRepository<Discount>
{
    public async Task AddAsync(Discount entity)
    {
        dbContext.Discounts.Add(entity);
    }

    public async Task DeleteAsync(Discount entity)
    {
        dbContext.Discounts.Remove(entity);
    }

    public async Task<IReadOnlyList<Discount>> GetAllAsync()
    {
        return await dbContext.Discounts.AsNoTracking().ToListAsync();
    }

    public Task<IEnumerable<Discount>> GetAllFilteredAsync<TFilter>(TFilter filter) where TFilter : class
    {
        throw new NotImplementedException();
    }

    public async Task<Discount> GetByIdAsync(int id)
    {
        var discount = await dbContext.Discounts.SingleOrDefaultAsync(x => x.Id == id);
        return discount;
    }

    public Task<IReadOnlyList<Season>> GetByIdsAndUserAsync(List<int> ids, int userId)
    {
        throw new NotImplementedException();
    }

    public async Task SaveChanges()
        => await dbContext.SaveChangesAsync();
}
