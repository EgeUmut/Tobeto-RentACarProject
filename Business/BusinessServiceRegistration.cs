using Business.Abstracts;
using Business.Concretes;
using Business.Rules;
using Core.CrossCuttingConcerns;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());    //Automapper

        var assembly = Assembly.GetExecutingAssembly();

        //Services
        services.RegisterAssemblyTypes(assembly).Where(p => p.ServiceType.Name.EndsWith("Manager"));
        //services.AddScoped<IBrandService, BrandManager>();
        //services.AddScoped<ICarService, CarManager>();
        //services.AddScoped<IModelService, ModelManager>();

        //Business Rules
        services.AddSubClassesOfType(assembly, typeof(BaseBusinessRules));
        //services.AddScoped<BrandBusinessRules>();
        //services.AddScoped<ModelBusinessRules>();


        return services;
    }

    public static IServiceCollection AddSubClassesOfType
        (this IServiceCollection services, Assembly assembly, Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
    {
        var types = assembly.GetTypes().Where(p => p.IsSubclassOf(type) && type != p).ToList();
        foreach (Type? item in types)
        {
            if (addWithLifeCycle == null)
            {
                services.AddScoped(item);
            }
            else
            {
                addWithLifeCycle(services, type);
            }
        }
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
