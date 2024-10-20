using MediatR;
using Resorter.Application.Entities;
using Resorter.Application.Features.Cars.Commands.CreateCar;
using Resorter.Application.Features.Cars.Commands.UpdateCar;

namespace Resorter.Application.Features.Cars.Dto;

public static class CarMapper
{
    public static Car ToEntity(this CreateCarCommand command)
    {
        return new Car()
        {
            UserId = "b712180d-e4e6-4a29-b14d-adc561f1034c",
            RegistrationCertificate = command.RegistrationCertificate,
            Brand = command.Brand,
            Model = command.Model,
            LicensePlate = command.LicensePlate,
            YearOfManufacturer = command.YearOfManufacturer,
            BodyColor = command.BodyColor,
            BodyType = command.BodyType,
            Insurance = command.Insurance,
            Engine = command.Engine,
            Chassis = command.Chassis,
            Specifications = command.Specifications,
            PriceConditions = command.PriceConditions.Map()
        };
    }

    public static List<PriceCondition> Map(this List<PriceConditionDto> priceConditionDtos)
    {

        return priceConditionDtos.Select(x => new PriceCondition
        {
            TariffId = x.TariffId,
            SeasonId = x.SeasonId,
            Price = x.Price,
        }).ToList();
    }

    public static IEnumerable<CarDto>? CarsDtoMap(this IEnumerable<Car>? cars)
    {
        return cars.Select(car => new CarDto
        {
            Id = car.Id,
            Brand = car.Brand,
            Model = car.Model,
            LicensePlate = car.LicensePlate,
            YearOfManufacturer = car.YearOfManufacturer,
            BodyColor = car.BodyColor,
            BodyType = car.BodyType,
            Insurance = car.Insurance,
            Engine = car.Engine,
            Chassis = car.Chassis,
            Specifications = car.Specifications
        }).ToList();
    }

    
    public static CarDto CarDtoMap(this Car? car)
    {
        return new CarDto
        {
            Brand = car.Brand,
            Model = car.Model,
            LicensePlate = car.LicensePlate,
            YearOfManufacturer = car.YearOfManufacturer,
            BodyColor = car.BodyColor,
            BodyType = car.BodyType,
            Insurance = car.Insurance,
            Engine = car.Engine,
            Chassis = car.Chassis,
            Specifications = car.Specifications
        };
    }

    public static Car UpdateMap(this UpdateCarCommand command, Car car)
    {
        car.Brand = command.Brand;
        car.Model = command.Model;
        car.LicensePlate = command.LicensePlate;
        car.YearOfManufacturer = command.YearOfManufacturer;
        car.BodyColor = command.BodyColor;
        car.BodyType = command.BodyType;
        car.Insurance = command.Insurance;
        car.Engine = command.Engine;
        car.Chassis = command.Chassis;
        car.Specifications = command.Specifications;
        return car;
     }
}