//using NUnit.Framework;
//using APITestApp.Services;
//using System.Threading.Tasks;

//namespace APITestApp.Tests
//{
//    public class WhenTheBulkPostcodeServiceIsCalledWithValidPostCodes
//    {
//        private BulkPostcodeService _bulkPostcodeService;
//        [OneTimeSetUp]
//        public void OneTimeSetup()
//        {
//            _bulkPostcodeService = new BulkPostcodeService();
//            _bulkPostcodeService.MakeRequest(new string[] { "OX49 5NU", "M32 OJG", "NE30 1DP" });
//        }
//        [Test]
//        public void StatusIs200()
//        {
//            Assert.That(_bulkPostcodeService.ResponseContent["status"].ToString(), Is.EqualTo("200"));
//        }
//        [Test]
//        public void PostcodesAreCorrect()
//        {
//            var result = _bulkPostcodeService.ResponseContent;
//            string[] expected = new string[] { "OX49 5NU", "M32 OJG", "NE30 1DP" };
//            for (int i = 0; i < 3; i++)
//            {
//                Assert.That(result["result"][i]["query"].ToString(), Is.EqualTo(expected[i]));
//            }
//        }
//    }
//}
