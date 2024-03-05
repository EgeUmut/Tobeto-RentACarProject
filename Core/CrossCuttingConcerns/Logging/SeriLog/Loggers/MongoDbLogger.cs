﻿using Core.CrossCuttingConcerns.Logging.SeriLog.ConfigurationModels;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Serilog;

namespace Core.CrossCuttingConcerns.Logging.SeriLog.Loggers;

public class MongoDbLogger:LoggerServiceBase
{
    private IConfiguration _configuration;

    //public MongoDbLogger(IConfiguration configuration)
    //{
    //    _configuration = configuration;
    //    var logConfig = configuration.GetSection("SerilogConfigurations:MongoDbConfiguration").Get<MongoDbConfiguration>();
    //    Logger = new LoggerConfiguration().WriteTo.MongoDB(logConfig.ConnectionString , collectionName: logConfig.Collection).CreateLogger();
    //}

    public MongoDbLogger()
    {
        //MongoDbConfiguration? dbConfiguration = configuration.GetSection("SerilogConfigurations:MongoDbConfiguration")
        //    .Get<MongoDbConfiguration>();

        Logger = new LoggerConfiguration().WriteTo.MongoDBBson(
            cfg =>
            {
                MongoClient client = new("mongodb://localhost:27017");
                IMongoDatabase? database = client.GetDatabase("TobetoRentACarlogs");
                cfg.SetMongoDatabase(database);
            }
        ).CreateLogger();
    }
}
