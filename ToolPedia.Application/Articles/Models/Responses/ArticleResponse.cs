using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolPedia.Domain.Enums;

namespace ToolPedia.Application.Articles.Models.Responses
{
    public class ArticleResponse
    {
        public required Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public required string Image { get; set; }
        public required DateTime DateCreated { get; set; }
    }
}
