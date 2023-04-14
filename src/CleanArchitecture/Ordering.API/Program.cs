using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Ordering.API.Configuration;
using Ordering.Infrastructure.Context;
using System.Text.RegularExpressions;

var builder = WebApplication.CreateBuilder(args);
var _config = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();



builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

//Configure DB sqlLite or any that you want to use
 
builder.Services.AddScoped<OrderingContext>(provider =>
{
    var options = new DbContextOptionsBuilder<OrderingContext>()
        .UseSqlite(_config.GetConnectionString("DefaultConnection"))
        .Options;

    return new OrderingContext(options);
});


//Solving DepedencyInjection
builder.Services.SolvingDependencies();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
