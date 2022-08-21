using Observability.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfiguration();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddInfluxdbConfiguration();

var app = builder.Build();

app.UseApiConfiguration();
app.UseSwaggerConfiguration();
app.UseInfluxdbConfiguration();

app.Run();
