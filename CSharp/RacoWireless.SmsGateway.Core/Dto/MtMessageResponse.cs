using System;

namespace RacoWireless.SmsGateway.Core.Dto
{
    public class MtMessageResponse
    {
        public int MessageId { get; set; }
        public string Recipient { get; set; }
        public string Message { get; set; }
        public DateTime AcceptedTimeStamp { get; set; }
        public DateTime SubmittedToCarrierTimeStamp { get; set; }
        public DateTime CarrierAcceptedTimeStamp { get; set; }
        public DateTime FinalizedTimeStamp { get; set; }
        public MessageStatus Status { get; set; }
    }
}
