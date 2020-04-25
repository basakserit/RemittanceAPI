using System.Diagnostics;
using RemittanceAPI.Helper;
using RemittanceAPI.V1.Models.Request;

namespace RemittanceAPI.Validators
{
    public class ExchangeRateValidator : IExchangeRateValidator
    {
        public void ValidateRequestModel(ExchangeRateRequest request)
        {

            if (request.From == null)
            {
                request.From = "US";
            }

            if (request.To == null)
            {
                Debug.WriteLine("to should be provided");
            }

            if (request.From.Length != 2)
            {
                Debug.WriteLine("from length is not 2");
            }


            if (request.To.Length != 2)
            {
                Debug.WriteLine("to length is not 2");
            }

        }
    }
}