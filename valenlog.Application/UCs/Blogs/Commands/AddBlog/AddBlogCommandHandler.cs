using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using valenlog.Application.Interfaces;
using valenlog.Domain.Entities;

namespace valenlog.Application.UCs.Blogs.Commands.AddBlog
{
    public class AddBlogCommandHandler : IRequestHandler<AddBlogCommand, int>
    {
        private readonly IBlogRepository _blogRepository;
        public AddBlogCommandHandler(IBlogRepository blogRepository) { _blogRepository = blogRepository; }

        public async Task<int> Handle(AddBlogCommand request, CancellationToken cancellationToken)
        {
            var blogToInsert = new Blog(request.Title, request.Content);
            return await _blogRepository.AddBlogAsync(blogToInsert);
        }
    }
}
