using Microsoft.EntityFrameworkCore;
using School.Data.Contexts;
using School.Repository.Seeding.SeedingBase;

namespace School.Web.Helper
{
    public class ApplySeeding
    {
        public static async Task ApplySeedingAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();

                try
                {
                    var context = services.GetRequiredService<SchoolDbContext>();
                    await context.Database.MigrateAsync();
                    await SchoolContextSeed.SeedAsync(context, loggerFactory);
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<ApplySeeding>();
                    logger.LogError(ex.Message);
                }

            }

        }
    }
}
