
using System.Text;
using Identity.Data;
using Identity.JWTAuth;
using Identity.JWTAuth.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Identity;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        #region Repositories
        //Dependecy injection
        // Using the singleton lifetime for the repository could cause you serious
        // concurrency problems when your DbContext is set to scoped (InstancePerLifetimeScope)
        // lifetime (the default lifetimes for a DBContext);
        builder.Services.AddDbContext<IdentityApiDBContext>();
        // Registering a Repository in Autofac IoC container
        builder.Services.AddScoped<IUserRepository, UserRepository>();

        #endregion

        #region JWT AUTH

        builder.Services
        .AddHttpContextAccessor()
        .AddAuthorization()
        .AddAuthentication(x =>
         {
             x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
             x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
         }).AddJwtBearer(options =>
         {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            };
         });

        #endregion

        builder.Services.AddScoped<IAuthenticateService, AuthenticateService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}

