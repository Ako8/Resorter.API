using Microsoft.EntityFrameworkCore;
using Resorter.Domain.Entities;
using Resorter.Domain.Repositories;
using Resorter.Infrastructure.Persistance;

namespace Resorter.Infrastructure.Repositories;

internal class CarRepository(ResorterDbContext dbContext) : ICrudRepository<Car>
{
    public async Task AddAsync(Car entity)
    {
        dbContext.Cars.Add(entity);
    }

    public async Task DeleteAsync(Car entity)
    {
        dbContext.Cars.Remove(entity);
    }

    public async Task<IReadOnlyList<Car>> GetAllAsync()
    {
        var cars = await dbContext.Cars.AsNoTracking().ToListAsync();
        return cars;
    }

    public async Task<Car> GetByIdAsync(int id)
    {
        var car = await dbContext.Cars
            .SingleOrDefaultAsync(e => e.Id == id);
        return car;
    }

    public async Task SaveChanges()
        => await dbContext.SaveChangesAsync();
}
