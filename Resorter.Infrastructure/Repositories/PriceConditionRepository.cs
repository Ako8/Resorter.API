using Microsoft.EntityFrameworkCore;
using Resorter.Application.Entities;
using Resorter.Infrastructure.Persistance;

namespace Resorter.Infrastructure.Repositories;

internal class PriceConditionRepository(ResorterDbContext dbContext) : IPriceConditionRepository
{
    public async Task<Dictionary<int, Season>> GetSeasonsByIds(IEnumerable<int>? ids)
    {
        if (ids == null || !ids.Any())
        {
            return await dbContext.Seasons.ToDictionaryAsync(s => s.Id, s => s);
        }

        return await dbContext.Seasons
            .Where(s => ids.Contains(s.Id))
            .ToDictionaryAsync(s => s.Id, s => s);
    }

    public async Task CreateSeasons(List<Season> newSeasons)
    {
        dbContext.Seasons.AddRange(newSeasons);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteSeasons(List<Season> seasons)
    {
        dbContext.Seasons.RemoveRange(seasons);
        await dbContext.SaveChangesAsync();
    }


    public async Task<Dictionary<int, Tariff>> GetTariffsByIds(IEnumerable<int>? ids)
    {
        if (ids == null || !ids.Any())
        {
            return await dbContext.Tariffs.ToDictionaryAsync(s => s.Id, s => s);
        }
        
        return await dbContext.Tariffs
            .Where(s => ids.Contains(s.Id))
            .ToDictionaryAsync(s => s.Id, s => s);
    }

    public async Task CreateTariffs(List<Tariff> newTariffs)
    {
        dbContext.Tariffs.AddRange(newTariffs);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteTariffs(List<Tariff> tariffs)
    {
        dbContext.Tariffs.RemoveRange(tariffs);
        await dbContext.SaveChangesAsync();
    }

    public async Task CreatePriceCondition(PriceCondition priceCondition)
    {
        dbContext.PriceConditions.Add(priceCondition);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeletePriceCondition(PriceCondition? priceCondition)
    {
        dbContext.PriceConditions.Remove(priceCondition);
        await dbContext.SaveChangesAsync();
    }

    public Task SaveChangesAsync()
        => dbContext.SaveChangesAsync();
}
