using Resorter.Application.Entities;
using Resorter.Domain.Entities;

namespace Resorter.Domain.Junctions;

public class UserTariff
{
    public int UserId { get; set; }
    public User User { get; set; }

    public int TariffId { get; set; }
    public Tariff Tariff { get; set; }
}
