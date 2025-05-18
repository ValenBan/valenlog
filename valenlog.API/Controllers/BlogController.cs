using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using valenlog.Application.UCs.Blogs.Commands.AddBlog;
using valenlog.Application.UCs.Blogs.Queries.GetAllBlogs;
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
        public async Task<IActionResult> GetAllBlogs()
        {
            var blogs = await _mediator.Send(new GetAllBlogsQuery());
            return Ok(blogs);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog([FromBody] AddBlogCommand addBlogCommand)
        {
            return Ok(await _mediator.Send(addBlogCommand));
        }
    }
}
