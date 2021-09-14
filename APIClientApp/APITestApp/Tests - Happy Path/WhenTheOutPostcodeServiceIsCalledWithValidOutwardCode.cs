//using NUnit.Framework;
//using APITestApp.Services;
//using System.Threading.Tasks;

//namespace APITestApp.Tests
//{
//    class WhenTheOutPostcodeServiceIsCalledWithValidOutwardCode
//    {
//        private OutPostcodeService _OutPostcodeService;
//        [OneTimeSetUp]
//        public void OneTimeSetup()
//        {
//            _OutPostcodeService = new OutPostcodeService();
//            _OutPostcodeService.MakeRequest("AL1");
//        }
//        [Test]
//        public void StatusIs200()
//        {
//            Assert.That(_OutPostcodeService.StatusCode, Is.EqualTo(200));
//        }
//        [Test]
//        public void OutcodeIsCorrect()
//        {
//            var result = _OutPostcodeService.ResponseObject.result.outcode;
//            Assert.That(result, Is.EqualTo("AL1"));
//        }
//    }
//}
