using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using TourManager.Data.Core.Configuration;
using TourManager.Data.Persistence;
using TourManagerLogic.Core.Api;
using TourManagerLogic.Core.Models;

namespace TourManagerEngineTests.Core.Api
{
    public class VenuesApiTest
    {
        private IUnityOfWork _unityOfWork;
        private VenueModel _venueModel;
        [SetUp]
        public void Setup()
        {   
            DbContextOptionsBuilder<TourManagerContext> options = new DbContextOptionsBuilder<TourManagerContext>();
            options.UseLazyLoadingProxies();
            
            DbContextOptions options2 = new DbContextOptions<TourManagerContext>();
            options.UseSqlite($"Data Source=./TourManager.db");
            TourManagerContext tourManagerContext = new TourManagerContext(options.Options);
            _unityOfWork = new UnityOfWork(tourManagerContext);
        }


        [Test]
        public void Test0_0Delete()
        {
            var venuesApi = new VenuesApi(_unityOfWork);

            var idsTobeDeleted = venuesApi.GetAllIds();

            foreach (var id in idsTobeDeleted)
            {
                venuesApi.Delete(id);
            }
        }

        [Test]
        public void Test1_0Add()
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
            var venuesApi = new VenuesApi(_unityOfWork);
            var contactsModel = new ContactModel();
            contactsModel.FirstName = "Eddie";
            contactsModel.LastName = "FrankenStein";
            contactsModel.TelefonNumbers.Add(new TelefonNumberModel() {Number = "+555 Venue" });
            contactsModel.Emails.Add(new EmailModel() {EmailAddress = "venuewstest@gmail.com"});
            contactsModel.Addresses.Add(address);
            
            var contactsModel2 = new ContactModel();
            contactsModel2.FirstName = "pofetti";
            contactsModel2.LastName = "ninuu";
            contactsModel2.TelefonNumbers.Add(new TelefonNumberModel() {Number = "+222 Venue" });
            contactsModel2.Emails.Add(new EmailModel() {EmailAddress = "venuewstest@venue.com"});
            contactsModel2.Addresses.Add(address);

            var addressw = new AddressModel
            {
                City = "Frankfurt",
                Country = "Germany",
                Street = "Westend",
                ExtranInfo = "behind a bar",
                PostalZip = "1231312",
                HouseNameOrNumber = "199A"
            };          
            
            _venueModel = new VenueModel();
            
            
            
            _venueModel.Addresses.Add(addressw);

            _venueModel.Name = "LaTaguarita";
            EmailModel emailModel = new EmailModel();
            emailModel.EmailAddress = "venuestest@taguara.net";
            
            _venueModel.Emails.Add(emailModel);
            _venueModel.TelefonNumbers.Add(new TelefonNumberModel() {Number = "+225 Venue" });
           

            _venueModel.MaxCapacity = 1500;
            _venueModel.Notes ="many notes";
         
            

            var venuesToContactsModel = new VenuesToContactsModel();
            var venuesToContactsModel2 = new VenuesToContactsModel();

            venuesToContactsModel.Venue = _venueModel;
            venuesToContactsModel.Contact = contactsModel2;
            
            venuesToContactsModel2.Venue = _venueModel;
            venuesToContactsModel2.Contact = contactsModel;
            
            
            _venueModel.VenuesToContacts.Add(venuesToContactsModel2);
            _venueModel.VenuesToContacts.Add(venuesToContactsModel2);
            
            venuesApi.Add(_venueModel);

            var result =venuesApi.Find(x => x.Name == _venueModel.Name);
            Assert.NotNull(result);
        }
        
        [Test]
        public void TestSelectById()
        {

            var venuesApi = new VenuesApi(_unityOfWork);
            var result =venuesApi.GetAllPagination()[0];
            var id = result.Id;
            var selectedOne = venuesApi.SelectBy(result.Id);
            Assert.AreEqual(id, selectedOne.Id);
        }
        
        [Test]
        public void Test3_1Update()
        {

            var venuesApi = new VenuesApi(_unityOfWork);
            _venueModel =venuesApi.Find(X => X.MaxCapacity == _venueModel.MaxCapacity).FirstOrDefault();
            _venueModel.MaxCapacity = 3000;
            
            venuesApi.Update(_venueModel);

            var result =venuesApi.Find(X => X.MaxCapacity == _venueModel.MaxCapacity).FirstOrDefault();
            
            Assert.AreEqual(result.MaxCapacity, _venueModel.MaxCapacity);
        }

    }
}