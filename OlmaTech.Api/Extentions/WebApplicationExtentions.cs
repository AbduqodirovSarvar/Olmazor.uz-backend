using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OlmaTech.Domain.Enums;
using System.Security.Claims;
using System.Text;

namespace OlmaTech.Api.Extentions
{
    public static class WebApplicationExtentions
    {
        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddApi(builder.Configuration);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddAuthentication(o =>
            {
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.FromDays(1),
                    ValidateLifetime = true,
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["JwtOptions:ValidIssuer"],
                    ValidAudience = builder.Configuration["JwtOptions:ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["JwtOptions:SecretKey"]!))
                };
                o.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine(context.Exception);
                        return Task.CompletedTask;
                    }
                };
            });
            builder.Services.AddAuthorizationBuilder()
                .AddPolicy("SuperAdminActions", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, UserRole.SuperAdmin.ToString());
                })
                .AddPolicy("AdminActions", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, UserRole.Admin.ToString());
                });

            builder.Services.AddCors(o => o.AddPolicy("AddCors", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
        }

        public static void ConfigurePipeline(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseCors("AddCors");

            app.UseHttpsRedirection();
            app.UseRequestLocalization();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
