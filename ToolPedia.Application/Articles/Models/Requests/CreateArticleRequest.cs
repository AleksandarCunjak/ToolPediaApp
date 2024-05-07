using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ToolPedia.Domain.Enums;

namespace ToolPedia.Application.Articles.Models.Requests
{
    public class CreateArticleRequest
    {
        public required string Title { get; set; }
        public required string Content { get; set; }
        public required string Image { get; set; }
    }
}
