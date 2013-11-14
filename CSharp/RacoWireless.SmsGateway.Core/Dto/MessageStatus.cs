
namespace RacoWireless.SmsGateway.Core.Dto
{
    public enum MessageStatus
    {
        Accepted = 1,
        InvalidCredential = 2,
        InvalidRecipient = 3,
        SubmittedToCarrier = 4,
        CarrierInvalidRecipient = 100,
        CarrierAccepted = 101,
        CarrierScheduled = 102,
        CarrierEnroute = 103,
        CarrierDelivered = 104,
        CarrierExpired = 105,
        CarrierDeleted = 106,
        CarrierUndeliverable = 107,
        CarrierUnknown = 108,
        CarrierRejected = 109,
        CarrierSkipped = 110
    }
}
