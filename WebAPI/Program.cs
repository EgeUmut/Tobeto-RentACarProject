using DataAccess.Concretes.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using Business;
using Core.Exceptios.Extensions;
using Autofac;
using Business.DependencyResolves.Autofac;
using Autofac.Extensions.DependencyInjection;
using Core.Utilities.IoC;
using Core.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//SQL Database Configuration Old
//builder.Services.AddDbContext<BaseDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//SQL Database Configuration --- Service Injections
builder.Services.AddDataAccessServices(builder.Configuration);
builder.Services.AddBusinessServices();
builder.Services.AddCoreModule();

//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());
});

var app = builder.Build();
ServiceTool.ServiceProvider = app.Services;

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ConfigureCustomExceptionMiddleWare();
}

if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ConfigureCustomExceptionMiddleWare();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
