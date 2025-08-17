using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using valenlog.Application.DTOs.Externals;
using valenlog.Domain.Entities;

namespace valenlog.Application.Interfaces
{
    public interface IPostRepository
    {
		public Task<List<PostHeaderDTO>> GetPostHeadersAsync();
        public Task<bool> RegisterViewPostAsync(string id);
        public Task<Post?> GetPostByIDAsync(string id);
        public Task<PostDTO> GetPostHeaderByIDAsync(string id);
        public Task<bool> RegiserPost(Post post);
    }
}
