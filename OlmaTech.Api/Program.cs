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

builder.Services.AddHttpContextAccessor();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

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