using Resorter.Domain.Entities;

namespace Resorter.Domain.Repositories;

public interface ISeasonRepository : ICrudRepository<Season>
{
    Task<IReadOnlyList<Season>> GetByIdsAndUserAsync(List<int> ids, int userId);
    Task<IEnumerable<Season>> AddRangeAsync(IEnumerable<Season> seasons);
}
