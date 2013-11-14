using System;
using System.Net;

namespace RacoWireless.SmsGateway.Core
{

    public class MoMessageReceiver
    {
        public string GetMessage()
        {
            string returnVal;

            var receiveEndpoint = Constants.MoEndpointUrl + string.Format(Constants.MoQueryString, Constants.PartnerId, Constants.WebServiceKey);
            using (var webClient = new WebClient())
            {
                returnVal = webClient.DownloadString(receiveEndpoint);
            }

            return returnVal;
        }

        public void PollMessages()
        {
            while (true)
            {
                var jsonData = GetMessage();
                if (!string.IsNullOrWhiteSpace(jsonData))
                {
                    Console.WriteLine("Received JSON Data: {0}", jsonData);
                }
                else
                {
                    Console.WriteLine("No messages available");
                }
            }
        }
    }
}
