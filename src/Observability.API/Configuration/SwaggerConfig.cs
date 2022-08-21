using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Observability.API.Configuration;

public static class SwaggerConfig
{
    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo()
            {
                Title = "Observability API",
                Contact = new OpenApiContact() { Name = "Anderson Hansen", Email = "adshan@gmail.com" },
                License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
            });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);

        });

        return services;
    }

    public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.DefaultModelsExpandDepth(-1);
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        });

        return app;
    }
}
