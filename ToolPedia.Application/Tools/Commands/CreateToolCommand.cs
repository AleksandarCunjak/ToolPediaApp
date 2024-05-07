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
                tool.Images = GenerateSasToken("images", "shaomi.jpg");

                await _dbContext.Tools.AddAsync(tool);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return _mapper.Map<ToolResponse>(tool);
            }

            public string GenerateSasToken(string containerName, string blobName)
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                    "DefaultEndpointsProtocol=https;AccountName=csb1003200368286dfe;AccountKey=1R/NwHio0hIpP3171rF7PFQO8skuepKiulH06VkjWfSBiRqxFBF4gsdrBUGQ7kbScVFRxNH7Htti+AStCwETlA==;EndpointSuffix=core.windows.net"
                );
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference(containerName);
                CloudBlockBlob blob = container.GetBlockBlobReference(blobName);

                SharedAccessBlobPolicy sasPolicy = new SharedAccessBlobPolicy()
                {
                    Permissions = SharedAccessBlobPermissions.Read,
                    SharedAccessExpiryTime = DateTime.UtcNow.AddHours(1), // Set expiry time as needed
                };

                string sasToken = blob.GetSharedAccessSignature(sasPolicy);
                return blob.Uri + sasToken;
            }
        }
    }
}
