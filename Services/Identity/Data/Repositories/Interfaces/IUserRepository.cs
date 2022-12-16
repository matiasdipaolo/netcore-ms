using System;
using Identity.Data.Repositories.Interfaces;
using Identity.Models;

namespace Identity.Data
{
	public interface IUserRepository : IAsyncRepository<User>
    {
        public Task<User> GetUser(string userName);
    }
}

