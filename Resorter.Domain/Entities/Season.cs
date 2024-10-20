namespace Resorter.Application.Entities;

public class Season
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
}
