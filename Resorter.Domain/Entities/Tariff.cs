namespace Resorter.Application.Entities;

public class Tariff
{
    public int Id { get; set; }
    public int MinDays { get; set; }
    public int MaxDays { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
}
