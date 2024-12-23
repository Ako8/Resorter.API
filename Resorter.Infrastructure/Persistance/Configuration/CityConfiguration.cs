﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resorter.Domain.Entities;

namespace Resorter.Infrastructure.Persistance.Configuration;

public class CityConfiguration : BaseConfiguration<City>
{
    public override void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasKey(e => e.Id);

        ConfigureBase(builder, x => x.Name, 100);
    }
}
