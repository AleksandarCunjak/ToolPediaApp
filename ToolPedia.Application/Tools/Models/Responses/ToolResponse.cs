using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolPedia.Domain.Enums;

namespace ToolPedia.Application.Tools.Models.Responses
{
    public class ToolResponse
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required ToolPowerSupplyCategory PowerSupply { get; set; }
        public required ToolType ToolType { get; set; }
        public required string Characteristics { get; set; }
        public required string Images { get; set; }
        public required double Price { get; set; }
    }
}
