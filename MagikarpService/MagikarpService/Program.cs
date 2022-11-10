using Customers.Api.Database;
using FastEndpoints;
using FastEndpoints.Swagger;
using MagikarpService.Contracts.Responses;
using MagikarpService.Repositories;
using MagikarpService.Services;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder
            .WithOrigins("http://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
        });
});

builder.Services.AddSingleton<IDbConnectionFactory>(_ =>
    new NpgsqlConnectionFactory(config.GetConnectionString("PostgreSqlConnectionString")));
builder.Services.AddSingleton<DatabaseInitializer>();

builder.Services.AddSingleton<IKarpTransactionRepository, KarpTransactionRepository>();
builder.Services.AddSingleton<IKarpTransactionService, KarpTransactionService>();

var app = builder.Build();

app.UseCors("AllowSpecificOrigin");
app.UseFastEndpoints();

app.UseOpenApi();
app.UseSwaggerUi3(s => s.ConfigureDefaults());

var databaseInitializer = app.Services.GetRequiredService<DatabaseInitializer>();
await databaseInitializer.InitializeAsync();

app.Run();
