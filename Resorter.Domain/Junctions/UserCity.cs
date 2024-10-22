using Resorter.Application.Entities;
using Resorter.Domain.Entities;

namespace Resorter.Domain.Junctions;

public class UserCity
{
    public int UserId { get; set; }
    public User User { get; set; }

    public int CityId { get; set; }
    public City City { get; set; }
}
