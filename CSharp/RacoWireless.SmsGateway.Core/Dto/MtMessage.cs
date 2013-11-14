
namespace RacoWireless.SmsGateway.Core.Dto
{
    public class MtMessage
    {
        public int PartnerId { get; set; }
        public string WebServiceKey { get; set; }
        public string Recipient { get; set; }
        public string Message { get; set; }

        public MtMessage()
        {
            
        }

        public MtMessage(int partnerId, string webServiceKey, string recipient, string message)
        {
            PartnerId = partnerId;
            WebServiceKey = webServiceKey;
            Recipient = recipient;
            Message = message;
        }
    }
}
