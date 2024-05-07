using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToolPedia.Application.Articles.Models.Responses;
using ToolPedia.Application.Common.Interfaces;

namespace ToolPedia.Application.Articles.Queries
{
    public record ListArticlesQuery : IRequest<ArticleResponseList>
    {
        public int? Page { get; set; }
        public int? PerPage { get; set; }
        public string? Sort { get; set; }

        public class Handler : IRequestHandler<ListArticlesQuery, ArticleResponseList>
        {
            private readonly IMapper _mapper;
            private readonly IToolPediaDbContext _dbContext;

            public Handler(IMapper mapper, IToolPediaDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<ArticleResponseList> Handle(
                ListArticlesQuery request,
                CancellationToken cancellationToken
            )
            {
                var articles = _dbContext.Articles.AsNoTracking().AsQueryable();

                var page = request.Page ?? 0;
                var perPage = request.PerPage ?? 20;

                var articleEntities = await articles
                    .OrderByDescending(a => a.DateCreated)
                    .Skip(page * perPage)
                    .Take(perPage)
                    .ToListAsync(cancellationToken: cancellationToken);

                var articleResponses = _mapper.Map<List<ArticleResponse>>(articleEntities);

                return new ArticleResponseList
                {
                    Articles = articleResponses,
                    Total = await articles.CountAsync()
                };
            }
        }
    }
}
