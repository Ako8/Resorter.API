using Resorter.Domain.Constants;
using Resorter.Domain.Junctions;

namespace Resorter.Domain.Entities;

public class Car
{
    public int Id { get; set; }
    public string RegistrationCertificate { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string LicensePlate { get; set; }
    public int YearOfManufacture { get; set; }
    public BodyColorEnum BodyColor { get; set; }
    public BodyTypeEnum BodyType { get; set; }
    public Engine Engine { get; set; }
    public Specifications Specifications { get; set; }
    public Chassis Chassis { get; set; }
    public Insurance Insurance { get; set; }


    public ICollection<UserCar> UserCars { get; set; }
    public ICollection<Discount> Discounts { get; set; }
    public ICollection<PriceCondition> PriceConditions { get; set; }
}
