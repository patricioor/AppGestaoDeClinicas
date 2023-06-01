using GeCli.Back.Infra.IoC;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc
    ("v1", new OpenApiInfo {Title = "App para Gestão de Clínicas", Version = "v1" })
    );

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
                        c.RoutePrefix = string.Empty;
                        c.SwaggerEndpoint("./swagger/v1/swagger.json", "GeCli v1");
                           });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
