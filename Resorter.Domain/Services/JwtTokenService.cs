using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Resorter.Application.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Resorter.Domain.Services;

public interface IJwtTokenService
{
    string GenerateJwtToken(User? user, IList<string> userRoles);
}

public class JwtTokenService(IConfiguration configuration) : IJwtTokenService
{
    public string GenerateJwtToken(User? user, IList<string> userRoles)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));

        var claims = new List<Claim>
        {
            new Claim("id", user.Id.ToString()),
            new Claim("email", user.Email),
            new Claim("email_confirmed", $"{user.EmailConfirmed}"),
            new Claim("phoneNumber", user.PhoneNumber),
            new Claim("phoneNumber_confirmed", $"{user.PhoneNumberConfirmed}"),
        };

        userRoles.Add("Member");

        foreach (var role in userRoles)
        {
            claims.Add(new Claim("roles", role));
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddDays(Convert.ToDouble(configuration["Jwt:ExpireDate"])),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
