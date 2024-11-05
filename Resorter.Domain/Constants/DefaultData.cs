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

    public static List<Season> Season()
    {
        return
        [
            new Season()
            {
                StartDate = new DateTime(DateTime.Now.Year, 1, 1), 
                EndDate = new DateTime(DateTime.Now.Year, 12, 31),
            },
        ];
    }

    public static List<Tariff> Tariff()
    {
        return
        [
            new Tariff()
            {
                MinDays = 1,
                MaxDays = 31,
            }
        ];
    }
}
