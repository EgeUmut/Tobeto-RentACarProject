using DataAccess.Concretes.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using Business;
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


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
