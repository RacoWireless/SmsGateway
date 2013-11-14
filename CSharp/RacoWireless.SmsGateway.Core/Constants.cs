
namespace RacoWireless.SmsGateway.Core
{
    public class Constants
    {
        public const int PartnerId = -1;
        public const string WebServiceKey = "WSK";
        public const string MtEndpointUrl = "https://smstest.racowireless.com/send";
        public const string MtQueryString = "?partnerId={0}&webServiceKey={1}&recipient={2}&message={3}";

        public const string MoEndpointUrl = "https://smstest.racowireless.com/receive";
        public const string MoQueryString = "?partnerId={0}&webServiceKey={1}";
    }
}
