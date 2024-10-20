using MediatR;
using Resorter.Application.Features.Cars.Dto;

namespace Resorter.Application.Features.Settings.Commands.CreateTariffs;

public class CreateTariffsCommand : IRequest
{
    public List<TariffDto>? NewTariffs { get; set; }
    public List<TariffDto>? EditedTariffs { get; set; }
    public List<int>? DeletedTariffIds { get; set; }
}
