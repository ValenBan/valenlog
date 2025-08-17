using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
namespace valenlog.Application.DTOs.Externals
{

    public sealed record PostDTO(
        string id,
        string title,
        string url,
        DateTime publishedAt,
        IReadOnlyList<tag> tags,
        content content
    );

    public sealed record content(string html);
}

