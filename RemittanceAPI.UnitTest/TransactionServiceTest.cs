using System;
using System.Threading.Tasks;
using Moq;
using RemittanceAPI.Entity;
using RemittanceAPI.Provider;
using RemittanceAPI.Repository;
using RemittanceAPI.Service;
using RemittanceAPI.V1.Models.Request;
using RemittanceAPI.V1.Models.Response;
using Xunit;

namespace RemittanceAPI.UnitTest
{
    public class TransactionServiceTest
    {
        private TransactionService transactionService;
        private Mock<IThirdPartyProvider> thirdPartyProviderMock;
        private Mock<ITransactionRepository> transactionRepositoryMock;
        private string testAccessKey = "accessKey";

        public TransactionServiceTest()
        {
            thirdPartyProviderMock = new Mock<IThirdPartyProvider>();
            transactionRepositoryMock = new Mock<ITransactionRepository>();

            thirdPartyProviderMock.Setup(x => x.SubmitTransaction(It.IsAny<TransactionRequest>()))
                .Returns(Task.FromResult(new SubmitTransactionResponse() { TransactionStatus = TransactionStatus.Pending, TransactionId = Guid.Parse("767319b8-fe00-49b5-bf14-2c6c368a11ea") }));

            transactionRepositoryMock.Setup(x => x.Add(It.IsAny<Transaction>()))
                .Returns(new Transaction()
                {
                    Id = 1,
                    TransactionId = Guid.Parse("767319b8-fe00-49b5-bf14-2c6c368a11ea"),
                    TransactionStatus = TransactionStatus.Pending
                });

            thirdPartyProviderMock.Setup(x => x.GetTransactionStatus(It.IsAny<StatusRequest>()))
                .Returns(Task.FromResult(new StatusResponse()
                {
                    TransactionStatus = TransactionStatus.Pending, 
                    TransactionId = Guid.Parse("767319b8-fe00-49b5-bf14-2c6c368a11ea")
                }));
            transactionRepositoryMock.Setup(x => x.Get(Guid.Parse("767319b8-fe00-49b5-bf14-2c6c368a11ea")))
                .Returns(new Transaction()
                {
                    Id = 1,
                    TransactionId = Guid.Parse("767319b8-fe00-49b5-bf14-2c6c368a11ea"),
                    TransactionStatus = TransactionStatus.Pending
                });

            transactionService = new TransactionService(thirdPartyProviderMock.Object, transactionRepositoryMock.Object);
        }

        [Fact]
        public async Task SubmitTransactionStatus_ShouldReturnValueFromThirdPartyService()
        {
            var result = await transactionService.SubmitTransaction(new TransactionRequest()
            {
                AccessKey = testAccessKey,
                DateOfBirth = "1993-09-09",
                Fees = (decimal) 1.23,
                ExchangeRate = (decimal)0.2,
                FromAmount = (decimal)100,
                FromCurrency = "USD",
                SendFromState = "TX",
                SenderAddress = "My address",
                SenderCity = "Dallas",
                SenderCountry = "US",
                SenderEmail = "abc@mail.com",
                SenderFirstName = "Basak",
                SenderLastName = "Serit",
                SenderPhone = "+906787677676",
                SenderPostalCode = "43FRFR",
                ToBankAccountName = "Bank account",
                ToBankAccountNumber = "3423432434234",
                ToBankCode = "SDB34",
                ToBankName = "US Bank",
                ToCountry = "SE",
                ToFirstName = "Test name",
                ToLastName = "Surname",
                TransactionNumber = "2323434323432432"
            });

            Assert.Equal("767319b8-fe00-49b5-bf14-2c6c368a11ea", result);
        }

        [Fact]
        public async Task GetTransactionStatus_ShouldReturnValueFromThirdPartyService()
        {
            var result = await transactionService.GetTransactionStatus(new StatusRequest() 
                { AccessKey = testAccessKey, TransactionId = Guid.Parse("767319b8-fe00-49b5-bf14-2c6c368a11ea") });
            
            Assert.Equal(TransactionStatus.Pending, result.TransactionStatus);
            Assert.Equal(Guid.Parse("767319b8-fe00-49b5-bf14-2c6c368a11ea"), result.TransactionId);
        }

    }
}