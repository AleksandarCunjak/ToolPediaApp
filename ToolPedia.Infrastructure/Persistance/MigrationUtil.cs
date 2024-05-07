using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToolPedia.Infrastructure.Persistance;

namespace ToolPedia.Infrastructure.Persistence
{
    public class MigrationUtil
    {
        public static void MigrateDatabase(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ToolPediaDbContext>();
            context.Database.Migrate();
        }
    }
}
