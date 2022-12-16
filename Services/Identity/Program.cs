
using Identity.Data;

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

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}

