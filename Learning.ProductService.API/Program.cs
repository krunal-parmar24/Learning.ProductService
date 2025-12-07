using Learning.ProductService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuration is automatically loaded by WebApplicationBuilder
// It loads: appsettings.json -> appsettings.{Environment}.json -> Environment variables
// The environment is determined by ASPNETCORE_ENVIRONMENT (default: Production)
var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseNpgsql(connectionString));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
