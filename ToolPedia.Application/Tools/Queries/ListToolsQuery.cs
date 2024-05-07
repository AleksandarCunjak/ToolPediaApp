using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ToolPedia.Application.Common.Interfaces;
using ToolPedia.Application.Tools.Models.Responses;

namespace ToolPedia.Application.Tools.Queries
{
    public record ListToolsQuery : IRequest<ToolResponseList>
    {
        public int? Page { get; set; }
        public int? PerPage { get; set; }

        public class Handler : IRequestHandler<ListToolsQuery, ToolResponseList>
        {
            private readonly IMapper _mapper;
            private readonly IToolPediaDbContext _dbContext;

            public Handler(IMapper mapper, IToolPediaDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<ToolResponseList> Handle(
                ListToolsQuery request,
                CancellationToken cancellationToken
            )
            {
                var tools = _dbContext.Tools.AsNoTracking().AsQueryable();

                var page = request.Page ?? 0;
                var perPage = request.PerPage ?? 20;

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
        }
    }
}
