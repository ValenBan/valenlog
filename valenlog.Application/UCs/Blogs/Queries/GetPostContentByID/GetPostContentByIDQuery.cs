using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using valenlog.Application.DTOs.Externals;

namespace valenlog.Application.UCs.Blogs.Queries.GetPostContent
{
    public class GetPostContentByIDQuery : IRequest<content>
    {
        public string ID { get; set; }
    }
}
