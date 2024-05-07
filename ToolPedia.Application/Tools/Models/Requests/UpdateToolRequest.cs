using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolPedia.Domain.Enums;

namespace ToolPedia.Application.Tools.Models.Requests
{
    public class UpdateToolRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ToolPowerSupplyCategory? PowerSupply { get; set; }
        public ToolType? ToolType { get; set; }
        public string? Characteristics { get; set; }
        public string? Images { get; set; }
        public string? Brand { get; set; }
        public double? Price { get; set; }
        public int? Visits { get; set; } = 0;
        public DateTime? DateCreated { get; set; }
    }
}
