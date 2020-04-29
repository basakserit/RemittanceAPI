namespace RemittanceAPI.Service
{
    public interface IConfigurationService
    {
        string ThirdPartyRemittanceServiceUrl { get; }

        string AccessKey { get; }
    }
}