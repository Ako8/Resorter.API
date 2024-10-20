using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Resorter.Domain.Constants;
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

    private IEnumerable<IdentityRole> GetRoles()
    {
        List<IdentityRole> roles =
            [
                 new (UserRoles.Admin){
                    NormalizedName =UserRoles.Admin.ToUpper(),
                },
                new (UserRoles.User){
                    NormalizedName =UserRoles.User.ToUpper(),
                }
            ];

        return roles;
    }


}

