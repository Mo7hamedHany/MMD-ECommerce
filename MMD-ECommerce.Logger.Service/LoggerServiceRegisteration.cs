using Microsoft.Extensions.Configuration;
using MMD_ECommerce.Logger.Service.Contentxt;
using Microsoft.Extensions.DependencyInjection;
using MMD_ECommerce.Logger.Service.Migrator;
using FluentMigrator.Runner;
using System.Reflection;
using Microsoft.Extensions.Logging;

namespace MMD_ECommerce.Logger.Service;

/// <summary>
/// Static class responsible for configuring dependency injection and logging setup for the Logger service.
/// </summary>
public static class LoggerServiceRegisteration
{
    /// <summary>
    /// Configures dependency injection services and sets up Fluent Migrator for database migrations.
    /// </summary>
    /// <param name="services">The collection of services to configure.</param>
    /// <param name="config">The configuration object providing application settings.</param>
    public static void ConfigureServices(this IServiceCollection services, IConfiguration config)
    {
        // Add Dapper context as a singleton service
        services.AddSingleton<DapperContext>();

        // Add Database service as a singleton
        services.AddSingleton<Database>();

        // Configure logging with Fluent Migrator console output
        services.AddLogging(c => c.AddFluentMigratorConsole().ClearProviders().SetMinimumLevel(LogLevel.None))
                .AddFluentMigratorCore()
                .ConfigureRunner(c => c
                .AddSqlServer2016() // Specify SQL Server 2016 as the database provider
                .WithGlobalConnectionString(config.GetConnectionString("LoggerConnection")) // Use the specified connection string from configuration
                .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations()); // Scan the executing assembly for migration classes

        services.AddSingleton<ILoggerProvider, DbLoggerProvider>();

    }
}

