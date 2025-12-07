using Learning.ProductService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Parse DATABASE_URL for EF Core (handles Render's format)
// Render sets DATABASE_URL as an environment variable
var databaseUrl = builder.Configuration["DATABASE_URL"];

if (!string.IsNullOrEmpty(databaseUrl) && databaseUrl.StartsWith("postgres://"))
{
    try
    {
        var url = new Uri(databaseUrl);
        var userInfo = url.UserInfo.Split(':');
        var connectionString = new NpgsqlConnectionStringBuilder
        {
            Host = url.Host,
            Username = userInfo[0],
            Password = userInfo.Length > 1 ? userInfo[1] : string.Empty,
            Database = url.AbsolutePath.TrimStart('/'),
            Port = url.Port,
            SslMode = SslMode.Require
        }.ConnectionString;

        builder.Services.AddDbContext<ProductDbContext>(options => options.UseNpgsql(connectionString));
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Failed to parse DATABASE_URL: {ex.Message}. Falling back to DefaultConnection.");
        builder.Services.AddDbContext<ProductDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")!));
    }
}
else
{
    builder.Services.AddDbContext<ProductDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")!));
}

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
