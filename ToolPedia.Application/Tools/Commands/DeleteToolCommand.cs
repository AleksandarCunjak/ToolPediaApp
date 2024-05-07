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
    public record DeleteToolCommand : IRequest<Task>
    {
        public int ToolId { get; set; }

        public class Handler : IRequestHandler<DeleteToolCommand, Task>
        {
            private readonly IMapper _mapper;
            private readonly IToolPediaDbContext _dbContext;

            public Handler(IMapper mapper, IToolPediaDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<Task> Handle(
                DeleteToolCommand request,
                CancellationToken cancellationToken
            )
            {
                var tool = await _dbContext.Tools.FindAsync(request.ToolId);

                if (tool == null)
                {
                    throw new ToolNotFoundException($"Tool with ID {request.ToolId} not found");
                }

                // Optionally, you can mark the entity as modified if you're using Entity Framework Core
                _dbContext.Tools.Remove(tool);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return Task.CompletedTask;
            }
        }
    }
}
