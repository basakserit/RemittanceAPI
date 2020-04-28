using System.Collections.Generic;
using System.Threading.Tasks;
using RemittanceAPI.Provider;
using RemittanceAPI.V1.Models.Request;
using RemittanceAPI.V1.Models.Response;

namespace RemittanceAPI.Service
{
    public class BeneficiaryManagementService : IBeneficiaryManagementService
    {
        private readonly IThirdPartyProvider _thirdPartyProvider;

        public BeneficiaryManagementService(IThirdPartyProvider thirdPartyProvider)
        {
            _thirdPartyProvider = thirdPartyProvider;
        }

        public async Task<BeneficiaryResponse> GetBeneficiaryName(BeneficiaryRequest beneficiaryRequest)
        {
            return await _thirdPartyProvider.GetBeneficiaryName(beneficiaryRequest);
        }

        public async Task<ICollection<CountryResponse>> GetCountries(string accessKey)
        {
            return await _thirdPartyProvider.GetCountries(accessKey);
        }

        public async Task<ICollection<StateResponse>> GetStateList(string accessKey)
        {
            return await _thirdPartyProvider.GetStates(accessKey);
        }

        public async Task<ICollection<BankResponse>> GetBankList(BankRequest bankRequest)
        {
            return await _thirdPartyProvider.GetBanks(bankRequest);
        }

    }
}