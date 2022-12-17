using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Identity.JWTAuth;
using Identity.JWTAuth.Interfaces;
using Identity.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Identity.Tests;

public class AuthenticationServiceTest
{

    private IAuthenticateService _sut;
    protected readonly IConfiguration Configuration;

    public AuthenticationServiceTest()
    {
          _sut = new AuthenticateService(Configuration);
    }

 

    [Fact]
    public void should_return_jwt_token()
    {
        //Arrange
        User user = new User()
        {
            UserName = "johndoe",
            Password = "123456",
            Id = 1,
            FirstName = "John",
            LastName = "Doe",

        };

        //Act
        var result = _sut.CreateToken(user);

        //Assert
        Assert.IsType<string>(result);
    }

    [Fact]
    public void jwt_token_sholud_have_correct_claims()
    {
        //Arrange
        User user = new User()
        {
            UserName = "johndoe",
            Password = "123456",
            Id = 1,
            FirstName = "John",
            LastName = "Doe",

        };

        //Act
        var jwt = _sut.CreateToken(user);
        var token = new JwtSecurityTokenHandler().ReadJwtToken(jwt);
        var userNameClaim = token.Claims.First(x => x.Type == ClaimTypes.Name).Value;
        var userIdClaim = token.Claims.First(x => x.Type == ClaimTypes.Sid).Value;
        var userGivenNameClaim = token.Claims.First(x => x.Type == ClaimTypes.GivenName).Value;

        //Assert
        Assert.Equal(user.UserName, userNameClaim);
        Assert.Equal(user.Id.ToString(), userIdClaim);
        Assert.Equal($"{user.FirstName} {user.LastName}", userGivenNameClaim);
    }

    [Fact]
    public void jwt_token_should_be_valid()
    {
        //Arrange
        User user = new User()
        {
            UserName = "johndoe",
            Password = "123456",
            Id = 1,
            FirstName = "John",
            LastName = "Doe",

        };
        bool result = false;

        //Act
        var jwtToken = _sut.CreateToken(user);
        JwtSecurityToken jwtSecurityToken;
        jwtSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(jwtToken);
        if (jwtSecurityToken.ValidTo > DateTime.UtcNow) {
            result = true;
        }

        //Assert
        Assert.True(result);
    }
}
