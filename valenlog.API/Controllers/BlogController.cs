using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using valenlog.Application.Common.Responses;
using valenlog.Application.DTOs.Externals;
using valenlog.Application.DTOs.Output;
using valenlog.Application.UCs.Blogs.Queries.GetPostHeaders;
using valenlog.Domain.Entities;
using valenlog.Infrastructure.Data;

namespace valenlog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPostHeaders()
        {
            var posts = await _mediator.Send(new GetPostHeadersQuery());
            return Ok(ApiResponse<List<PostHeadersOutputDTO>>.Ok(posts));
        }
        
    }
}
