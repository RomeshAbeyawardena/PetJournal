using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PetJournal.Contracts;
using PetJournal.Domains;
using PetJournal.Domains.Data;
using Shared.Contracts;
using Shared.Contracts.Providers;
using Shared.Services.Extensions;

namespace PetJournal.Services
{
    public class ServiceRegistration : IServiceRegistration
    {
        public void RegisterServices(IServiceCollection services)
        {
            services
                .AddSingleton<ApplicationSettings>()
                .AddSingleton<ICacheEntityEventHandler, CacheEntityEventHandler>()
                .AddScoped<IPetTypeService, PetTypeService>()
                .AddScoped<IPetBreedService, PetBreedService>()
                .AddScoped<IPetClassificationService, PetClassificationService>()
                .RegisterDefaultEntityValueProvider<PetType>(options => options
                    .AddDefaults(EntityState.Added, (serviceProvider, petType) => { 
                        var clockProvider = serviceProvider.GetRequiredService<IClockProvider>();
                        petType.Created = clockProvider.Now;
                        petType.Modified = clockProvider.Now;
                    }))
                .RegisterDefaultEntityValueProvider<PetBreed>(options => options
                    .AddDefaults(EntityState.Added, (serviceProvider, petBreed) => { 
                        var clockProvider = serviceProvider.GetRequiredService<IClockProvider>();
                        petBreed.Created = clockProvider.Now;
                        petBreed.Modified = clockProvider.Now;
                    }));
        }
    }
}
