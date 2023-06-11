using GeCli.Back.API.Configurations;
using GeCli.Back.Infra.IoC;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("log.txt", fileSizeLimitBytes: 100000, rollOnFileSizeLimit: true, rollingInterval: RollingInterval.Day)
    .CreateLogger();

try
{
    Log.Information("initializing WebApi");
    // Add services to the container.

    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerConfiguration();

    var app = builder.Build();
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
        app.UseSwaggerConfiguration();

    app.UseInfrastructure();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Critical Error");
}
finally
{
    Log.CloseAndFlush();
}

