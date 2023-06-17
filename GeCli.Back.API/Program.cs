using GeCli.Back.API.Configurations;
using GeCli.Back.Infra.IoC;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddInfrastructure(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();

IConfigurationRoot configuration = GetConfiguration();

ConfigureLog(configuration);

try
{
    Log.Information("initializing WebApi");
    builder.AppConfigurations();
    builder.Logging.ClearProviders();
    builder.Logging.AddSerilog();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Critical Error");
}
finally
{
    Log.CloseAndFlush();
}

static IConfigurationRoot GetConfiguration()
{
    string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

    var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .AddJsonFile($"appsettings.{environment}.json", optional: true)
        .Build();
    return configuration;
}

static void ConfigureLog(IConfigurationRoot configuration)
{
    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(configuration)
        .CreateLogger();
}


