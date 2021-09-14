using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Threading.Tasks;
using APIClientApp;
using APITestApp.PostcodesIOService;

namespace APITestApp.Services
{
    public class SinglePostcodeService
    {
        #region Properties
        public CallManager CallManager { get; set; }
        public JObject Json_Response { get; set; }
        // The response DTO
        public DTO<SinglePostcodeResponse> SinglePostcodeDTO { get; set; }
        // The postcode used in the API request
        public string PostcodeSelected { get; set; }
        public string PostcodeResponse { get; set; }

        #endregion
        // Constructor
        public SinglePostcodeService()
        {
            CallManager = new CallManager();
            SinglePostcodeDTO = new DTO<SinglePostcodeResponse>();
        }
        public async Task MakeRequest(string postcode)
        {
            PostcodeSelected = postcode;
            PostcodeResponse = await CallManager.MakePostcodeRequestAsync(postcode);
            Json_Response = JObject.Parse(PostcodeResponse);
            // Use DTO to convert JSON string into an object tree
            SinglePostcodeDTO.DeserializeResponse(PostcodeResponse);
        }
    }
}
