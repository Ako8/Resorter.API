using Resorter.Application.Entities;

namespace Resorter.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Comment { get; set; }
    public decimal Price { get; set; }

    public int PickupAddressId { get; set; }
    public Address PickupAddress { get; set; }

    public int DropoffAddressId { get; set; }
    public Address DropoffAddress { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public int CarId { get; set; }
    public Car Car { get; set; }
}