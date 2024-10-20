using MediatR;
using Resorter.Application.Features.Cars.Dto;

namespace Resorter.Application.Features.Settings.Commands.CreateSeasons;

public class CreateSeasonsCommand : IRequest
{
    public List<SeasonDto>? NewSeasons { get; set; }
    public List<SeasonDto>? EditedSeasons { get; set; }
    public List<int>? DeletedSeasonIds { get; set; }
}


