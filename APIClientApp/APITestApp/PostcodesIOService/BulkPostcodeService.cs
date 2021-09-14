//using System;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using RestSharp;
//using System.Threading.Tasks;
//using APIClientApp;

//namespace APITestApp.Services
//{
//    public class BulkPostcodeService
//    {
//        public RestClient Client;
//        public JObject ResponseContent { get; set; }
//        public string[] PostcodeSelected { get; set; }
//        public int StatusCode { get; set; }
//        public BulkPostcodeResponse ResponseObject { get; set; }
//        public BulkPostcodeService()
//        {
//            Client = new RestClient { BaseUrl = new Uri(AppConfigReader.BaseUrl + "/postcodes/") };
//        }
//        public void MakeRequest(string[] postcodes)
//        {
//            var request = new RestRequest(Method.POST);
//            request.AddHeader("Content-Type", "application/json");
//            PostcodeSelected = postcodes;
//            JObject objPostcodes = new JObject 
//            { 
//                new JProperty("postcodes", new JArray(postcodes)) 
//            };
//            request.AddParameter("application/json", objPostcodes.ToString(), ParameterType.RequestBody);
//            IRestResponse response = Client.Execute(request);
//            ResponseContent = JObject.Parse(response.Content);
//            StatusCode = (int)response.StatusCode;
//            ResponseObject = JsonConvert.DeserializeObject<BulkPostcodeResponse>(response.Content);
//        }
//    }
//}
