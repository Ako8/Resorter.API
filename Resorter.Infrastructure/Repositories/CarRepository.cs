using Microsoft.EntityFrameworkCore;
using Resorter.Application.Features.Cars.Queries.GetFilteredCars;
using Resorter.Domain.Entities;
using Resorter.Domain.Repositories;
using Resorter.Infrastructure.Persistance;

namespace Resorter.Infrastructure.Repositories;

internal class CarRepository(ResorterDbContext dbContext) : ICarRepository
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


    public async Task<IEnumerable<Car>> GetAllFilteredAsync<TFilter>(TFilter carFilter) where TFilter : class
    {
        if (carFilter is not GetFilteredCarsQuery filter)
            return Enumerable.Empty<Car>();

        if (filter.PageNumber < 1) filter.PageNumber = 1;
        if (filter.PageSize < 1) filter.PageSize = 10;

        var query = dbContext.Cars
            .Include(c => c.PriceConditions)
                .ThenInclude(p =>  p.Season)
            .AsQueryable();
        var now = DateTime.UtcNow.Date;

        var bookRange = (filter.EndDate.Date - filter.StartDate.Date).Days;
        if (bookRange < 0) return Enumerable.Empty<Car>();

        query = query.Where(car =>
            car.PriceConditions.Any(con =>
                con.Tariff != null &&
                con.Season != null &&
                con.Tariff.MinDays <= bookRange &&
                bookRange <= con.Tariff.MaxDays &&
                con.Season.StartDate.Date <= now &&
                con.Season.EndDate.Date >= now)
            &&
            !car.Orders.Any(order =>
                order.StartDate.Date <= filter.EndDate.Date &&
                order.EndDate.Date >= filter.StartDate.Date)
        );

        if (!string.IsNullOrEmpty(filter.PickUp) || !string.IsNullOrEmpty(filter.DropOff))
        {
            query = query.Where(car => car.UserCars.Any(userCar =>
                userCar.User.UserAddresses.Any(userAddress =>
                    userAddress.Address != null &&
                    userAddress.Address.City != null &&
                    (!string.IsNullOrEmpty(filter.PickUp) ?
                        userAddress.Address.City.Name.Contains(filter.PickUp) : true) &&
                    (!string.IsNullOrEmpty(filter.DropOff) ?
                        userAddress.Address.City.Name.Contains(filter.DropOff) : true)
                )
            ));
        }

        if (filter.BodyTypes?.Count > 0)
            query = query.Where(c => filter.BodyTypes.Contains(c.BodyType));

        if (filter.FuelTypes?.Count > 0)
            query = query.Where(c => c.Engine != null && filter.FuelTypes.Contains(c.Engine.Fuel));

        if (filter.DriveTypes?.Count > 0)
            query = query.Where(c => c.Chassis != null && filter.DriveTypes.Contains(c.Chassis.Drive));

        if (filter.Transmissions?.Count > 0)
            query = query.Where(c => c.Chassis != null && filter.Transmissions.Contains(c.Chassis.Transmission));

        if (filter.Year > 0)
            query = query.Where(c => c.YearOfManufacture == filter.Year);

        if (filter.FuelConsumptionMin > 0)
            query = query.Where(c => c.Engine != null && c.Engine.FuelConsumptionKm >= filter.FuelConsumptionMin);

        if (filter.FuelConsumptionMax > 0)
            query = query.Where(c => c.Engine != null && c.Engine.FuelConsumptionKm <= filter.FuelConsumptionMax);
        
        return await query
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .ToListAsync();
    }

    public async Task<Car> GetByIdAsync(int id)
    {
        var car = await dbContext.Cars
            .Include(c => c.PriceConditions)
            .SingleOrDefaultAsync(e => e.Id == id);
        return car;
    }

    public Task<IReadOnlyList<Season>> GetByIdsAndUserAsync(List<int> ids, int userId)
    {
        throw new NotImplementedException();
    }

    public async Task SaveChanges()
        => await dbContext.SaveChangesAsync();
}
