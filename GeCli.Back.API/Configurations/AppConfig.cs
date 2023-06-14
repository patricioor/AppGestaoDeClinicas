using GeCli.Back.Infra.IoC;

namespace GeCli.Back.API.Configurations
{
    public static class AppConfig
    {
        public static void AppConfigurations(this WebApplicationBuilder builder)
        {

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
    }
}
