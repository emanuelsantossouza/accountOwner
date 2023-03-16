using Contracts;
using LoggerService;
using Entities;
using Microsoft.EntityFrameworkCore;
using  Repository;


// xerife-- essa classe é que manda no controle da api
namespace AccountOwenerServer.Extensions;

public static class ServiceExtensions /*Se o metodo for estatico a classe precisa ser estatica!!!*/
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                    builder => builder
                    .AllowAnyOrigin() //   builder => builder.WithOrigins("http.com...")
                    .AllowAnyMethod()      // .WithMethods("Post", "Get")
                    .AllowAnyHeader());    // WithHeaders("accept", "content-type")
        });
    }


    public static void ConfigureIISIntegration(this IServiceCollection services)
    {
        services.Configure<IISOptions>(options =>
        { });
    }

    public static void ConfigureLoggerService(this IServiceCollection services)
    {
        services.AddSingleton<ILoggerManager, LoggerManager>();
    }

    public static void ConfigureMySQLContext(this IServiceCollection services, IConfiguration config)
    {
        var conn = config["mysqlconnection:connectionString"];
        services.AddDbContext<RepositoryContext>(
            o => o.UseMySql(conn, ServerVersion.AutoDetect(conn))
        );
    }

    public static void ConfigureRepositoryWrapper(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
    }
}