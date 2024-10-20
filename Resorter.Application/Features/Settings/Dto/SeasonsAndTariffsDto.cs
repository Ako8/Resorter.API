using Resorter.Application.Features.Cars.Dto;

namespace Resorter.Application.Features.Settings.Dto;

public class SeasonsAndTariffsDto
{
    public List<SeasonDto> Seasons { get; set; }
    public List<TariffDto> Tariffs { get; set; }
}
