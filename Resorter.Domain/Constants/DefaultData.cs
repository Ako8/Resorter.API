using Resorter.Application.Entities;
using Resorter.Domain.Entities;

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
        };
    }

    public static List<Season> Season(User? user)
    {
        return new List<Season>()
        {
                new Season()
                {
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
                MinDays = 1,
                MaxDays = 31,
            }
        };
    }
}
