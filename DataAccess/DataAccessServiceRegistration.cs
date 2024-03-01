using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Context;
using DataAccess.Concretes.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess;

public static class DataAccessServiceRegistration
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        var assembly = Assembly.GetExecutingAssembly();
        //Services and Managers Dependency Injections

        services.RegisterAssemblyTypes(assembly).Where(p => p.ServiceType.Name.EndsWith("Repository"));
        //services.AddScoped<IBrandRepository, BrandRepository>();    //Brand DI
        //services.AddScoped<IModelRepository, ModelRepository>();    //Model DI
        //services.AddScoped<ICarRepository, CarRepository>();    //Car DI

        return services;
    }

    public static IServiceCollection RegisterAssemblyTypes(this IServiceCollection services, Assembly assembly)
    {
        var types = assembly.GetTypes().Where(p => p.IsClass && !p.IsAbstract);
        foreach (Type? item in types)
        {
            var interfaces = item.GetInterfaces();
            foreach (var @interface in interfaces)
            {
                services.AddScoped(@interface, item);
            }
        }
        return services;
    }
}
