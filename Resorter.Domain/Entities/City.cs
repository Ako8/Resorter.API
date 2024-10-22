using Resorter.Domain.Junctions;
using System.Net;

namespace Resorter.Domain.Entities;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<UserCity> UserCities { get; set; }
    public ICollection<Address> Addresses { get; set; }
}
