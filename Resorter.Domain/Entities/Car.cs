namespace Resorter.Application.Entities;

public class Car
{
    public int Id { get; set; }
    public string RegistrationCertificate { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string LicensePlate { get; set; }
    public string YearOfManufacturer { get; set; }
    public string BodyColor { get; set; }
    public string BodyType { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public Insurance Insurance { get; set; }
    public Engine Engine { get; set; }
    public Specifications Specifications { get; set; }
    public Chassis Chassis { get; set; }
    public List<PriceCondition> PriceConditions { get; set; }
    public List<Discount> Discounts { get; set; }
}
