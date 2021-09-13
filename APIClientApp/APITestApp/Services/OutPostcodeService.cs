using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using APIClientApp;

namespace APITestApp.Services
{
    class OutPostcodeService
    {
        public RestClient Client;
        public JObject ResponseContent { get; set; }
        public string OutwardCode { get; set; }
        public int StatusCode { get; set; }
        public OutCodeResponse ResponseObject { get; set; }
        public OutPostcodeService()
        {
            Client = new RestClient { BaseUrl = new Uri(AppConfigReader.BaseUrl) };
        }
        public void MakeRequest(string outcode)
        {
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.Resource = $"/outcodes/{outcode}";
            OutwardCode = outcode;
            IRestResponse response = Client.Execute(request);
            ResponseContent = JObject.Parse(response.Content);
            StatusCode = (int)response.StatusCode;
            ResponseObject = JsonConvert.DeserializeObject<OutCodeResponse>(response.Content);
        }
    }
}
