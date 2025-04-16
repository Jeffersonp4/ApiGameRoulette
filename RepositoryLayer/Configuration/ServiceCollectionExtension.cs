using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.EntityFramework.Context;
using RepositoryLayer.EntityFramework.Repositories;
using RepositoryLayer.EntityFramework.Services;

namespace RepositoryLayer.Configuration
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDepencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            // Aqui Registramos el  dbContext para conexion en base de datos

            services.AddDbContext<RouletteDbContext>(option =>
                option.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))

            );


            // Registrar el repositorio generico para la injeccion

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            
            // Registrar repositorios especificos 

            services.AddScoped<IUserRepository, UserRepository>();


            return services;



        }
    }
}
