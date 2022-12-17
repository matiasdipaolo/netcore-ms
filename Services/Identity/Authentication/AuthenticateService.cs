using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Identity.DTOs;
using Identity.JWTAuth.Interfaces;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Identity.JWTAuth
{
	public class AuthenticateService : IAuthenticateService
    {
        // private readonly TokenManager _tokenManagement;
        protected readonly IConfiguration Configuration;

        public AuthenticateService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // @Todo in next verision
        public string CreateRefreshToken()
        {
            throw new NotImplementedException();
        }

        public string CreateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            int ExpiresIn;
            if (!int.TryParse(Configuration["Jwt:AccessExpiration"], out ExpiresIn))
            {
                throw new InvalidOperationException("Invalid AccessExpiration in config file");
            }
            // see: https://github.com/AzureAD/azure-activedirectory-identitymodel-extensions-for-dotnet/blob/d2361e5dcd1abbf6d0ea441cdb2e7404166b122c/src/System.IdentityModel.Tokens.Jwt/ClaimTypeMapping.cs#L61
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Sid, user.Id.ToString()),
                    new Claim(ClaimTypes.GivenName, $"{user.FirstName} {user.LastName}"),
                }),
                IssuedAt = DateTime.UtcNow,
                Issuer = Configuration["Jwt:Issuer"],
                Audience =  Configuration["Jwt:Audience"],
                Expires = DateTime.UtcNow.AddMinutes(ExpiresIn),
                SigningCredentials = credentials,
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}

