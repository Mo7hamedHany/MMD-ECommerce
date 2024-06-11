using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MMD_ECommerce.Infrastructure.Data.Contexts;
using MMD_ECommerce.Infrastructure.Data.DataSeeding;

namespace MMD_ECommerce.API.Extensions
{
    public static class DbInitializer
    {
        public static async Task InitializeDbAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var service = scope.ServiceProvider;

                var loggerFactory = service.GetRequiredService<ILoggerFactory>();

                try
                {
                    var context = service.GetRequiredService<MMDDataContext>();


                    if ((await context.Database.GetPendingMigrationsAsync()).Any())
                    {
                        await context.Database.MigrateAsync();
                    }

                    await DataContextSeed.SeedData(context);


                }
                catch (Exception ex)
                {

                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex.Message);
                }
            }
        }
    }
}
