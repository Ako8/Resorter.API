using MediatR;
using Resorter.Application.Features.Settings.Dto;
using Resorter.Infrastructure.Repositories;

namespace Resorter.Application.Features.Settings.Queries.GetSeasonsAndTariffs;

public class GetSeasonsAndTariffsQueryHandler
    (
        IPriceConditionRepository priceConditionRepository  
    ) : IRequestHandler<GetSeasonsAndTariffsQuery, SeasonsAndTariffsDto>
{
    public async Task<SeasonsAndTariffsDto> Handle(GetSeasonsAndTariffsQuery request, CancellationToken cancellationToken)
    {
        var seasons = await priceConditionRepository.GetSeasonsByIds(null);
        var tariffs = await priceConditionRepository.GetTariffsByIds(null);

        return new SeasonsAndTariffsDto()
        {
            Seasons = seasons.MapToDto(),
            Tariffs = tariffs.MapToDto()
        };
    }
}
