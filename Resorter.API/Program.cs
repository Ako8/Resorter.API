using Resorter.API.Extensions;
using Resorter.API.Middleware;
using Resorter.Application.Extensions;
using Resorter.Infrastructure.Extensions;
using Resorter.Infrastructure.Seeder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration, builder.Environment);


var app = builder.Build();
using var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IResorterSeeder>();
await seeder.Seed();
// Configure the HTTP request pipeline.
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


//aqana daemate dimitri mumladzis pirveli komiti
