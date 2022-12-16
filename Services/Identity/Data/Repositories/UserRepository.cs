using System;
using Identity.Models;

namespace Identity.Data
{
	public class UserRepository : IUserRepository
	{
		public UserRepository()
		{
		}

        public List<User> GetUsers()
        {
            using (var context = new IdentityApiDBContext()) //WTFFF!!
            {
                var list = context.User
                    .Include(a => a.Books)
                    .ToList();
                return list;
            }
        }
    }
}

