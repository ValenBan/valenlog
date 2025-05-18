using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using valenlog.Domain.Entities;

namespace valenlog.Application.Interfaces
{
    public interface IBlogRepository
    {
		public Task<List<Blog>> GetAllBlogsAsync();
		public Task<Blog> GetBlogByIdAsync(int id);
		public Task<int> AddBlogAsync(Blog blog);
	}
}
