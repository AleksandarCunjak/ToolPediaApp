using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ToolPedia.Application.Common.Exceptions;
using ToolPedia.Application.Common.Interfaces;
using ToolPedia.Application.Tools.Models.Requests;
using ToolPedia.Application.Tools.Models.Responses;
using ToolPedia.Domain.Entities;

namespace ToolPedia.Application.Tools.Commands
{
    public record UpdateToolCommand : IRequest<ToolResponse>
    {
        public int ToolId { get; set; }
        public required UpdateToolRequest UpdateToolRequest { get; set; }

        public class Handler : IRequestHandler<UpdateToolCommand, ToolResponse>
        {
            private readonly IMapper _mapper;
            private readonly IToolPediaDbContext _dbContext;

            public Handler(IMapper mapper, IToolPediaDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<ToolResponse> Handle(
                UpdateToolCommand request,
                CancellationToken cancellationToken
            )
            {
                var tool = await _dbContext.Tools.FindAsync(request.ToolId);

                if (tool == null)
                {
                    throw new ToolNotFoundException($"Tool with ID {request.ToolId} not found");
                }

                _mapper.Map(request.UpdateToolRequest, tool);

                // Optionally, you can mark the entity as modified if you're using Entity Framework Core
                _dbContext.Tools.Update(tool);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return _mapper.Map<ToolResponse>(tool);
            }
        }
    }
}
