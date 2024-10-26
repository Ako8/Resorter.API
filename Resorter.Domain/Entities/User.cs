using Microsoft.AspNetCore.Identity;
using Resorter.Domain.Entities;
using Resorter.Domain.Junctions;

namespace Resorter.Application.Entities;

public class User : IdentityUser<int>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public ICollection<Order> Orders { get; set; }
    public ICollection<UserCar> UserCars { get; set; }
    public ICollection<UserSeason> UserSeasons { get; set; }
    public ICollection<UserTariff> UserTariffs { get; set; }
    public ICollection<UserAddress> UserAddresses { get; set; }
}
