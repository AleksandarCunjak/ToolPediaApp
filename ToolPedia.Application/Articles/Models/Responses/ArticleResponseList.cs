using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolPedia.Domain.Enums;

namespace ToolPedia.Application.Articles.Models.Responses
{
    public class ArticleResponseList
    {
        public required ICollection<ArticleResponse> Articles { get; set; }
        public required int Total { get; set; }
        //    public required int Page { get; set; }
        //    public required int PerPage { get; set; }
        //    public required int TotalPages { get; set; }
        //}
    }
}
