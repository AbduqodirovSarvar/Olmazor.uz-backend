using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using OlmaTech.Api.Extentions;
using OlmaTech.Application.Services;
using OlmaTech.Infrastructure.Extentions;
using OlmaTech.Infrastructure.Persistance.EntityFramework;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.ConfigureServices();

var app = builder.Build();

// Configure the HTTP request pipeline
app.ConfigurePipeline();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<AppDbContext>();
try
{
    await context.Database.MigrateAsync();
    Console.WriteLine("Migrations applied successfully.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error applying migrations: {ex.Message}");
}
try
{
    await context.SeedAsync();
    Console.WriteLine("default data added succesfully.");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

app.Run();