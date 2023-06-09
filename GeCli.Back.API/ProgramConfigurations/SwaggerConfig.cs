using Microsoft.OpenApi.Models;

namespace GeCli.Back.API.ProgramConfigurations
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", 
                    new OpenApiInfo 
                    { 
                        Title = "App para Gestão de Clínicas", 
                        Version = "v1",
                        Description = "API da aplicação 'GeCli'",
                        Contact = new OpenApiContact
                        {
                            Name = "Patrício Osterno Rios",
                            Email = "patricio.osterno1@gmail.com",
                            Url = new Uri("https://github.com/patricioor")
                        },
                        License = new OpenApiLicense
                        {
                            Name = "All rigths reserveds."
                        }
                    });
            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "GeCli v1");
            });          
        }
    }
}
