using System.Linq;
using AutoMapper;
using AutoMapper.EntityFrameworkCore;
using AutoMapper.EquivalencyExpression;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.DependencyInjection;

using NUnit.Framework;
using TourManager.Data.Core.Configuration;
using TourManager.Data.Persistence;
using TourManagerLogic.Core.Api;
using TourManagerLogic.Core.Models;

namespace TourManagerEngineTests.Core.Api
{
    public class BandApiTest
    {
        private IUnityOfWork _unityOfWork;
        private BandModel _bandModel;

        [SetUp]
        public void Setup()
        {
            _unityOfWork = new ConfigurationApis().GetUnityConfigurated();
        }

        [Test]
        public void Test0_0DeleteEverything()
        {
            var bandsApi = new BandsApi(_unityOfWork);

            var idsTobeDeleted = bandsApi.GetAllIds();

            foreach (var id in idsTobeDeleted)
            {
                bandsApi.Delete(id);
            }
        }

        [Test]
        public void Test1_1Add()
        {

            _bandModel = new BandModel();
            _bandModel.Name = "Korn";
            
            
            var address = new AddressModel
            {
                City = "Munich",
                Country = "Germany",
                Street = "Westend",
                ExtranInfo = "behind a bar",
                PostalZip = "1231312",
                HouseNameOrNumber = "199A"
            };
            

            var _contactModel = new ContactModel();
            _contactModel.FirstName = "Eddie test";
            _contactModel.LastName = "FrankenStein";
            _contactModel.TelefonNumbers.Add(new TelefonNumberModel() {Number = "+555 Contact" });
            _contactModel.Emails.Add(new EmailModel() {EmailAddress = "contacttest@gmail.com"});
            _contactModel.Addresses.Add(address);


            _bandModel.Manager = _contactModel;
            
                 
            var address2 = new AddressModel
            {
                City = "Mainz",
                Country = "Germany",
                Street = "Westend",
                ExtranInfo = "behind a bar",
                PostalZip = "1231312",
                HouseNameOrNumber = "199A"
            };
            

            var _contactModel2 = new ContactModel();
            _contactModel2.FirstName = "non Eddie test";
            _contactModel2.LastName = "FrankenStein";
            _contactModel2.TelefonNumbers.Add(new TelefonNumberModel() {Number = "+555 Contact" });
            _contactModel2.Emails.Add(new EmailModel() {EmailAddress = "contacttest@gmail.com"});
            _contactModel2.Addresses.Add(address2);
            
            _bandModel.Members.Add(_contactModel2);

            _bandModel.Style = "Rock";
            
            var address3 = new AddressModel
            {
                City = "Frankfurt",
                Country = "Germany",
                Street = "Westend",
                ExtranInfo = "behind a bar",
                PostalZip = "1231312",
                HouseNameOrNumber = "199A"
            };
            _bandModel.Address = address3;
            var bandsApi = new BandsApi(_unityOfWork);
            bandsApi.Add(_bandModel);
            var result =bandsApi.Find(x => x.Name == _bandModel.Name).FirstOrDefault();
            Assert.NotNull(result);
            Assert.AreEqual(result.Name, _bandModel.Name);
        }
        
        [Test]
        public void Test2_1Find()
        {
            var bandsApi = new BandsApi(_unityOfWork);
            
            var result =bandsApi.Find(x => x.Name == _bandModel.Name).FirstOrDefault();
            
            Assert.NotNull(result);
            Assert.AreEqual(result.Name, _bandModel.Name);
        }
        
        [Test]
        public void Test3_1Update()
        {
            var bandsApi = new BandsApi(_unityOfWork);
            
            _bandModel =bandsApi.Find(x => x.Name == _bandModel.Name).FirstOrDefault();
            
            _bandModel.Name = "Limpbizkit";

            _bandModel.Address.City = "Passau";
           
            bandsApi.Update(_bandModel);
            var result =bandsApi.Find(x => x.Name == _bandModel.Name).FirstOrDefault();
            Assert.NotNull(result);
            Assert.AreEqual(result.Name, _bandModel.Name);
        }
        
        [Test]
        public void Test4_1DeleteEveythng()
        {
            Test0_0DeleteEverything();
        }
    }
}