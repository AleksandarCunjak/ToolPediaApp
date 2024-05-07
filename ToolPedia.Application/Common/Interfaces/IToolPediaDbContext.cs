using Microsoft.EntityFrameworkCore;
using ToolPedia.Domain.Entities;

namespace ToolPedia.Application.Common.Interfaces
{
    public interface IToolPediaDbContext
    {
        DbSet<Tool> Tools { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Article> Articles { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
