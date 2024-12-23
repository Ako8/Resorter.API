﻿using Resorter.Application.Entities;
using Resorter.Domain.Entities;

namespace Resorter.Domain.Junctions;

public class UserCar
{
    public int UserId { get; set; }
    public User User { get; set; }

    public int CarId { get; set; }
    public Car Car { get; set; }
}
