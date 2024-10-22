using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Resorter.Application.Entities;
using Resorter.Domain.Entities;
using Resorter.Domain.Services;
using Resorter.Infrastructure.Persistance;
using Resorter.Infrastructure.Seeder;

namespace Resorter.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(
       this IServiceCollection services,
            IConfiguration configuration,
            IHostEnvironment environment)
    {
        var connectionString = configuration.GetConnectionString("ResorterDb");
        services.AddDbContext<ResorterDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
            if (!environment.IsDevelopment())
            {
                options.EnableSensitiveDataLogging();
            }
        });

        services.AddIdentityApiEndpoints<User>()
            .AddRoles<UserRole>()
            .AddEntityFrameworkStores<ResorterDbContext>();

        services.AddScoped<IJwtTokenService, JwtTokenService>();
        services.AddScoped<IResorterSeeder, ResorterSeeder>();
    }
}
