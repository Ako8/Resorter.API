using Resorter.Domain.Junctions;

namespace Resorter.Domain.Entities;

public class Tariff
{
    public int Id { get; set; }
    public int MinDays { get; set; }
    public int MaxDays { get; set; }

    public ICollection<UserTariff> UserTariffs { get; set; }
}
