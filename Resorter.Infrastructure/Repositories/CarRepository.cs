using Microsoft.EntityFrameworkCore;
using Resorter.Domain.Entities;
using Resorter.Domain.Repositories;
using Resorter.Infrastructure.Persistance;

namespace Resorter.Infrastructure.Repositories;

internal class CarRepository(ResorterDbContext dbContext) : IBaseRepository<Car>
{
    public async Task<Car> AddAsync(Car entity)
    {
        dbContext.Cars.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(Car entity)
    {
        dbContext.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<Car>> GetAllAsync()
    {
        var cars = await dbContext.Cars.AsNoTracking().ToListAsync();
        return cars;
    }

    public async Task<Car> GetByIdAsync(int id)
    {
        var car = await dbContext.Cars.SingleOrDefaultAsync(e => e.Id == id);
        return car;
    }

    public Task SaveChanges()
        => dbContext.SaveChangesAsync();
}
