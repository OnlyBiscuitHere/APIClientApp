using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Linq;

namespace APIClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //// Client Property whihc is equal to a new 'RestSharp'. We are going to creata Uri Objects which encapsulates 
            //var restClient = new RestClient(@"https://api.postcodes.io/");
            //// Set up the request
            //var restRequest = new RestRequest();
            //// Set method
            //restRequest.Method = Method.GET;
            //restRequest.AddHeader("Content-Type", "application/json");
            //restRequest.Timeout = -1;
            //var postcode = "EC2Y 5AS";
            //// Define reqest resource path
            //restRequest.Resource = $"postcodes/{postcode.ToLower().Replace(" ", "")}";
            //// Execute
            //var singlePostcodeResponse = restClient.Execute(restRequest);
            ////Console.WriteLine($"Response content: \n{singlePostcodeResponse.Content}");
            ////Set up Bulkcode request
            //var client = new RestClient("https://api.postcodes.io/postcodes/");
            //client.Timeout = -1;
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Content-Type", "application/json");
            //JObject postcodes = new JObject
            //{
            //    new JProperty("postcodes", new JArray(new string[] {"OX49 5NU", "M32 OJG", "NE30 1DP" }))
            //};
            //request.AddParameter("application/json", postcodes.ToString(), ParameterType.RequestBody);
            ////Or
            //request.AddJsonBody(postcodes.ToString());
            //IRestResponse bulkPostcodeResponse = client.Execute(request);
            ////Console.WriteLine(bulkPostcodeResponse.Content);
            ////Console.WriteLine($"Status code:  { bulkPostcodeResponse.StatusCode}");
            ////Console.WriteLine($"Status code:  { (int)bulkPostcodeResponse.StatusCode}");


            ////var course = new JObject
            ////{
            ////    new JProperty("name", "eng91"),
            ////    new JProperty("trainees", new JArray(new string[] {"Ringo", "Paul", "George", "John" })),
            ////    new JProperty("total", 4)
            ////};

            //// Query our response as a JObject
            //var bulkJsonResponse = JObject.Parse(bulkPostcodeResponse.Content);
            //var singleJsonResponse = JObject.Parse(singlePostcodeResponse.Content);
            ////Console.WriteLine(singleJsonResponse["status"]);
            ////Console.WriteLine(singleJsonResponse["result"]["country"]);
            ////Console.WriteLine(singleJsonResponse["result"]["codes"]["parish"]);
            ////Console.WriteLine(bulkJsonResponse["result"][1]["result"]["country"]);

            ////Query our response as a C# object
            //var singlePostcode = JsonConvert.DeserializeObject<SinglePostcodeResponse>(singlePostcodeResponse.Content);
            //var bulkPostcode = JsonConvert.DeserializeObject<BulkPostcodeResponse>(bulkPostcodeResponse.Content);

            //console.writeline(singlepostcode.result.country);
            //console.writeline(singlepostcode.result.codes.admin_county);

            //foreach (var result in bulkPostcode.result)
            //{
            //    Console.WriteLine(result.query);
            //    //Console.WriteLine(result.postcode.region);
            //}
            //var result2 = bulkPostcode.result.Where(p => p.query == "OX49 5NU").Select(p => p.postcode.parish).FirstOrDefault();

            RestClient outClient = new RestClient(@"https://api.postcodes.io/outcodes/AL1");
            outClient.Timeout = -1;
            RestRequest outRequest = new RestRequest(Method.GET);
            IRestResponse outResponse = outClient.Execute(outRequest);

            var outDetails = JsonConvert.DeserializeObject<OutCodeResponse>(outResponse.Content);

            Console.WriteLine(outDetails.status);
            foreach (var parish in outDetails.result.parish)
            {
                Console.WriteLine(parish);
            }
            bool result = outDetails.result.admin_ward.Where(o => o.Contains("Colney")).Select(o => o.Contains("Colney")).FirstOrDefault();
            Console.WriteLine(result);
        }
    }
}
