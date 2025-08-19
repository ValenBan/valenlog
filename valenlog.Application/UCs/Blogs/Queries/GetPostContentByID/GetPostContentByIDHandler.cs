using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using valenlog.Application.DTOs.Externals;
using valenlog.Application.Interfaces;
using valenlog.Application.UCs.Blogs.Queries.GetPostContent;

namespace valenlog.Application.UCs.Blogs.Queries.GetPostContentByID
{
    public class GetPostContentByIDHandler : IRequestHandler<GetPostContentByIDQuery, content>
    {
        private readonly IPostRepository _postRepository;

        public GetPostContentByIDHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<content> Handle(GetPostContentByIDQuery request, CancellationToken cancellationToken)
        {
            PostHeaderDTO postFinded = await _postRepository.GetPostHeaderByIDAsync(request.ID);

            if (postFinded == null)
                throw new Exception("Post not found");

            return await _postRepository.GetPostConentByIDAsync(request.ID);

        }   
    }
}
