using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ToolPedia.Application.Common.Filters;
using ToolPedia.Application.Common.Interfaces;
using ToolPedia.Application.Tools.Models.Responses;
using ToolPedia.Domain.Entities;

namespace ToolPedia.Application.Tools.Queries
{
    public record FilterSortToolsQuery : IRequest<ToolResponseList>
    {
        public ToolFilter? Filter { get; set; }
        public string? Fields { get; set; }
        public int? page { get; set; }
        public int? perPage { get; set; }
        public string? Sort { get; set; }

        public class Handler : IRequestHandler<FilterSortToolsQuery, ToolResponseList>
        {
            private readonly IMapper _mapper;
            private readonly IToolPediaDbContext _dbContext;

            public Handler(IMapper mapper, IToolPediaDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<ToolResponseList> Handle(
                FilterSortToolsQuery request,
                CancellationToken cancellationToken
            )
            {
                var tools = _dbContext.Tools.AsNoTracking().AsQueryable();

                if (request.Filter is not null)
                {
                    tools = ApplyFilter(tools, request.Filter);
                }
                if (!request.Sort.IsNullOrEmpty())
                {
                    tools = ApplySorting(tools, request.Sort!);
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

            private static IQueryable<Tool> ApplyFilter(IQueryable<Tool> sites, ToolFilter filter)
            {
                if (filter.ToolType?.Count > 0)
                    sites = sites.Where(c => filter.ToolType.Contains(c.ToolType!));

                if (filter.PowerSupply?.Count > 0)
                    sites = sites.Where(c => filter.PowerSupply.Contains(c.PowerSupply!));

                if (filter.PriceBetween is not null)
                    sites = sites.Where(
                        c => filter.PriceBetween[0] <= c.Price && filter.PriceBetween[1] >= c.Price
                    );

                return sites;
            }

            private IQueryable<Tool> ApplySorting(IQueryable<Tool> query, string sort)
            {
                var sortExpression = CreateSortingExpression(sort);
                return query.OrderBy(sortExpression);
            }

            private Expression<Func<Tool, object>> CreateSortingExpression(string sort)
            {
                var propertyName = sort.Trim();
                var parameter = Expression.Parameter(typeof(Tool), "x");
                var property = Expression.Property(parameter, propertyName);
                var selector = Expression.Lambda(property, parameter);

                return Expression.Lambda<Func<Tool, object>>(
                    Expression.Convert(selector.Body, typeof(object)),
                    parameter
                );
            }
        }
    }
}
