using Microsoft.AspNetCore.Identity;
using Resorter.Domain.Constants;
using Resorter.Domain.Entities;
using Resorter.Infrastructure.Persistance;

namespace Resorter.Infrastructure.Seeder;

internal class ResorterSeeder(ResorterDbContext dbContext) : IResorterSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Roles.Any())
            {
                var roles = GetRoles();
                dbContext.Roles.AddRange(roles);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<UserRole> GetRoles()
    {

        List<UserRole> roles =
            [
                new UserRole() {Name = UserRoles.Admin, NormalizedName=UserRoles.Admin.ToUpper(),
                },
                new UserRole() {Name = UserRoles.User, NormalizedName=UserRoles.User.ToUpper(),
                }
            ];

        return roles;
    }


}

