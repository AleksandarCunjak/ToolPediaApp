using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolPedia.Domain.Enums;

namespace ToolPedia.Application.Tools.Models.Responses
{
    public class ToolResponseList
    {
        public required ICollection<ToolResponse> Tools { get; set; }
        public required int Total { get; set; }
        //    public required int Page { get; set; }
        //    public required int PerPage { get; set; }
        //    public required int TotalPages { get; set; }
        //}
    }
}
