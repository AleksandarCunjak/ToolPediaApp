using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToolPedia.Application.Common.Interfaces;
using ToolPedia.Application.Tools.Models.Responses;
using ToolPedia.Domain.Entities;

namespace ToolPedia.Application.Tools.Queries
{
    public record SearchToolsQuery : IRequest<ToolResponseList>
    {
        public required string Query { get; set; }
        public int? page { get; set; }
        public int? perPage { get; set; }
        public string? Sort { get; set; }

        public class Handler : IRequestHandler<SearchToolsQuery, ToolResponseList>
        {
            private readonly IMapper _mapper;
            private readonly IToolPediaDbContext _dbContext;

            public Handler(IMapper mapper, IToolPediaDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<ToolResponseList> Handle(
                SearchToolsQuery request,
                CancellationToken cancellationToken
            )
            {
                var tools = _dbContext.Tools.AsNoTracking().AsQueryable();

                tools = ApplySearch(tools, request.Query.ToLower());

                if (request.Sort is not null)
                {
                    tools = tools.OrderBy(t => request.Sort);
                }

                var page = request.page ?? 0;
                var perPage = request.perPage ?? 20;

                var toolEntities = await tools
                    .Skip(page * perPage)
                    .Take(perPage)
                    .ToListAsync(cancellationToken: cancellationToken);

                var toolResponses = _mapper.Map<List<ToolResponse>>(toolEntities);

                return new ToolResponseList
                {
                    Tools = toolResponses,
                    Total = await tools.CountAsync()
                };
            }

            private static IQueryable<Tool> ApplySearch(IQueryable<Tool> tools, string query) =>
                tools.Where(
                    t =>
                        EF.Functions.Like(t.Name.ToLower(), "%" + query + "%")
                        || (
                            t.Description != null
                            && EF.Functions.Like(t.Description.ToLower(), "%" + query + "%")
                        )
                        || EF.Functions.Like(t.Brand.ToLower(), "%" + query + "%")
                );
        }
    }
}
