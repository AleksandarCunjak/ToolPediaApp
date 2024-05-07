using System.ComponentModel.DataAnnotations;
using ToolPedia.Domain.Enums;

namespace ToolPedia.Application.Common.Filters
{
    public class ToolFilter
    {
        public ICollection<ToolPowerSupplyCategory>? PowerSupply { get; set; }
        public ICollection<ToolType>? ToolType { get; set; }

        [Length(2, 2, ErrorMessage = "PriceBetween array must have exactly 2 elements")]
        public double[]? PriceBetween { get; set; }
        public ICollection<string>? Brand { get; set; }
        public DateTime? DateCreatedAfter { get; set; }
    }
}
