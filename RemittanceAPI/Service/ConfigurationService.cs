using System.Configuration;

namespace RemittanceAPI.Service
{
    public class ConfigurationService : IConfigurationService
    {
        public string ThirdPartyRemittanceServiceUrl => ConfigurationManager.AppSettings["base_url"];

        public string AccessKey => ConfigurationManager.AppSettings["accessKey123"];

    }
}