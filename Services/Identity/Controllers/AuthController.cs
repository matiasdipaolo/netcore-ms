using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.Data;
using Identity.DTOs;
using Identity.JWTAuth.Interfaces;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Identity.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IUserRepository _repository;
        private readonly IAuthenticateService _authService;

        public AuthController(ILogger<AuthController> logger, IUserRepository repository, IAuthenticateService authService)
        {
            _authService = authService;
            _logger = logger;
            _repository = repository;
    }
        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]UserDTO User)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Very credencials
                    var userObj = await _repository.GetUserAndCheckPasswordAsync(User.UserName, User.Password);

                    if (userObj is null)
                    {
                        return StatusCode(StatusCodes.Status403Forbidden, "User or password incorrect");
                    }
                    // Create token
                    var token = _authService.CreateToken(userObj);
                    return Ok(token);

                }
                catch (Exception e)
                {
                    _logger.LogError("Error in auth controller: " + e.ToString());
                    return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
                }
            }

            return StatusCode(StatusCodes.Status400BadRequest, "Please verify your request to this endpoint");
        }

    }
}

