using System;
namespace Identity.Data
{
	public interface IUserRepository
	{
        public List<User> GetUsers();
    }
}

