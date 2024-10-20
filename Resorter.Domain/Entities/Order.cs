namespace Resorter.Application.Entities;

public class Order
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Price { get; set; }
    public Car Car { get; set; }
    public int CarId { get; set; }
}
