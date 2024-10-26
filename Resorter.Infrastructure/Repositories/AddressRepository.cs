using Microsoft.EntityFrameworkCore;
using Resorter.Domain.Entities;
using Resorter.Domain.Repositories;
using Resorter.Infrastructure.Persistance;

namespace Resorter.Infrastructure.Repositories;

internal class AddressRepository(ResorterDbContext dbContext) : ICrudRepository<Address>
{
    public async Task AddAsync(Address entity)
    {
        dbContext.Addresses.Add(entity);
    }

    public async Task DeleteAsync(Address entity)
    {
        dbContext.Addresses.Remove(entity);
    }

    public async Task<IReadOnlyList<Address>> GetAllAsync()
    {
        var addresses = await dbContext.Addresses
            .Include(e => e.City)
            .AsNoTracking()
            .ToListAsync();

        return addresses;
    }

    public Task<IEnumerable<Address>> GetAllFilteredAsync<TFilter>(TFilter filter) where TFilter : class
    {
        throw new NotImplementedException();
    }

    public async Task<Address> GetByIdAsync(int id)
    {
        var address = await dbContext.Addresses
            .Include(e => e.City)
            .SingleOrDefaultAsync(e => e.Id == id);

        return address;
    }

    public async Task SaveChanges() 
        => await dbContext.SaveChangesAsync();
    
}
