using Resorter.Domain.Entities;

namespace Resorter.Domain.Repositories;

public interface ITariffRepository : ICrudRepository<Tariff>
{
    Task<IReadOnlyList<Tariff>> GetByIdsAndUserAsync(List<int> ids, int userId);
    Task<IEnumerable<Tariff>> AddRangeAsync(IEnumerable<Tariff> tariffs);
}
