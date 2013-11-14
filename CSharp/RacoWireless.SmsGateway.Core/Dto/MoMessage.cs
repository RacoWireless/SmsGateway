using System;

namespace RacoWireless.SmsGateway.Core.Dto
{
    public class MoMessage
    {
        public int MoMessageId { get; set; }
        public string Sender { get; set; }
        public string Message { get; set; }
        public DateTime ReceivedTimeStamp { get; set; }
    }
}
