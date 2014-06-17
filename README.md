# RacoWireless SMS Gateway
==========

The RacoWireless SMS Gateway allows RacoWireless customers to send and receive SMS messages over a simple REST API.


## How to send MT Messages
MT Messages are submitted by posting a JSON Serialized Mt Message object to the web service endpoint.  Alternatively you may submit a GET request with the parameters in the URL.  As a slight deviation for restful web services, all requests (even invalid requests) will be responded with HTTP Status code 200 - and the output data will be a MtMessageResponse object.

POST https://sms.racowireless.com/send (this URL is not yet active and may change)
'''{
  "partnerId":551427,
  "webServiceKey":"A14CB2CB30224B1F56C16CJ527A248C7",
  "recipient":"15554442233",
  "message":"Hello World"
}///

NOTE: If your application requires transmitting characters that cannot be transmitted in XML without encoding (such as the ‘<’ character), you must use the https://sms.racowireless.com/sendEncoded method.  The sendEncoded method requires the message parameter to be Base64 encoded.  Otherwise the methodology is identical.

POST https://sms.racowireless.com/sendEncoded (this URL is not yet active and may change)
{
  "partnerId":551427,
  "webServiceKey":"A14CB2CB30224B1F56C16CJ527A248C7",
  "recipient":"15554442233",
  "message":"SGVsbG8gV29ybGQ="
}
How to receive MO Messages
To receive an MO Message, make a get request to the web service endpoint.  Your request will be held open until a message is available, or for {30} seconds (whichever comes first).  If you wish to receive messages as quickly as possible, your solution should ‘infinite loop’ this http request to get messages as soon as possible.

GET https://sms.racowireless.com/receive?partnerId={partnerId}&webServiceKey={wsk}
 (this URL is not yet active and may change)

MoMessage
{
  "messageId":38124587452, (64 bit integer)
  "sender":"15554442233",
  "receivedTimestamp":"2013-09-20 12:12:22Z",
  "message":"aGVsbG8gd29ybGQ="
}

MtMessageResponse
{
  "messageId":48124587452, (64 bit integer)
  "recipient":"15554442233",
  "message":"aGVsbG8gc2VydmVy",
  "acceptedTimestamp":"2013-09-20 12:12:22.501Z",
  "submittedToCarrierTimestamp":"2013-09-20 12:12:23.000Z",
  "carrierAcceptedTimestamp":"2013-09-20 12:12:23.900Z",
  "finalizedTimestamp":"2013-09-20 12:12:26.101Z",
  "messageStatus":4
}

NOTE: Timestamps are in UTC

NOTE: If your application requires transmitting characters that cannot be transmitted in XML without encoding (such as the ‘<’ character), you must use the https://sms.racowireless.com/receiveEncoded method.  The receiveEncoded method will Base64 encode the ‘message’ parameter.  Otherwise the methodology is identical.

MT Message Status Updates
Two types of objects will be available from https://sms.racowireless.com/receive - both MoMessage objects and MtMessageResponse objects.  As MtMessages are processed by RACO Wireless and the carrier, we will notify you by adding new MtMessageResponse objects to your queue.  The combination of timestamps not being null and the MessageStatus value will tell you the specific message status.  The only time more than one status may correspond to a given timestamp is the finalizedTimestamp.

All message deliveries must be acknowledged
To support a transactional workflow, messages must be acknowledged after they have been processed.  Messages may be acknowledged by making a get or post request to https://sms.racowireless.com/ack.  Each request requires 3 arguments that may be submitted in post data (json serialization) or included in the query string.

For example:
https://sms.racowireless.com/ack?partnerId={123}&webServiceKey={KEY}&messageId=98543

If messages are not acknowledged, they will be ready for consumption after 5 minutes.
Character Encoding
This section will describe what character set is available (is it UTF-7, UTF-8, or GSM 03.38)?
Valid XML Characters


Message Specifications
The Raco Wireless SMS Gateway can accept either XML or JSON encoded messages.
MtMessage
MtMessage is used to submit a request to send a mobile terminated (server to device) message.

MoMessage
MoMessage is used to send MoMessage data (device to server) to the customer.


MtMessageResponse
MtMessageResponse is used to acknowledge a MtMessage request, and also to provide status update information about previously submitted MtMessage objects.





MessageStatus
To message status is an enumeration that describes status of the message at the instant the data is transmitted.  Possible MessageStatus values are below:


Status
Name
Description
1
Accepted
RACO Wireless has accepted the message
2
InvalidCredential
Your credentials are invalid
3
InvalidRecipient
The MSISDN you are referencing is not in your account
4
SubmittedToCarrier
The message has been submitted to the carrier
5
InvalidMessageLength
The message submitted is too long (max 140 characters)
6
MessageAlreadyAck
The message has already been acknowledged
7
MessageDoesNotExist
The message requested does not exist
100
CarrierInvalidRecipient
The carrier returned an ‘Invalid Recipient’ message
101
CarrierAccepted
The carrier has accepted the message
102
CarrierScheduled
The carrier has scheduled the message for delivery
103
CarrierEnroute
The carrier has returned an Enroute status
104
CarrierDelivered
The message has been delivered
105
CarrierExpired
The message was not able to be delivered due to the message validity period expiring
106
CarrierDeleted
The carrier deleted the message (an unlikely status)
107
CarrierUndeliverable
The carrier could not deliver the message (an unlikely status)
108
CarrierUnknown
The carrier returned an unknown status (an unlikely status)
109
CarrierRejected
The carrier returned a rejected status (an unlikely status)
110
CarrierSkipped
The carrier returned a skipped status (an unlikely status)




Advanced Configurations (Coming Soon)
In a future release of the RACO SMS Gateway, partners will have some flexibility with regards to their gateway configuration.

Require MoMessage Acknowledgement
This option (by default) is true, however, if you do not wish to acknowledge MO messages, we can turn this off.

Deliver MT Status Update messages
If you do not wish to receive any MT Status Update messages, we can disable this feature.
FAQ
{This section is currently blank}
