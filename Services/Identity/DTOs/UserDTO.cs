using System;
using System.Text.Json.Serialization;

namespace Identity.DTOs
{
	public class UserDTO
	{
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserDTO() { }
	}
}

