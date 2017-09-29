﻿using System.Collections.Generic;
using Newtonsoft.Json;
using Nexmo.Api.Request;
using System.Threading.Tasks;

namespace Nexmo.Api
{
    public static class NumberInsight
    {
        public enum CallerType
        {
            Unkown,
            Business, 
            Consumer
        }

        public enum PortedStatus
        {
            Ported,
            NotPorted,
            Unknown,
            AssumedPorted,
            AssumedNotPorted
        }

        public enum NumberValidity
        {
            Unkonwn,
            Valid,
            NotValid
        }

        public enum NumberReachability
        {
            Unknown,
            Reachable,
            Undeliverable,
            Absent,
            BadNumber,
            Blacklisted
        }

        public class NumberInsightBasicRequest
        {
            public string number { get; set; }
            public string Country { get; set; }
        }

        public class NumberInsightBasicResponse
        {
            /// <summary>
            /// 	The status code and a description about your request.
            /// </summary>
            public string status { get; set; }
            public string status_message { get; set; }
            /// <summary>
            /// The unique identifier for your request. This is a alphanumeric string up to 40 characters.
            /// </summary>
            public string request_id { get; set; }
            /// <summary>
            /// The number in your request in International format.
            /// </summary>
            public string international_format_number { get; set; }
            /// <summary>
            /// Looked up Number in format used by the country the number belongs to.
            /// </summary>
            public string national_format_number { get; set; }
            /// <summary>
            /// 	Two character country code for number. This is in ISO 3166-1 alpha-2 format.
            /// </summary>
            public string country_code { get; set; }
            /// <summary>
            /// Two character country code for number. This is in ISO 3166-1 alpha-3 format.
            /// </summary>
            public string country_code_iso3 { get; set; }
            /// <summary>
            /// The full name of the country that number is registered in.
            /// </summary>
            public string country_name { get; set; }
            /// <summary>
            /// The numeric prefix for the country that number is registered in.
            /// </summary>
            public string country_prefix { get; set; }
        }

        public class CarrierInfo
        {
            /// <summary>
            /// The MCCMNC for the carrier *number* is associated with.Unreal numbers are marked as 'unknown' and the request is rejected altogether if the number is impossible as per E.164 guidelines.
            /// </summary>
            public string network_code { get; set; }
            /// <summary>
            /// The full name of the carrier that *number* is associated with.
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// The country that *number* is associated with. This is in ISO 3166-1 alpha-2 format.
            /// </summary>
            public string country { get; set; }
            /// <summary>
            /// The type of network that *number* is associated with. For example mobile, landline, virtual, premium, toll-free.
            /// </summary>
            public string network_type { get; set; }
        }

        public class NumberInsightStandardResponse : NumberInsightBasicResponse
        {
            /// <summary>
            /// The amount in EUR charged to your account.
            /// </summary>
            public string request_price { get; set; }
            /// <summary>
            /// Your account balance in EUR after this request.
            /// </summary>
            public string remaining_balance { get; set; }
            /// <summary>
            /// Information about the network number is currently connected to.
            /// </summary>
            public CarrierInfo current_carrier { get; set; }
            /// <summary>
            /// Information about the network number was initially connected to
            /// </summary>
            public CarrierInfo original_carrier { get; set; }
            public string CallerName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public CallerType CallerType { get; set; }
            public PortedStatus PortedStatus { get; set; }
        }

        public class NumberInsightAdvancedRequest : NumberInsightBasicRequest
        {
            public bool Cnam { get; set; }
            public string IpAddress { get; set; }
            public string Callback { get; set; }
        }

        public class NumberInsightAdvancedResponse : NumberInsightStandardResponse
        {
            public string LookupOutcomeMessage { get; set; }
            public int LookupOutcome { get; set; }
            public NumberValidity NumberValidity { get; set; }
            public NumberReachability NumberReachability { get; set; }
            public RoamingInformation RoamingInformation { get; set; }
        }

        public class NumberInsightRequest
        {
            public string Number { get; set; }
            public string Callback { get; set; }
        }

        public class NumberInsightRequestResponse
        {
            public string request_id { get; set; }
            public string number { get; set; }
            public string status { get; set; }
            public string error_text { get; set; }
            public string remaining_balance { get; set; }
            public string request_price { get; set; }
        }

        public class NumberInsightResponse
        {
            public string request_id { get; set; }
            public string number { get; set; }
            public string status { get; set; }
            public string status_message { get; set; }
            public string number_type { get; set; }
            public string carrier_network_code { get; set; }
            public string carrier_network_name { get; set; }
            public string carrier_country_code { get; set; }
            public string valid { get; set; }
            public string ported { get; set; }
            public string reachable { get; set; }
            public string roaming { get; set; }
            public string roaming_country_code { get; set; }
            public string roaming_network_code { get; set; }
        }

        /// <summary>
        /// Performs basic semantic checks on given phone number.
        /// </summary>
        /// <param name="request">NI request</param>
        /// <param name="creds">(Optional) Overridden credentials for only this request</param>
        /// <returns></returns>
        public static NumberInsightBasicResponse RequestBasic(NumberInsightBasicRequest request, Credentials creds = null)
        {
            var response = ApiRequest.DoPostRequest(ApiRequest.GetBaseUriFor(typeof(NumberVerify), "/ni/basic/json"), request, creds);

            return JsonConvert.DeserializeObject<NumberInsightBasicResponse>(response.JsonResponse);
        }

        /// <summary>
        /// Identifies the phone number type and, for mobile phone numbers, the network it is registered with.
        /// </summary>
        /// <param name="request">NI request</param>
        /// <param name="creds">(Optional) Overridden credentials for only this request</param>
        /// <returns></returns>
        public static NumberInsightStandardResponse RequestStandard(NumberInsightBasicRequest request, Credentials creds = null)
        {
            var response = ApiRequest.DoPostRequest(ApiRequest.GetBaseUriFor(typeof(NumberVerify), "/ni/standard/json"), request, creds);

            return JsonConvert.DeserializeObject<NumberInsightStandardResponse>(response.JsonResponse);
        }

        public static NumberInsightAdvancedResponse RequestAdvanced( NumberInsightAdvancedRequest request, Credentials creds = null)
        {
            var response = ApiRequest.DoPostRequest(ApiRequest.GetBaseUriFor(typeof(NumberVerify), "/ni/advanced/json"), request, creds);

            return JsonConvert.DeserializeObject<NumberInsightAdvancedResponse>(response.JsonResponse);
        }

        //public static NumberInsightAdvancedResponse RequestAdvancedAsync(NumberInsightAdvancedRequest request, Credentials creds = null)
        //{
        //    var response = ApiRequest.DoPostRequest(ApiRequest.GetBaseUriFor(typeof(NumberVerify), "/ni/advanced/async/json"), request, creds);

        //    return JsonConvert.DeserializeObject<NumberInsightAdvancedResponse>(response.JsonResponse);
        //}

        /// <summary>
        /// Retrieve validity, roaming, and reachability information about a mobile phone number.
        /// </summary>
        /// <param name="request">NI advenced request</param>
        /// <param name="creds">(Optional) Overridden credentials for only this request</param>
        /// <returns></returns>
        public static NumberInsightRequestResponse Request(NumberInsightRequest request, Credentials creds = null)
        {
            var response = ApiRequest.DoPostRequest(ApiRequest.GetBaseUriFor(typeof(NumberInsight), "/ni/json"), new Dictionary<string, string>
            {
                {"number", request.Number},
                {"callback", request.Callback}
            },
            creds);

            return JsonConvert.DeserializeObject<NumberInsightRequestResponse>(response.JsonResponse);
        }

        /// <summary>
        /// Deserializes a NumberInsight response JSON string
        /// </summary>
        /// <param name="json">NumberInsight response JSON string</param>
        /// <returns></returns>
        public static NumberInsightResponse Response(string json)
        {
            return JsonConvert.DeserializeObject<NumberInsightResponse>(json);
        }
    }
}