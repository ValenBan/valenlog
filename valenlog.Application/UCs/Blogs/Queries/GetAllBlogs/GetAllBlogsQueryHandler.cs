using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using valenlog.Application.Interfaces;
using valenlog.Domain.Entities;

namespace valenlog.Application.UCs.Blogs.Queries.GetAllBlogs
{
    public class GetAllBlogsQueryHandler : IRequestHandler<GetAllBlogsQuery, List<Blog>>
    {
        private readonly IBlogRepository _blogRepository;
        public GetAllBlogsQueryHandler(IBlogRepository blogRepository) { _blogRepository = blogRepository; }

        public Task<List<Blog>> Handle(GetAllBlogsQuery request, CancellationToken cancellationToken)
        {
            return _blogRepository.GetAllBlogsAsync();
        }
    }
}
