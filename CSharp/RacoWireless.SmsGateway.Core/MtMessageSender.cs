using Newtonsoft.Json;
using RacoWireless.SmsGateway.Core.Dto;
using System.Net;

namespace RacoWireless.SmsGateway.Core
{
    public class MtMessageSender
    {
        public MtMessageResponse SendMessageViaGet(string recipient, string message)
        {
            MtMessageResponse returnVal;

            var getRequestUrl = Constants.MtEndpointUrl + string.Format(Constants.MtQueryString, Constants.PartnerId, Constants.WebServiceKey, recipient, message);

            using (var webClient = new WebClient())
            {
                var jsonString = webClient.DownloadString(getRequestUrl);
                returnVal = JsonConvert.DeserializeObject<MtMessageResponse>(jsonString);
            }

            return returnVal;
        }

        public MtMessageResponse SendMessageViaPost(string recipient, string message)
        {
            MtMessageResponse returnVal;

            var mtMessage = new MtMessage(Constants.PartnerId, Constants.WebServiceKey, recipient, message);

            using (var webClient = new WebClient())
            {
                webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                var jsonUploadData = JsonConvert.SerializeObject(mtMessage);
                var jsonString = webClient.UploadString(Constants.MtEndpointUrl, jsonUploadData);
                returnVal = JsonConvert.DeserializeObject<MtMessageResponse>(jsonString);
            }

            return returnVal;
        }
    }
}
