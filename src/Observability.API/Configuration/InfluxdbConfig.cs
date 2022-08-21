using App.Metrics;
using App.Metrics.Filtering;
using App.Metrics.Formatters.InfluxDB;

namespace Observability.API.Configuration;

public static class InfluxdbConfig
{
    public static IServiceCollection AddInfluxdbConfiguration(this IServiceCollection services)
    {
        var filter = new MetricsFilter().WhereType(MetricType.Timer);

        var metrics = new MetricsBuilder()
            .Configuration.Configure(
                options =>
                    {
                        options.WithGlobalTags((globalTags, info) =>
                        {
                            globalTags.Add("app", info.EntryAssemblyName);
                            globalTags.Add("env", "local");
                        });
                    })
            .Report.ToInfluxDb(
                options =>
                    {
                        options.InfluxDb.BaseUri = new Uri("http://localhost:8086/api/v2/");
                        options.InfluxDb.Bucket = "_monitoring";
                        options.InfluxDb.Token = "__INFLUX_TOKEN__";
                        options.InfluxDb.OrganizationId = "__INFLUX_ORGANIZATION-ID__";
                        options.InfluxDb.CreateBucketIfNotExists = true;
                        options.HttpPolicy.BackoffPeriod = TimeSpan.FromSeconds(30);
                        options.HttpPolicy.FailuresBeforeBackoff = 5;
                        options.HttpPolicy.Timeout = TimeSpan.FromSeconds(10);
                        options.MetricsOutputFormatter = new MetricsInfluxDbLineProtocolOutputFormatter();
                        options.Filter = filter;
                        options.FlushInterval = TimeSpan.FromSeconds(20);
                    })
            .Build();

        services.AddMetrics(metrics);
        services.AddMetricsTrackingMiddleware();
        services.AddMetricsReportingHostedService();
        services.AddMetricsEndpoints();

        return services;
    }

    public static WebApplication UseInfluxdbConfiguration(this WebApplication app)
    {
        app.UseMetricsAllEndpoints();

        /*
         
        app.UseMetricsApdexTrackingMiddleware();
        app.UseMetricsRequestTrackingMiddleware();
        app.UseMetricsErrorTrackingMiddleware();
        app.UseMetricsActiveRequestMiddleware();
        app.UseMetricsPostAndPutSizeTrackingMiddleware();
        app.UseMetricsOAuth2TrackingMiddleware();

        OU

        */

        app.UseMetricsAllMiddleware();

        return app;
    }

}