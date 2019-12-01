using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PetJournal.Broker;
using PetJournal.Domains;
using Shared.Library.Extensions;
using System.Reflection;

namespace PetJournal.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddAutoMapper(
                    Assembly.GetExecutingAssembly(), 
                    Assembly.GetAssembly(typeof(DomainProfile)))
                .RegisterServiceBroker<PetJournalServiceBroker>(ServiceLifetime.Scoped)
                .AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app
                .ApplicationServices
                .SubscribeToAllNotifications();

            app.UseEndpoints(endpoints =>
            {
                endpoints
                    .MapControllers();
            });
        }
    }
}
