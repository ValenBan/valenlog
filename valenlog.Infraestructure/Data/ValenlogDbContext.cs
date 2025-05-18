using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using valenlog.Domain.Entities;

namespace valenlog.Infrastructure.Data
{
    public class ValenlogDbContext : DbContext
    {
        public ValenlogDbContext(DbContextOptions<ValenlogDbContext> options) : base(options)
        {

        }

        public DbSet<Blog> Blogs { get; set; }
        
    }
}
