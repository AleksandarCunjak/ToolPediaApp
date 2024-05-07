using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using ToolPedia.Application.Common.Interfaces;
using ToolPedia.Application.Tools.Models.Requests;
using ToolPedia.Application.Tools.Models.Responses;
using ToolPedia.Domain.Entities;

namespace ToolPedia.Application.Tools.Commands
{
    public record CreateToolCommand : IRequest<ToolResponse>
    {
        public required CreateToolRequest CreateToolRequest { get; set; }

        public class Handler : IRequestHandler<CreateToolCommand, ToolResponse>
        {
            private readonly IMapper _mapper;
            private readonly IToolPediaDbContext _dbContext;

            public Handler(IMapper mapper, IToolPediaDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<ToolResponse> Handle(
                CreateToolCommand request,
                CancellationToken cancellationToken
            )
            {
                var tool = _mapper.Map<Tool>(request.CreateToolRequest);

                await _dbContext.Tools.AddAsync(tool);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return _mapper.Map<ToolResponse>(tool);
            }
        }
    }
}
