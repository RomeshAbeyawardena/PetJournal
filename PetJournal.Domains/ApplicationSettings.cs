using Microsoft.Extensions.Configuration;
using _Constants = PetJournal.Domains.Constants.Constants;
namespace PetJournal.Domains
{
    public class ApplicationSettings
    {
        public ApplicationSettings(IConfiguration configuration)
        {
            configuration.Bind(this);
            DefaultConnectionString = configuration.GetConnectionString(_Constants.DefaultConnectionString);
        }

        public string DefaultConnectionString { get; set; }
    }
}
