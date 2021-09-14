using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace APITestApp.PostcodesIOService
{
    public class CallManager
    {
        // Restsharp Object which handles comms with the API
        private readonly IRestClient _Client;
        // Capture status
        public int StatusCode { get; set; }
        public CallManager()
        {
            _Client = new RestClient(AppConfigReader.BaseUrl);
        }
        /// <summary>
        ///  define and makes the PAI request and stores the response
        /// </summary>
        /// <param name = "postcode"></param>
        public async Task<string> MakePostcodeRequestAsync(string postcode)
        {
            // Setup the request
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            // Define the request resource path
            request.Resource = $"postcodes/{postcode.ToLower().Replace(" ", "")}";
            // Make the request
            IRestResponse response = await _Client.ExecuteAsync(request);
            StatusCode = (int)response.StatusCode;
            return response.Content;
        }
    }
}
