using System.Linq;
using NUnit.Framework;
using TourManager.Data.Persistence;
using TourManagerLogic.Core.Api;
using TourManagerLogic.Core.Models;

namespace TourManagerEngineTests.Core.Api
{
    public class AddressApiTest
    {
        private IUnityOfWork _unityOfWork;
        private AddressModel _addressModel;

        [SetUp]
        public void Setup()
        {
            _unityOfWork = new ConfigurationApis().GetUnityConfigurated();
        }
        
        [Test]
        public void Test0_0DeleteEverything()
        {
            var addressApi = new AddressApi(_unityOfWork);

            var idsTobeDeleted = addressApi.GetAllIds();

            foreach (var id in idsTobeDeleted)
            {
                addressApi.Delete(id);
            }
        }
        
         [Test]
        public void Test1_1Add()
        {
            var address = new AddressModel
            {
                City = "Munich",
                Country = "Germany",
                Street = "Westend",
                ExtranInfo = "behind a bar",
                PostalZip = "1231312",
                HouseNameOrNumber = "199A"
            };
            

            
            var address2 = new AddressModel
            {
                City = "Mainz",
                Country = "Germany",
                Street = "Westend",
                ExtranInfo = "behind a bar",
                PostalZip = "1231312",
                HouseNameOrNumber = "123333"
            };

            _addressModel = address;

            var addressApi = new AddressApi(_unityOfWork);

            addressApi.Add(address);
            addressApi.Add(address2);

            var result1 =addressApi.Find(x => x.City == address.City).FirstOrDefault();
            var result2 =addressApi.Find(x => x.City == address2.City).FirstOrDefault();
            Assert.NotNull(result1);
            Assert.NotNull(result2);
            Assert.AreEqual(address.HouseNameOrNumber, address.HouseNameOrNumber);
            Assert.AreEqual(address2.HouseNameOrNumber, address2.HouseNameOrNumber);
        }
        
        [Test]
        public void Test3_1Update()
        {
            var addressApi = new AddressApi(_unityOfWork);
            
            _addressModel =addressApi.Find(x => x.City == _addressModel.City).FirstOrDefault();
            
            _addressModel.City = "Brandenburg";

            addressApi.Update(_addressModel);
            var result =addressApi.Find(x => x.City == _addressModel.City).FirstOrDefault();
            Assert.NotNull(result);
            Assert.AreEqual(result.City, _addressModel.City);
        }
        
        [Test]
        public void Test4_1DeleteEveythng()
        {
            Test0_0DeleteEverything();
        }

    }
}