using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using valenlog.Domain.Entities;

namespace valenlog.Application.UCs.Blogs.Queries.GetAllBlogs
{
    public class GetAllBlogsQuery  : IRequest<List<Blog>>
    {
    }
}
