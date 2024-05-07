using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json.Linq;
using ToolPedia.Domain.Entities;

namespace ToolPedia.Infrastructure.Persistence.Configurations
{
    public class ToolConfiguration : IEntityTypeConfiguration<Tool>
    {
        public void Configure(EntityTypeBuilder<Tool> builder)
        {
            builder.ToTable("tool");

            builder.HasKey(t => t.Id);

            builder.Property(ur => ur.Id).HasDefaultValueSql("gen_random_uuid()");
            builder
                .Property(t => t.Characteristics)
                .HasConversion(
                    v => v.ToString(), // Convert JObject to string
                    v => JObject.Parse(v) // Convert string to JObject
                );

            builder.HasIndex(t => t.Brand);
            builder.HasIndex(t => t.Name);
            builder.HasIndex(t => t.Price);
            builder.HasIndex(t => t.PowerSupply);
            builder.HasIndex(t => t.ToolType);
        }
    }
}
