namespace Observability.API.Configuration;

public static class ApiConfig
{
    public static IServiceCollection AddApiConfiguration(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();

        return services;
    }

    public static WebApplication UseApiConfiguration(this WebApplication app)
    {
        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        return app;
    }

}