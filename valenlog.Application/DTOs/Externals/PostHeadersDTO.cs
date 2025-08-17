using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace valenlog.Application.DTOs.Externals
{
    using System;
    using System.Collections.Generic;

    public sealed record PostHeaderDTO(
        string cuid,
        string title,
        string url,
        DateTime publishedAt,
        IReadOnlyList<Tag> tags
    );

    public sealed record Tag(string name);
}
