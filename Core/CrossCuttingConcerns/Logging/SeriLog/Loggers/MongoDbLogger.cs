using Core.CrossCuttingConcerns.Logging.SeriLog.ConfigurationModels;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Core.CrossCuttingConcerns.Logging.SeriLog.Loggers;

public class MongoDbLogger:LoggerServiceBase
{
    private IConfiguration _configuration;

    public MongoDbLogger()
    {
        
    }
    public MongoDbLogger(IConfiguration configuration)
    {
        _configuration = configuration;
        var logConfig = configuration.GetSection("SerilogConfigurations:MongoDbConfiguration").Get<MongoDbConfiguration>();
        Logger = new LoggerConfiguration().WriteTo.MongoDB(logConfig.ConnectionString , collectionName: logConfig.Collection).CreateLogger();
    }
}
