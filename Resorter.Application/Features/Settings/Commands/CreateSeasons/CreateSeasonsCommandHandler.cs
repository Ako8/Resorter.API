using MediatR;
using Resorter.Application.Entities;
using Resorter.Application.Features.Settings.Dto;
using Resorter.Domain.Exceptions;
using Resorter.Infrastructure.Repositories;

namespace Resorter.Application.Features.Settings.Commands.CreateSeasons;

public class CreateSeasonsCommandHandler
    (
        IPriceConditionRepository priceConditionRepository
    ) : IRequestHandler<CreateSeasonsCommand>
{
    public async Task Handle(CreateSeasonsCommand request, CancellationToken cancellationToken)
    {
        if (request.NewSeasons != null)
        {
            var toCreate = request.NewSeasons.CreateSeasonsMapper();
            await priceConditionRepository.CreateSeasons(toCreate);
        }

        if (request.DeletedSeasonIds != null)
        {
            var carSeasonIds = request.DeletedSeasonIds
                .Select(pc => pc)
                .Distinct()
                .ToList();

            var toDeleteSeasons = await priceConditionRepository.GetSeasonsByIds(carSeasonIds);

            if (toDeleteSeasons.Keys.Count != carSeasonIds.Count)
            {
                var missingIds = carSeasonIds.Except(toDeleteSeasons.Select(s => s.Value.Id));
                throw new NotFoundException(nameof(Season), string.Join(", ", missingIds));
            }

            await priceConditionRepository.DeleteSeasons([.. toDeleteSeasons.Values]);
        }

        if (request.EditedSeasons != null)
        {
            var carSeasonIds = request.EditedSeasons
                .Select(pc => pc.Id)
                .Distinct()
                .ToList();

            var toEditedSeasons = await priceConditionRepository.GetSeasonsByIds(carSeasonIds);

            if (toEditedSeasons.Keys.Count != carSeasonIds.Count)
            {
                var missingIds = carSeasonIds.Except(toEditedSeasons.Select(s => s.Value.Id));
                throw new NotFoundException(nameof(Season), string.Join(", ", missingIds));
            }

            foreach (var season in toEditedSeasons.Values)
            {
                var toEdit = request.EditedSeasons
                    .Where(x => x.Id == season.Id)
                    .First();

                season.StartDate = toEdit.StartDate;
                season.EndDate = toEdit.EndDate;
            }

            await priceConditionRepository.SaveChangesAsync();
        }
    }
}
