using Microsoft.Extensions.DependencyInjection;
using PetJournal.Contracts;
using PetJournal.Contracts.Providers;
using PetJournal.Domains;
using PetJournal.Services.Providers;
using Shared.Contracts;

namespace PetJournal.Services
{
    public class ServiceRegistration : IServiceRegistration
    {
        public void RegisterServices(IServiceCollection services)
        {
            services
                .AddSingleton<ApplicationSettings>()
                .AddSingleton<ICacheProvider, CacheProvider>()
                .AddScoped<IPetTypeService, PetTypeService>()
                .AddScoped<IPetBreedService, PetBreedService>();
        }
    }
}
