using Resorter.Domain.Entities;

namespace Resorter.Domain.Repositories;

public interface IPriceConditionRepository : ICrudRepository<PriceCondition>
{
    Task AddRangeAsync(IEnumerable<PriceCondition> priceConditions);
}
