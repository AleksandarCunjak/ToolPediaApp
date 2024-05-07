using AutoMapper;
using MediatR;
using ToolPedia.Application.Articles.Models.Requests;
using ToolPedia.Application.Articles.Models.Responses;
using ToolPedia.Application.Common.Interfaces;
using ToolPedia.Domain.Entities;

namespace ToolPedia.Application.Articles.Commands
{
    public record CreateArticleCommand : IRequest<ArticleResponse>
    {
        public required CreateArticleRequest CreateToolRequest { get; set; }

        public class Handler : IRequestHandler<CreateArticleCommand, ArticleResponse>
        {
            private readonly IMapper _mapper;
            private readonly IToolPediaDbContext _dbContext;

            public Handler(IMapper mapper, IToolPediaDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<ArticleResponse> Handle(
                CreateArticleCommand request,
                CancellationToken cancellationToken
            )
            {
                var article = _mapper.Map<Article>(request.CreateToolRequest);

                article.DateCreated = DateTime.UtcNow;

                await _dbContext.Articles.AddAsync(article);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return _mapper.Map<ArticleResponse>(article);
            }
        }
    }
}
