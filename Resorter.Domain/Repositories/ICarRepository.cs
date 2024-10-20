using Resorter.Application.Entities;

namespace Resorter.Infrastructure.Repositories;

public interface ICarRepository
{
    Task<IEnumerable<Car>> GetAllAsync();
    Task<int> Create(Car newCar);
    Task<Car> GetById(int id);
    public Task SaveChanges();
    Task<IEnumerable<Car>> GetAllMatchingAsync(string? searchPhrase);
}