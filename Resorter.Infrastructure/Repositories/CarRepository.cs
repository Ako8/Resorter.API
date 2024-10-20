using Microsoft.EntityFrameworkCore;
using Resorter.Application.Entities;
using Resorter.Infrastructure.Persistance;

namespace Resorter.Infrastructure.Repositories;

internal class CarRepository(ResorterDbContext dbContext) : ICarRepository
{
    public async Task<IEnumerable<Car>> GetAllAsync()
    {
        var cars = await dbContext.Cars
            .Include(x => x.PriceConditions)
            .AsNoTracking()
            .ToListAsync();
        return cars;
    }

    public async Task<IEnumerable<Car>> GetAllMatchingAsync(string? searchPhrase)
    {
        var searchPhraseLower = searchPhrase?.ToLower();

        var cars = await dbContext.Cars
            .Where(r => searchPhraseLower == null ||  (r.Brand.ToLower().Contains(searchPhraseLower)
                || r.Model.ToLower().Contains(searchPhraseLower)))
            .Include(x => x.PriceConditions)
            .AsNoTracking()
            .ToListAsync();
        return cars;
    }

    public async Task<Car>? GetById(int carId)
    {
        return await dbContext.Cars
            .Include(x => x.PriceConditions)
            .SingleOrDefaultAsync(c => c.Id == carId);
    }

    public async Task<int> Create(Car newCar)
    {
        dbContext.Cars.Add(newCar);
        await dbContext.SaveChangesAsync();
        return newCar.Id;
    }

    public Task SaveChanges()
        => dbContext.SaveChangesAsync();
}
