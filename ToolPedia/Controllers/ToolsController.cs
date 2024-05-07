using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ToolPedia.Application.Common.Filters;
using ToolPedia.Application.Tools.Commands;
using ToolPedia.Application.Tools.Models.Requests;
using ToolPedia.Application.Tools.Queries;

namespace ToolPedia.Api.Controllers
{
    [ApiController]
    [Route("api/tools")]
    [EnableCors("AllowFrontend")]
    public class ToolsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ToolsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("tools")]
        public async Task<IActionResult> GetTools(int? page, int? perPage)
        {
            var tools = await _mediator.Send(new ListToolsQuery { PerPage = perPage, Page = page });

            return Ok(tools);
        }

        [HttpPost("filter")]
        public async Task<IActionResult> FilterSortTools(
            [FromBody] ToolFilter? filter,
            string? sort,
            int? page,
            int? perPage
        )
        {
            var filterSortToolList = await _mediator.Send(
                new FilterSortToolsQuery
                {
                    Filter = filter,
                    perPage = perPage,
                    page = page,
                    Sort = sort
                }
            );

            return Ok(filterSortToolList);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchTools(
            string? sort,
            int? page,
            int? perPage,
            string query
        )
        {
            var searchToolsQuerylList = await _mediator.Send(
                new SearchToolsQuery
                {
                    perPage = perPage,
                    page = page,
                    Sort = sort,
                    Query = query
                }
            );

            return Ok(searchToolsQuerylList);
        }

        [HttpPatch("{toolId}")]
        public async Task<IActionResult> UpdateTool(
            int toolId,
            [FromBody] UpdateToolRequest updateToolRequest
        )
        {
            var updatedTool = await _mediator.Send(
                new UpdateToolCommand { ToolId = toolId, UpdateToolRequest = updateToolRequest }
            );

            return Ok(updatedTool);
        }

        [HttpPost("create")]
        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateTool([FromBody] CreateToolRequest tool)
        {
            var newTool = await _mediator.Send(new CreateToolCommand { CreateToolRequest = tool });

            return Created();
        }

        [HttpDelete("{toolId}")]
        public async Task<IActionResult> DeleteTool(int toolId)
        {
            await _mediator.Send(new DeleteToolCommand { ToolId = toolId });

            return NoContent();
        }
    }
}
