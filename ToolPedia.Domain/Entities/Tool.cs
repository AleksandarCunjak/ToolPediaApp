using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ToolPedia.Domain.Enums;

namespace ToolPedia.Domain.Entities
{
    public class Tool
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required ToolPowerSupplyCategory PowerSupply { get; set; }
        public required ToolType ToolType { get; set; }
        public required JObject Characteristics { get; set; }
        public required string Images { get; set; }
        public required string Brand { get; set; }
        public required double Price { get; set; }
        public int Visits { get; set; } = 0;
        public DateTime DateCreated { get; set; }
    }
}
