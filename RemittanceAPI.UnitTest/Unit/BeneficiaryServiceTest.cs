using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using RemittanceAPI.Provider;
using RemittanceAPI.Service;
using RemittanceAPI.V1.Models.Request;
using RemittanceAPI.V1.Models.Response;
using Xunit;

namespace RemittanceAPI.UnitTest
{
    public class BeneficiaryServiceTest
    {
        private BeneficiaryManagementService beneficiaryService;
        private Mock<IThirdPartyProvider> thirdPartyProviderMock;
        private string testAccessKey = "accessKey";

        public BeneficiaryServiceTest()
        {
            thirdPartyProviderMock = new Mock<IThirdPartyProvider>();
            thirdPartyProviderMock.Setup(x => x.GetBeneficiaryName(It.IsAny<BeneficiaryRequest>()))
                .Returns(Task.FromResult(new BeneficiaryResponse() {AccountName = "Test Account"}));

            thirdPartyProviderMock.Setup(x => x.GetCountries(It.IsAny<string>()))
                .Returns(Task.FromResult(new CountryResponse[]{ new CountryResponse(){Code = "US", Name = "America"} }));

            thirdPartyProviderMock.Setup(x => x.GetStates(It.IsAny<string>()))
                .Returns(Task.FromResult(new StateResponse[] { new StateResponse() { Code = "TX", Name = "Texas" }, 
                    new StateResponse() { Code = "NY", Name = "New York" } }));

            thirdPartyProviderMock.Setup(x => x.GetBanks(It.IsAny<BankRequest>()))
                .Returns(Task.FromResult(new BankResponse[] { new BankResponse() { Code = "TX", Name = "Texas Bank" },
                    new BankResponse() { Code = "NY", Name = "NY Bank" } }));

            beneficiaryService = new BeneficiaryManagementService(thirdPartyProviderMock.Object);
        }

        [Fact]
        public async Task GetBeneficiaryName_ShouldReturnValueFromThirdPartyService()
        {
            var result = await beneficiaryService.GetBeneficiaryName(new BeneficiaryRequest());
            Assert.Equal( "Test Account", result.AccountName);
        }

        [Fact]
        public async Task GetCountryList_ShouldReturnValueFromThirdPartyService()
        {
            var result = await beneficiaryService.GetCountries(testAccessKey);
            IList<CountryResponse> resultList = result as IList<CountryResponse>;
            Assert.Equal("US", resultList[0].Code);
            Assert.Equal("America", resultList[0].Name);
        }

        [Fact]
        public async Task GetCountryList_ShouldContainOneElementFromThirdPartyService()
        {
            var result = await beneficiaryService.GetCountries(testAccessKey);
            Assert.Equal(1, result.Count);
        }

        [Fact]
        public async Task GetStateList_ShouldReturnValueFromThirdPartyService()
        {
            var result = await beneficiaryService.GetStateList(testAccessKey);
            IList<StateResponse> resultList = result as IList<StateResponse>;
            Assert.Equal("TX", resultList[0].Code);
            Assert.Equal("Texas", resultList[0].Name);

            Assert.Equal("NY", resultList[1].Code);
            Assert.Equal("New York", resultList[1].Name);
        }

        [Fact]
        public async Task GetStateList_ShouldContainTwoElementFromThirdPartyService()
        {
            var result = await beneficiaryService.GetStateList(testAccessKey);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetBankList_ShouldReturnValueFromThirdPartyService()
        {
            var result = await beneficiaryService.GetBankList(new BankRequest());
            IList<BankResponse> resultList = result as IList<BankResponse>;
            Assert.Equal("TX", resultList[0].Code);
            Assert.Equal("Texas Bank", resultList[0].Name);

            Assert.Equal("NY", resultList[1].Code);
            Assert.Equal("NY Bank", resultList[1].Name);
        }

        [Fact]
        public async Task GetBankList_ShouldContainTwoElementFromThirdPartyService()
        {
            var result = await beneficiaryService.GetStateList(testAccessKey);
            Assert.Equal(2, result.Count);
        }

    }
}
