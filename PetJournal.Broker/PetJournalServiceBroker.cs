using PetJournal.Services;
using Shared.Services;
using DataServiceRegistration = PetJournal.Data.ServiceRegistration;
using System.Reflection;

namespace PetJournal.Broker
{
    public class PetJournalServiceBroker : DefaultServiceBroker
    {
        public override Assembly[] GetAssemblies => new [] { 
            DefaultAssembly, 
            Assembly.GetAssembly(typeof(DataServiceRegistration)),
            Assembly.GetAssembly(typeof(ServiceRegistration)) };
    }
}
