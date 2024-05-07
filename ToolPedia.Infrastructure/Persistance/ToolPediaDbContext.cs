using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ToolPedia.Application.Common.Interfaces;
using ToolPedia.Domain.Entities;

namespace ToolPedia.Infrastructure.Persistance
{
    public class ToolPediaDbContext : DbContext, IToolPediaDbContext
    {
        public DbSet<Tool> Tools { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }

        public ToolPediaDbContext(DbContextOptions<ToolPediaDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
