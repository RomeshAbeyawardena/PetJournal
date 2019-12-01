using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PetJournal.Domains;
using Shared.Contracts;

namespace PetJournal.Data
{
    public class ServiceRegistration : IServiceRegistration
    {
        public void RegisterServices(IServiceCollection services)
        {
            services.AddDbContextPool<PetJounalDbContext>((serviceProvider, options) => { 
                var appSettings = serviceProvider.GetRequiredService<ApplicationSettings>(); 
                options.UseSqlServer(appSettings.DefaultConnectionString);
                });
        }
    }
}
