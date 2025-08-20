using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace valenlog.Application.Exceptions
{
    public class PostNotFoundException : Exception
    {
        public PostNotFoundException(string id)
            : base($"Post with ID {id} was not found.")
        {
        }
    }
}
