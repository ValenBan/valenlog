using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using valenlog.Application.DTOs.Externals;
using valenlog.Application.DTOs.Output;
using valenlog.Application.Interfaces;
using valenlog.Domain.Entities;

namespace valenlog.Application.UCs.Blogs.Queries.GetPostHeaders
{
    public class GetPostHeadersHandler : IRequestHandler<GetPostHeadersQuery, List<PostHeadersOutputDTO>>
    {
        private readonly IBlogRepository _blogRepository;
        public GetPostHeadersHandler(IBlogRepository blogRepository) { _blogRepository = blogRepository; }

        public async Task<List<PostHeadersOutputDTO>> Handle(GetPostHeadersQuery request, CancellationToken cancellationToken)
        {
            List<PostHeaderDTO> postsHeaders = await _blogRepository.GetPostHeadersAsync();

            List<PostHeadersOutputDTO> postsHeadersOutput = postsHeaders.Select(x => new PostHeadersOutputDTO(
            x.cuid,
            x.title,
            x.url,
            x.publishedAt,
            x.tags.Select(t => new tag(t.name)).ToList()
             )).ToList();

            return postsHeadersOutput;
        }
    }
}
