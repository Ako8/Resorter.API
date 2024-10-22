using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resorter.Application.Entities;

namespace Resorter.Infrastructure.Persistance.Configuration;

public class UserConfiguration : BaseConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.Id);

        ConfigureBase(builder, x => x.Name, 100);
        ConfigureBase(builder, x => x.Email, 100);
    }
}
