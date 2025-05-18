using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using valenlog.Application.Interfaces;
using valenlog.Infrastructure.Data;
using valenlog.Infrastructure.Repositories;

namespace valenlog.Infrastructure
{
    public static class DependencyInjection
    {

        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<ValenlogDbContext>(options => options.UseSqlite("Data Source = valenlog.db"));

            services.AddScoped<IBlogRepository, BlogRepository>();
        }
    }
}
