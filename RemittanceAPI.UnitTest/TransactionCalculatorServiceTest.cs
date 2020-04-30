using Moq;
using RemittanceAPI.Provider;
using RemittanceAPI.Service;
using RemittanceAPI.V1.Models.Request;
using RemittanceAPI.V1.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RemittanceAPI.UnitTest
{
    public class TransactionCalculatorServiceTest
    {
        private TransactionCalculatorService transactionCalculatorService;
        private Mock<IThirdPartyProvider> thirdPartyProviderMock;
        private string testAccessKey = "accessKey";

        public TransactionCalculatorServiceTest()
        {
            thirdPartyProviderMock = new Mock<IThirdPartyProvider>();
            thirdPartyProviderMock.Setup(x => x.GetExchangeRate(It.IsAny<ExchangeRateRequest>()))
                .Returns(Task.FromResult(new ExchangeRateResponse() { SourceCountry = "United States", DestinationCountry = "Turkey", ExchangeRate = 6.99887M, ExchangeRateToken = "ABCD"}));

            thirdPartyProviderMock.Setup(x => x.GetFees(It.IsAny<FeeRequest>()))
                .Returns(Task.FromResult(new FeeResponse[] { new FeeResponse() {Amount = 100, Fee = 10}, new FeeResponse() { Amount = 300, Fee = 15 } }));

            transactionCalculatorService = new TransactionCalculatorService(thirdPartyProviderMock.Object);
        }

        [Fact]
        public async Task GetExchangeRate_ShouldReturnValueFromThirdPartyService()
        {
            var result = await transactionCalculatorService.GetExchangeRate(new ExchangeRateRequest() { AccessKey = testAccessKey, From = "US", To = "TRY" });
            Assert.Equal("United States", result.SourceCountry);
            Assert.Equal("Turkey", result.DestinationCountry);
            Assert.Equal(6.999M, result.ExchangeRate);
            Assert.Equal("ABCD", result.ExchangeRateToken);
        }

        [Fact]
        public async Task GetFees_ShouldReturnValueFromThirdPartyService()
        {
            var result = await transactionCalculatorService.GetFees(new FeeRequest() { AccessKey = testAccessKey, From = "US", To = "TRY" });
            IList<FeeResponse> resultList = result as IList<FeeResponse>;
            Assert.Equal(100, resultList[0].Amount);
            Assert.Equal(10, resultList[0].Fee);

            Assert.Equal(300, resultList[1].Amount);
            Assert.Equal(15, resultList[1].Fee);
        }

    }
}