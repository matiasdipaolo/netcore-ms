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

        public async Task<User> GetUser(string userName)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            return user;

        }
    }
}

