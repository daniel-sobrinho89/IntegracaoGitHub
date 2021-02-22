using IntegracaoGitHub.Infrastructure.Context;
using IntegracaoGitHub.Infrastructure.Repository;
using IntegracaoGitHub.Infrastructure.Repository.Interface;
using IntegracaoGitHub.Services;
using IntegracaoGitHub.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IntegracaoGitHub.Infrastructure.IoC
{
    public static class AppServices
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IHomeRepository, HomeRepository>();
        }
        public static void ConfigureDataBases(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration["ConnectionStrings:DB.SQLite"];
            services.AddDbContext<HomeContext>(options =>
                options.UseSqlite(connection)
            );
        }
    }
}
