using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using valenlog.Application.DTOs.Externals;
using valenlog.Application.DTOs.Output;
using valenlog.Domain.Entities;

namespace valenlog.Application.UCs.Blogs.Queries.GetHotPosts
{
    public class GetRelevantPostHeadersQuery : IRequest<List<PostHeadersOutputDTO>>
    {

    }
}
