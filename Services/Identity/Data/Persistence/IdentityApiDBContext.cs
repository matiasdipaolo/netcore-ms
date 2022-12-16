using System;
using Identity.Models;
using Microsoft.EntityFrameworkCore;

namespace Identity.Data
{
	public class IdentityApiDBContext : DbContext
    {
        // For read appsettings.json
        protected readonly IConfiguration Configuration;

        public IdentityApiDBContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // Database config
        // method to connect to SQLite
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"));
        }

        // Register user model in db context
        public virtual DbSet<User> Users { get; set; }



    }
}

