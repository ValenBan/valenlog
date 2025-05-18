using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace valenlog.Domain.Entities
{
    public class Blog
    {
        public Blog(string title, string content)
        {
            Title = title;
            Content = content;
        }

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}
