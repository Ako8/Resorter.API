using Resorter.Application.Entities;

namespace Resorter.Infrastructure.Repositories
{
    public interface IPriceConditionRepository
    {
        Task CreatePriceCondition(PriceCondition priceCondition);
        Task CreateSeasons(List<Season> newSeasons);
        Task CreateTariffs(List<Tariff> newTariffs);
        Task DeleteSeasons(List<Season> seasons);
        Task DeleteTariffs(List<Tariff> tariffs);
        Task DeletePriceCondition(PriceCondition? priceCondition);
        Task<Dictionary<int, Season>> GetSeasonsByIds(IEnumerable<int>? ids);
        Task<Dictionary<int, Tariff>> GetTariffsByIds(IEnumerable<int>? ids);
        Task SaveChangesAsync();

    }
}