using Resorter.Domain.Junctions;

namespace Resorter.Domain.Entities;

public class Season
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public ICollection<UserSeason> UserSeasons { get; set; }
}
