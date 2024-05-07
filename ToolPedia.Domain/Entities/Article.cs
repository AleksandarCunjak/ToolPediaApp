using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolPedia.Domain.Entities
{
    public class Article
    {
        public required Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public required string Image { get; set; }
        public required DateTime DateCreated { get; set; }
    }
}
