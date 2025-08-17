using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace valenlog.Application.UCs.Blogs.Commands.RegisterView
{
    public class RegisterViewCommand : IRequest<bool>
    {
        public string ID { get; set; }
    }
}
