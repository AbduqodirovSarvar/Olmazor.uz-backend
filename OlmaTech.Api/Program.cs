using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;
using OlmaTech.Application.Services;
using OlmaTech.Infrastructure.Extentions;
using OlmaTech.Infrastructure.Persistance.EntityFramework;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});

builder.Logging.SetMinimumLevel(LogLevel.Warning);

// Define default culture and supported cultures
var defaultCulture = new CultureInfo("en");
var supportedCultures = new[]
{
    new CultureInfo("en"),
    new CultureInfo("uz"),
    new CultureInfo("ru"),
};

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture(defaultCulture);
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddScoped<Localization>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var localization = services.GetRequiredService<Localization>();

    Console.WriteLine(localization.Get("UserRole_Admin")); // Ensure "test" key exists in your resources
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRequestLocalization();
app.UseAuthorization();
app.MapControllers();

app.Run();


public class Localization
{
    private readonly IStringLocalizer<Localization> _localizer;

    public Localization(IStringLocalizer<Localization> localizer)
    {
        _localizer = localizer;
    }

    public string Get(string key)
    {
        return _localizer[key];
    }
}