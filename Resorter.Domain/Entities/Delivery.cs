namespace Resorter.Application.Entities;

public class Delivery
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public string Name { get; set; }
}
