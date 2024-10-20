using Resorter.Application.Entities;
using Resorter.Application.Features.Cars.Dto;
using Resorter.Application.Features.Settings.Commands.CreateSeasons;

namespace Resorter.Application.Features.Settings.Dto;

public static class RequestHelpers
{
    public static List<SeasonDto> MapToDto(this Dictionary<int, Season> seasons)
    {
        return seasons.Select(x => new SeasonDto()
        {
            Id = x.Value.Id,
            EndDate = x.Value.EndDate,
            StartDate = x.Value.StartDate,
        }).ToList();
    }

    public static List<TariffDto> MapToDto(this Dictionary<int, Tariff> tariffs)
    {
        return tariffs.Select(x => new TariffDto()
        {
            Id= x.Value.Id,
            MaxDays = x.Value.MaxDays,
            MinDays = x.Value.MinDays,
        }).ToList();
    }


    public static List<Season> CreateSeasonsMapper(this List<SeasonDto> seasons)
    {
        return seasons.Select(x => new Season()
        {
            UserId = "b712180d-e4e6-4a29-b14d-adc561f1034c",
            EndDate = x.EndDate,
            StartDate = x.StartDate,
        }).ToList();
    }


    public static List<Season> DeleteSeasonsMapper(this List<int> seasonIds)
    {
        return seasonIds.Select(x => new Season()
        {
            Id = x,
        }).ToList();
    }

    public static List<Tariff> CreateTariffsMapper(this List<TariffDto> tariffs)
    {
        return tariffs.Select(x => new Tariff()
        {
            Id = x.Id,
            MaxDays = x.MaxDays,
            MinDays = x.MinDays,    
            UserId = "b712180d-e4e6-4a29-b14d-adc561f1034c",
        }).ToList();
    }

    public static List<Tariff> DeleteTariffsMapper(this List<int> tariffIds)
    {
        return tariffIds.Select(x => new Tariff()
        {
            Id = x,
            UserId = "b712180d-e4e6-4a29-b14d-adc561f1034c",
        }).ToList();
    }

}
