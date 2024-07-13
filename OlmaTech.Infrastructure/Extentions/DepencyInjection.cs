using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OlmaTech.Application.Abstractions;
using OlmaTech.Infrastructure.Persistance.EntityFramework;
using OlmaTech.Application.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Microsoft.EntityFrameworkCore;

namespace OlmaTech.Infrastructure.Extentions
{
    public static class DepencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplication();

            services.AddScoped<IAppDbContext, AppDbContext>();

            //var connectionString = configuration.GetConnectionString("DefaultConnection");

            /*var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);
            var dataSource = dataSourceBuilder.Build();*/

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                    o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
            });

            /*services.AddDbContext<IAppDbContext, AppDbContext>((serviceProvider, options) =>
            {
                
                options.UseNpgsql(dataSource,
                    options =>
                    {
                        options.MigrationsAssembly(typeof(AppDbContext).Assembly.GetName().Name);
                        options.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(30), errorCodesToAdd: null);
                        options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                    })
                    .EnableSensitiveDataLogging();
            });*/

            /*services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));

            using var serviceProvider = services.BuildServiceProvider();
            var hashService = serviceProvider.GetRequiredService<IHashService>();
            DefautUserData.Initialize(hashService);

            services.AddAuthorization();*/

            return services;
        }
    }
}
