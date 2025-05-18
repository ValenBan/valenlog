using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using valenlog.Application.Interfaces;
using valenlog.Domain.Entities;
using valenlog.Infrastructure.Data;
namespace valenlog.Infrastructure.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly ValenlogDbContext _context;
        public BlogRepository(ValenlogDbContext context)
        {
            _context = context;
        }
        public Task<List<Blog>> GetAllBlogsAsync()
        {
            return _context.Blogs.ToListAsync();
        }
        public Task<Blog> GetBlogByIdAsync(int id)
        {
            return _context.Blogs.FirstAsync();
        }
        public async Task<int> AddBlogAsync(Blog blog)
        {
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();
            return blog.Id;
        }
    }
}
