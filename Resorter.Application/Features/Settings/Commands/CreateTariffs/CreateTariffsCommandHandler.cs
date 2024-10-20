using MediatR;
using Resorter.Application.Entities;
using Resorter.Application.Features.Settings.Dto;
using Resorter.Domain.Exceptions;
using Resorter.Infrastructure.Repositories;

namespace Resorter.Application.Features.Settings.Commands.CreateTariffs;

public class CreateTariffsCommandHandler
    (
        IPriceConditionRepository priceConditionRepository
    ) : IRequestHandler<CreateTariffsCommand>
{
    public async Task Handle(CreateTariffsCommand request, CancellationToken cancellationToken)
    {
        if (request.NewTariffs != null)
        {
            var toCreate = request.NewTariffs.CreateTariffsMapper();
            await priceConditionRepository.CreateTariffs(toCreate);
        }

        if (request.DeletedTariffIds != null)
        {
            var carTariffIds = request.DeletedTariffIds
                .Select(pc => pc)
                .Distinct()
                .ToList();

            var toDeleteTariffs = await priceConditionRepository.GetTariffsByIds(carTariffIds);

            if (toDeleteTariffs.Keys.Count != carTariffIds.Count)
            {
                var missingIds = carTariffIds.Except(toDeleteTariffs.Select(s => s.Value.Id));
                throw new NotFoundException(nameof(Tariff), string.Join(", ", missingIds));
            }

            await priceConditionRepository.DeleteTariffs([.. toDeleteTariffs.Values]);
        }

        if (request.EditedTariffs != null)
        {
            var carTariffIds = request.EditedTariffs
                .Select(pc => pc.Id)
                .Distinct()
                .ToList();

            var toEditedTariffs = await priceConditionRepository.GetTariffsByIds(carTariffIds);

            if (toEditedTariffs.Keys.Count != carTariffIds.Count)
            {
                var missingIds = carTariffIds.Except(toEditedTariffs.Select(s => s.Value.Id));
                throw new NotFoundException(nameof(Tariff), string.Join(", ", missingIds));
            }

            foreach (var season in toEditedTariffs.Values)
            {
                var toEdit = request.EditedTariffs
                    .Where(x => x.Id == season.Id)
                    .First();

                season.MaxDays = toEdit.MaxDays;
                season.MinDays = toEdit.MinDays;
            }

            await priceConditionRepository.SaveChangesAsync();
        }
    }
}
