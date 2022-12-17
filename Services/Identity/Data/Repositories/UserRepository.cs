using System;
using Identity.Data.Repositories;
using Identity.Models;
using Microsoft.EntityFrameworkCore;

namespace Identity.Data
{
	public class UserRepository : RepositoryBase<User> , IUserRepository
    {
		public UserRepository(IdentityApiDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetUser(string UserName)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == UserName);
            return user;

        }

        public async Task<User> GetUserAndCheckPasswordAsync(string UserName,string Password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x =>
                            x.UserName == UserName &&
                            x.Password == Password);
            return user;

        }
    }
}

