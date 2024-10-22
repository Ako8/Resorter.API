using Resorter.Application.Entities;
using Resorter.Domain.Entities;

namespace Resorter.Domain.Junctions;

public class UserSeason
{
    public int UserId { get; set; }
    public User User { get; set; }

    public int SeasonId { get; set; }
    public Season Season { get; set; }
}
