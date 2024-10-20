using Resorter.Application.Entities;

namespace Resorter.Domain.Constants;

public static class DefaultData
{
    public static Car Car()
    {
        return new Car()
        {
            RegistrationCertificate = "rUrl",
            Brand = "Default",
            Model = "Default",
            LicensePlate = "XX 000 XX",
            YearOfManufacturer = "2024",
            BodyColor = "White",
            BodyType = "Sedan",
        };
    }

    public static List<Season> Season(User? user)
    {
        return new List<Season>()
        {
                new Season()
                {
                    User = user,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddMonths(5),
                },
        };
    }

    public static List<Tariff> Tariff(User? user)
    {
        return new List<Tariff>()
        {
            new Tariff()
            {
                User = user,
                MinDays = 1,
                MaxDays = 31,
            }
        };
    }
}
