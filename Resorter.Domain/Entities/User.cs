using Microsoft.AspNetCore.Identity;

namespace Resorter.Application.Entities;

public class User : IdentityUser
{
    public string Name { get; set; }
    public List<Car> Cars { get; set; }
    public List<Season> Seasons { get; set; }
    public List<Tariff> Tariffs { get; set; }
}
