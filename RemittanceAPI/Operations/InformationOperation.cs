using RemittanceAPI.V1.Models.Request;
using RemittanceAPI.V1.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using RemittanceAPI.Provider;

namespace RemittanceAPI.Operations
{
    public class InformationOperation : IInformationOperation
    {
        private readonly IThirdPartyProvider _thirdPartyProvider;
        public InformationOperation(IThirdPartyProvider thirdPartyProvider)
        {
            _thirdPartyProvider = thirdPartyProvider;
        }
        public async Task<IEnumerable<BankResponse>> GetBankList(BankRequest bankRequest)
        {
            // DB works...
            //var response = _iBankDao.getAllBanksByCountry(countryId);

            // var banks = new BankResponse[3]; ;
            // var b1 = new BankResponse { Code = "TX", Name = "Texas Bank" };
            // var b2 = new BankResponse { Code = "NY", Name = "NY Bank" };
            // var b3 = new BankResponse { Code = "AK", Name = "Alsk Bank" };
            // banks[0] = b1;
            // banks[1] = b2;
            // banks[2] = b3;
            // return banks;
            return await _thirdPartyProvider.GetBanks(bankRequest);
        }

        public async Task<IEnumerable<Country>> GetCountryList()
        {
            // DB works...
            //var response = _iCountryDao.getAllCountries();

            // var countries = new Country[3]; ;
            // var c1 = new Country { Code = "US", Name = "America" };
            // var c2 = new Country { Code = "SE", Name = "Sweden" };
            // var c3 = new Country { Code = "TR", Name = "Turkey" };
            // countries[0] = c1;
            // countries[1] = c2;
            // countries[2] = c3;
            // return countries;
            return await _thirdPartyProvider.GetCountries("accessKey");
        }

        public async Task<IEnumerable<FeeResponse>> GetFees(FeeRequest feeRequest)
        {
            // from & to validations for request model 
            // _iFeeValidator.ValidateRequestModel(feeRequest);
            //
            //if(isValidModel)
            // string from = feeRequest.From;
            // string to = feeRequest.To;

            // DB works...
            //var response = _iFeeDAO.getFeesByFromAndTo(from, to);

            // var fees = new FeeResponse[3]; ;
            // var f1 = new FeeResponse { Amount = 100, Fee = 0 };
            // var f2 = new FeeResponse { Amount = 200, Fee = 2 };
            // var f3 = new FeeResponse { Amount = 500, Fee = 6 };
            // fees[0] = f1;
            // fees[1] = f2;
            // fees[2] = f3;
            // return fees;
            return await _thirdPartyProvider.GetFees(feeRequest);
        }

        public async Task<IEnumerable<StateResponse>> GetStateList()
        {
            // DB works...
            //var response = _iStateDao.getAllStates();

            // var states = new State[3]; ;
            // var s1 = new State { Code = "TX", Name = "Texas" };
            // var s2 = new State { Code = "NY", Name = "New York" };
            // var s3 = new State { Code = "AK", Name = "Alaska" };
            // states[0] = s1;
            // states[1] = s2;
            // states[2] = s3;
            //
            // return states;

            return await _thirdPartyProvider.GetStates("accessKey");
        }
    }
}