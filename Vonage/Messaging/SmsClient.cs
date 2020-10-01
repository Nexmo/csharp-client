using Vonage.Request;

namespace Vonage.Messaging
{
    public class SmsClient : ISmsClient
    {
        public Credentials Credentials { get; set; }

        public SmsClient(Credentials creds = null)
        {
            Credentials = creds;
        }

        /// <summary>
        /// Send a SMS message.
        /// </summary>
        /// <param name="request">The SMS message request</param>
        /// <param name="creds">(Optional) Overridden credentials for only this request</param>
        /// <exception cref="VonageSmsResponseException">Thrown when the status of a message is non-zero or response is empty</exception>
        /// <returns></returns>
        public SendSmsResponse SendAnSms(SendSmsRequest request, Credentials creds = null)
        {
            var result = ApiRequest.DoPostRequestUrlContentFromObject<SendSmsResponse>(
                ApiRequest.GetBaseUri(ApiRequest.UriType.Rest, "/sms/json"),
                request,
                creds ?? Credentials
            );

            ValidSmsResponse(result);
            return result;
        }

        private static void ValidSmsResponse(SendSmsResponse smsResponse)
        {
            if(smsResponse?.Messages == null)
            {
                throw new VonageSmsResponseException("Encountered an Empty SMS response");
            }
            else if (smsResponse.Messages[0].Status != "0")
            {
                throw new VonageSmsResponseException($"SMS Request Failed with status: {smsResponse.Messages[0].Status} and error message: {smsResponse.Messages[0].ErrorText}") { Response = smsResponse};
            }
        }

        SendSmsResponse ISmsClient.SendAsSms(string to, string from, string text, SmsType smsType, Credentials credentials)
        {
            var result = ApiRequest.DoPostRequestUrlContentFromObject<SendSmsResponse>(
                ApiRequest.GetBaseUri(ApiRequest.UriType.Rest, "sms/json"),
                credentials ?? Credentials
            );

            return result;
        }
    }
}