using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ToolPedia.Application.Articles.Commands;
using ToolPedia.Application.Articles.Models.Requests;
using ToolPedia.Application.Articles.Queries;

namespace ToolPedia.Api.Controllers
{
    [ApiController]
    [Route("api/articles")]
    [EnableCors("AllowFrontend")]
    public class ArticlesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArticlesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("articles")]
        public async Task<IActionResult> GetArticles(int? page, int? perPage, string? sort)
        {
            var articles = await _mediator.Send(
                new ListArticlesQuery
                {
                    PerPage = perPage,
                    Page = page,
                    Sort = sort
                }
            );

            return Ok(articles);
        }

        //[HttpPatch("{toolId}")]
        //public async Task<IActionResult> UpdateTool(
        //    int toolId,
        //    [FromBody] UpdateToolRequest updateToolRequest
        //)
        //{
        //    var updatedTool = await _mediator.Send(
        //        new UpdateToolCommand { ToolId = toolId, UpdateToolRequest = updateToolRequest }
        //    );

        //    return Ok(updatedTool);
        //}

        [HttpPost("create")]
        // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateArticle([FromBody] CreateArticleRequest article)
        {
            var newArticle = await _mediator.Send(
                new CreateArticleCommand { CreateToolRequest = article }
            );

            return Created();
        }

        //[HttpDelete("{toolId}")]
        //public async Task<IActionResult> DeleteTool(int toolId)
        //{
        //    await _mediator.Send(new DeleteToolCommand { ToolId = toolId });

        //    return NoContent();
        //}
    }
}
