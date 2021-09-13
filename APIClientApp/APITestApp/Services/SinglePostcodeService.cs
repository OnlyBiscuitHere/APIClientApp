using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Threading.Tasks;
using APIClientApp;

namespace APITestApp.Services
{
    public class SinglePostcodeService
    {
        #region Properties
        // Create RestSharp object which handles communication with api
        public RestClient Client;
        // A newtonsoft object representing the json response
        public JObject ResponseContent { get; set; }
        // The postcode being used in this API request
        public string PostcodeSelected { get; set; }
        // Store the status code
        public int StatusCode { get; set; }
        public SinglePostcodeResponse ResponseObject { get; set; }
        #endregion
        // Constructor
        public SinglePostcodeService()
        {
            Client = new RestClient {BaseUrl = new Uri(AppConfigReader.BaseUrl) };
        }
        public async Task MakeRequest(string postcode)
        {
            // Setup the request
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            PostcodeSelected = postcode;
            // Define the request resource path
            request.Resource = $"postcodes/{postcode.ToLower().Replace(" ", "")}";
            // Make the request
            IRestResponse response = await Client.ExecuteAsync(request);
            // Parse JSON in response content
            ResponseContent = JObject.Parse(response.Content);

            // Capture status code
            StatusCode = (int)response.StatusCode;

            ResponseObject = JsonConvert.DeserializeObject<SinglePostcodeResponse>(response.Content);
        }
    }
}
