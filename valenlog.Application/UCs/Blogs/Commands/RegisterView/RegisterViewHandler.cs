using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using valenlog.Application.DTOs.Externals;
using valenlog.Application.Interfaces;
using valenlog.Domain.Entities;

namespace valenlog.Application.UCs.Blogs.Commands.RegisterView
{
    public class RegisterViewHandler : IRequestHandler<RegisterViewCommand, bool>
    {
        private readonly IPostRepository _postRepository;

        public RegisterViewHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<bool> Handle(RegisterViewCommand request, CancellationToken cancellationToken)
        {
            Post selectedPost = await _postRepository.GetPostByIDAsync(request.ID);

            if (selectedPost == null)
            {
                PostHeaderDTO PostHeader = await _postRepository.GetPostHeaderByIDAsync(request.ID);

                if (! await _postRepository.existPost(request.ID)) throw new Exception("Post not found");

                await _postRepository.RegiserPost(new Post
                {
                    id = PostHeader.id,
                    title = PostHeader.title,
                    totalReactions = 0
                });
            }

            bool isRegistered = await _postRepository.RegisterViewPostAsync(request.ID);

            return isRegistered;

        }
    }
}
