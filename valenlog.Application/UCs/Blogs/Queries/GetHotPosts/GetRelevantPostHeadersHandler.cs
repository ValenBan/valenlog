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

namespace valenlog.Application.UCs.Blogs.Queries.GetHotPosts
{
    public class GetRelevantPostHeadersHandler : IRequestHandler<GetRelevantPostHeadersQuery, List<PostHeadersOutputDTO>>
    {
        private readonly IPostRepository _postRepository;

        public GetRelevantPostHeadersHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<List<PostHeadersOutputDTO>> Handle(GetRelevantPostHeadersQuery request, CancellationToken cancellationToken)
        {
            List<Post> relevantPosts = await _postRepository.GetRelevantPostHeaders();

            List<PostHeaderDTO> relevantPostHeaders = new List<PostHeaderDTO>();

            foreach (var post in relevantPosts)
            {
                PostHeaderDTO postHeader = await _postRepository.GetPostHeaderByIDAsync(post.id);
                if (postHeader != null)
                {
                    relevantPostHeaders.Add(postHeader);
                }
            }

            List<PostHeadersOutputDTO> postsHeadersOutput = relevantPostHeaders.Select(x => new PostHeadersOutputDTO(
                x.id,
                x.title,
                x.url,
                x.publishedAt,
                x.tags.Select(t => new valenlog.Application.DTOs.Output.tag(t.name)).ToList()
            )).ToList();

            return postsHeadersOutput;
        }
    }
}
