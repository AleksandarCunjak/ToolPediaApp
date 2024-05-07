using AutoMapper;
using ToolPedia.Application.Articles.Models.Requests;
using ToolPedia.Application.Articles.Models.Responses;
using ToolPedia.Application.Tools.Models.Requests;
using ToolPedia.Domain.Entities;

namespace ToolPedia.Api.Mappings
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<CreateArticleRequest, Article>();
            CreateMap<Article, ArticleResponse>();
        }
    }
}
