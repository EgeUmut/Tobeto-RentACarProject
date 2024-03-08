using Core.CrossCuttingConcerns.Logging.SeriLog.Loggers;
using Core.Utilities.Security.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions;

public static class CoreModuleExtensions
{
    public static IServiceCollection AddCoreModule(this IServiceCollection services)
    {
        services.AddTransient<MssqlLogger>();
        services.AddTransient<MongoDbLogger>();
        services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<ITokenHelper, JwtHelper>();
        return services;
    }
}
