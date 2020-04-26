using System;

namespace RemittanceAPI.Exceptions
{
    public class ThirdPartyException : Exception
    {
        public ThirdPartyException(string error) : base(error)
        {

        }
    }

    public class ThirdPartyProviderErrorMessage
    {
        public string Error { get; set; }
    }
}