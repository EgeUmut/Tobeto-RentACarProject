using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Context;
using DataAccess.Concretes.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess;

public static class DataAccessServiceRegistration
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


        //Services and Managers Dependency Injections


        services.AddScoped<IBrandRepository, BrandRepository>();    //Brand DI
        services.AddScoped<IModelRepository, ModelRepository>();    //Model DI
        services.AddScoped<ICarRepository, CarRepository>();    //Car DI

        return services;
    }
}
