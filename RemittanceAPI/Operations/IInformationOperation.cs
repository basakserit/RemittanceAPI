using System.Collections.Generic;
using System.Threading.Tasks;
using RemittanceAPI.V1.Models.Request;
using RemittanceAPI.V1.Models.Response;

namespace RemittanceAPI.Operations
{
    public interface IInformationOperation
    {
        public Task<IEnumerable<Country>> GetCountryList();

        public Task<IEnumerable<FeeResponse>> GetFees(FeeRequest request);

        public Task<IEnumerable<StateResponse>> GetStateList();

        public Task<IEnumerable<BankResponse>> GetBankList(BankRequest request);
    }
}