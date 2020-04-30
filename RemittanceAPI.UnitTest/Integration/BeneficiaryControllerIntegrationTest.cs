using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RemittanceAPI.Provider;
using RemittanceAPI.V1.Models.Response;
using Xunit;

namespace RemittanceAPI.Test.Integration
{
    public class BeneficiaryControllerIntegrationTest
    {
        private readonly IHost _host;
        private readonly HttpClient _client;
        private const string TestAccessKey = "AccessKey123";

        private const string GetBeneficiaryNameUri = "/api/v1/beneficiarymanagement/getbeneficiaryname?AccessKey={0}&AccountNumber={1}&BankCode={2}";
        private const string GetCountryListUri = "/api/v1/beneficiarymanagement/getcountrylist?AccessKey={0}";
        private const string GetBankListUri = "/api/v1/beneficiarymanagement/getbanklist?AccessKey={0}&Country={1}";


        public BeneficiaryControllerIntegrationTest()
        {
            var hostBuilder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
                    webHost.UseTestServer();
                    webHost.UseStartup<Startup>();

                    webHost.ConfigureTestServices(collection =>
                    {
                        collection.AddTransient<IThirdPartyProvider, FakeThirdPartyProvider>();
                    });
                });

            _host = hostBuilder.StartAsync().Result;
            _client = _host.GetTestClient();
            _client.DefaultRequestVersion = new Version(1, 0, 0);
        }

        [Fact]
        public async Task GetBeneficiaryName_ShouldReturnInvalidRequestErrorWhenAccessKeyIsEmpty()
        {
            var response = await _client.GetAsync(string.Format(GetBeneficiaryNameUri, "", "Account1", "Test Bank"));
            var responseMessage = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task GetBeneficiaryName_ShouldReturnCorrectAccountName()
        {
            var response = await _client.GetAsync(string.Format(GetBeneficiaryNameUri, TestAccessKey, "Account1", "Test Bank"));
            var responseMessage = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<BeneficiaryResponse>(responseMessage);

            Assert.Equal("My account", responseObject.AccountName);
        }

        [Fact]
        public async Task GetCountryList_ShouldReturnAllCountryListWhenAccessKeyIsNotEmpty()
        {
            var response = await _client.GetAsync(string.Format(GetCountryListUri, TestAccessKey));
            var responseMessage = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<ICollection<CountryResponse>>(responseMessage);

            Assert.NotEqual(0, responseObject.Count);
        }

        [Fact]
        public async Task GetBankList_ShouldReturnInvalidRequestModelErrorWhenCountryCodeIsNotValidFormat()
        {
            var response = await _client.GetAsync(string.Format(GetBankListUri, TestAccessKey, "Sweden"));
            var responseMessage = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

    }
}