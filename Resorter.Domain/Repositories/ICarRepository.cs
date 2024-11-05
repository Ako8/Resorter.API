using Resorter.Domain.Entities;

namespace Resorter.Domain.Repositories;

public interface ICarRepository : ICrudRepository<Car>
{
    Task<IEnumerable<Car>> GetAllFilteredAsync<TFilter>(TFilter filter) where TFilter : class;
}
