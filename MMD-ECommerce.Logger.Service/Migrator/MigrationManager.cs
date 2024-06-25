using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using FluentMigrator.Runner;

namespace MMD_ECommerce.Logger.Service.Migrator;

/// <summary>
/// Provides extension methods for database migration.
/// </summary>
public static class MigrationManager
{
    /// <summary>
    /// Applies database migrations at application startup.
    /// </summary>
    /// <param name="app">The <see cref="WebApplication"/> instance.</param>
    /// <returns>The modified <see cref="WebApplication"/> instance.</returns>
    public static IApplicationBuilder MigrateLoggerDatabase(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var databaseService = services.GetRequiredService<Database>();
            var migrationService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
            var logger = services.GetRequiredService<ILogger<Database>>();
            try
            {
                databaseService.CreateDatabase("MMD_ECommerceLoggerDb");
                migrationService.ListMigrations();
                migrationService.MigrateUp(202406200001);
            }
            catch (Exception)
            {
                throw;
            }
        }
        return app;
    }
}

