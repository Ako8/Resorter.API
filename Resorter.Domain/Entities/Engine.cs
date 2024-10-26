using Resorter.Domain.Constants;

namespace Resorter.Domain.Entities;

public class Engine
{
    public string Type { get; set; }
    public int Horsepower { get; set; }
    public FuelTypeEnum Fuel { get; set; }
    public decimal TankCapacity { get; set; }
    public decimal FuelConsumptionKm { get; set; }
}
