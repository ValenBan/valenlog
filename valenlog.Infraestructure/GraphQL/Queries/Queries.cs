using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace valenlog.Infrastructure.GraphQL.Queries
{
    public static class Queries
    {
        public const string GetMyPosts = @"
        query GetMyPosts {
          user(username: ""ValenBan"") {
            posts(page: 1, pageSize: 20) {
              nodes {
                cuid
                title
                url
                publishedAt
                tags {
                  name
                }
              }
            }
          }
        }
        ";
    }
}
