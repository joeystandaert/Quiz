using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace UI.HostBuilders
{
    public static class AddDbContextHostBuilderExtensions
    {
        public static IHostBuilder AddDbContext(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<DbContext>();

                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["EFC"].ConnectionString;
                IServiceCollection serviceCollection = services.AddSingleton<DbContextOptions>(new DbContextOptionsBuilder().UseSqlServer(connectionString).Options);
                services.AddSingleton<string>(connectionString);
                services.AddSingleton<QuizContextFactory>();

            });

            return hostBuilder;
        }
    }
}