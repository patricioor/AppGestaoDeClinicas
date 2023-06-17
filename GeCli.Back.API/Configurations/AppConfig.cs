using GeCli.Back.Infra.IoC;
using Serilog;

namespace GeCli.Back.API.Configurations
{
    public static class AppConfig
    {
        public static void AppConfigurations(this WebApplicationBuilder builder)
        {
            var app = builder.Build();

            app.UseExceptionHandler("/error");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseSwaggerConfiguration();

            app.UseInfrastructure();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
