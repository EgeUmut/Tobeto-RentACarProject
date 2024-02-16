using Business.Abstracts.Async;
using Business.Abstracts.Sync;
using Business.Concretes.Async;
using Business.Concretes.Sync;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        //Async Services
        services.AddScoped<IAsyncBrandService, AsyncBrandManager>();
        services.AddScoped<IAsyncCarService, AsyncCarManager>();
        services.AddScoped<IAsyncModelService, AsyncModelManager>();

        //Sync Services
        services.AddScoped<IBrandService, BrandManager>();
        services.AddScoped<ICarService, CarManager>();
        services.AddScoped<IModelService, ModelManager>();


        return services;
    }
}
