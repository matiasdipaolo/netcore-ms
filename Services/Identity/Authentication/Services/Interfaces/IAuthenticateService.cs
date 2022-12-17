using System;
using Identity.DTOs;
using Identity.Models;

namespace Identity.JWTAuth.Interfaces
{
	public interface IAuthenticateService
	{
        string CreateToken(User user);
    
    }
}

