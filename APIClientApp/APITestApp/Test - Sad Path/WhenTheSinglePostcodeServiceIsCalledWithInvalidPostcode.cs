using NUnit.Framework;
using APITestApp.Services;
using System.Threading.Tasks;

namespace APITestApp.Test___Sad_Path
{
    public class WhenTheSinglePostcodeServiceIsCalledWithInvalidPostcode
    {
        private SinglePostcodeService _singlePostcodeService;
        [OneTimeSetUp]
        public async Task OneTimeSetup()
        {
            _singlePostcodeService = new SinglePostcodeService();
            await _singlePostcodeService.MakeRequest("Bad Request");
        }
        [Test]
        public void StatusIs404()
        {
            Assert.That(_singlePostcodeService.StatusCode, Is.EqualTo(404));
        }
    }
}
