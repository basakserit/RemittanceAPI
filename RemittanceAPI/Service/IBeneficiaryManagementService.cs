using System.Collections.Generic;
using System.Threading.Tasks;
using RemittanceAPI.V1.Models.Request;
using RemittanceAPI.V1.Models.Response;

namespace RemittanceAPI.Service
{
    public interface IBeneficiaryManagementService
    {
        Task<BeneficiaryResponse> GetBeneficiaryName(BeneficiaryRequest beneficiaryRequest);
        Task<ICollection<CountryResponse>> GetCountries(string accessKey);
        Task<ICollection<StateResponse>> GetStateList(string accessKey);
        Task<ICollection<BankResponse>> GetBankList(BankRequest bankRequest);
    }
}