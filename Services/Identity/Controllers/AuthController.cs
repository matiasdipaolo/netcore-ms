using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Identity.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }
        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody]UserDTO user)
        {
            return Ok("All good");
        }

    }
}

