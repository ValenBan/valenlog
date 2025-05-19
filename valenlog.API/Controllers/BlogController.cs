using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using valenlog.Application.Common.Responses;
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
            throw new Exception("Mamita posho, se rompio algo");
            var blogs = await _mediator.Send(new GetAllBlogsQuery());
            return Ok(ApiResponse<List<Blog>>.Ok(blogs, "Blogs obtenidos con éxito"));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog([FromBody] AddBlogCommand addBlogCommand)
        {
            //return Ok(await _mediator.Send(addBlogCommand));
            var idBlogCreated = await _mediator.Send(addBlogCommand);

            return Ok(ApiResponse<int>.Ok(idBlogCreated, $"Se creo el blog numero {idBlogCreated}"));

        }
    }
}
