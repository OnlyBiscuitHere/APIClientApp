using NUnit.Framework;
using APITestApp.Services;
using System.Threading.Tasks;

namespace APITestApp.Tests
{
    public class WhenTheSinglePostcodeServiceIsCalledWithValidPostCode
    {
        private SinglePostcodeService _singlePostcodeService;
        [OneTimeSetUp]
        public async Task OneTimeSetup()
        {
            _singlePostcodeService = new SinglePostcodeService();
            await _singlePostcodeService.MakeRequest("EC2Y 5AS");
        }
        [Test]
        public void StatusIs200()
        {
            Assert.That(_singlePostcodeService.Json_Response["status"].ToString(), Is.EqualTo("200"));
        }
        [Test]
        public void StatusIs200_Alt()
        {
            Assert.That(_singlePostcodeService.CallManager.StatusCode, Is.EqualTo(200));
        }
        [Test]
        public void CorrectPostCodeIsReturned()
        {
            var result = _singlePostcodeService.Json_Response["result"]["postcode"].ToString();
            Assert.That(result, Is.EqualTo("EC2Y 5AS"));
        }
        [Test]
        public void ObjectStatusIs200()
        {
            var result = _singlePostcodeService.SinglePostcodeDTO.Response.status;
            Assert.That(result, Is.EqualTo(200));
        }
        [Test]
        public void AdminDistrict_IsCityOfLondon()
        {
            Assert.That(_singlePostcodeService.SinglePostcodeDTO.Response.result.admin_district, Is.EqualTo("City of London"));
        }
    }
}
