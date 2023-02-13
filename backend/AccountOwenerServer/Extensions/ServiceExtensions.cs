using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// xerife-- essa classe é que manda no controle da api
namespace AccountOwenerServer.Extensions
{
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
            {});
        }
    }
}