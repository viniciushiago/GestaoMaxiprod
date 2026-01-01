using Domain.Interfaces.Repositories;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoMaxiprod.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrasctrute(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<GestaoDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IPersonRepository, PersonRepository>();

            return services;
        }

    }
}
