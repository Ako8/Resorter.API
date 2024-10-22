﻿namespace Resorter.Domain.Entities;

public class Discount
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public Car Car { get; set; }
    public string Name { get; set; }
    public int PercentageAmount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsDiscount { get; set; }
}
