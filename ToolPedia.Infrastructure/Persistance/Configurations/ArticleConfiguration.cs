using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json.Linq;
using ToolPedia.Domain.Entities;

namespace ToolPedia.Infrastructure.Persistence.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("article");

            builder.HasKey(t => t.Id);

            builder.Property(ur => ur.Id).HasDefaultValueSql("gen_random_uuid()");

            builder.HasIndex(t => t.DateCreated);
        }
    }
}
