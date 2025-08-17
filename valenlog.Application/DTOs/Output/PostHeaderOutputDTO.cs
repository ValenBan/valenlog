using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace valenlog.Application.DTOs.Output
{
    public sealed record PostHeadersOutputDTO(
        string id,
        string title,
        string url,
        DateTime publishedAt,
        IReadOnlyList<tag> tags
    );

    public sealed record tag(string name);

}
