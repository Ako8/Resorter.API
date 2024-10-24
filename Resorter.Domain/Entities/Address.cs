﻿namespace Resorter.Domain.Entities;

public class Address
{
    public int Id { get; set; }
    public int CityId { get; set; }
    public City City { get; set; }
    public string Location { get; set; }
    public decimal DeliveryFee { get; set; }
    public string DeliveryTime { get; set; }
}
