using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using TourManager.Data.Core.Configuration;
using TourManager.Data.Persistence;
using TourManagerLogic.Core.Api;
using TourManagerLogic.Core.Models;

namespace TourManagerEngineTests.Core.Api
{
    public class VenuesContactsApiTest

    {
        private IUnityOfWork _unityOfWork;
        
        VenuesToContactsModel _venuesToContactsModel = new VenuesToContactsModel();
        VenuesToContactsModel _venuesToContactsModel2 = new VenuesToContactsModel();
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
            var venuesContactApi = new VenuesContactApi(_unityOfWork);
            var contactsModel = new ContactModel();
            contactsModel.FirstName = "Eddie";
            contactsModel.LastName = "FrankenStein";
            contactsModel.TelephoneNumbers.Add(new TelephoneNumberModel() {Number = "+555 Venue" });
            contactsModel.Emails.Add(new EmailModel() {EmailAddress = "venuewstest@gmail.com"});
            contactsModel.Addresses.Add(address);
            
            var contactsModel2 = new ContactModel();
            contactsModel2.FirstName = "pofetti";
            contactsModel2.LastName = "ninuu";
            contactsModel2.TelephoneNumbers.Add(new TelephoneNumberModel() {Number = "+222 Venue" });
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
            
            
            VenueModel venueModel = new VenueModel();
            
            venueModel.Addresses.Add(addressw);

            venueModel.Name = "LaTaguarita";
            EmailModel emailModel = new EmailModel();
            emailModel.EmailAddress = "venuestest@taguara.net";
            
            venueModel.Emails.Add(emailModel);
            venueModel.TelephoneNumbers.Add(new TelephoneNumberModel() {Number = "+225 Venue" });
           

            venueModel.MaxCapacity = 1500;
            venueModel.Notes ="many notes";
         
            

            _venuesToContactsModel = new VenuesToContactsModel();
            _venuesToContactsModel2 = new VenuesToContactsModel();

            _venuesToContactsModel.Venue = venueModel;
            _venuesToContactsModel.Contact = contactsModel2;
            
            _venuesToContactsModel2.Venue = venueModel;
            _venuesToContactsModel2.Contact = contactsModel;

            venuesContactApi.Add(_venuesToContactsModel);
          
            venuesContactApi.Add(_venuesToContactsModel2);

            Assert.NotNull("result");
        }

        [Test]
        public void Test2_0Find()
        {
            var venuesContactApi = new VenuesContactApi(_unityOfWork);

            var firstName = _venuesToContactsModel.Contact.FirstName;
            var venueName = _venuesToContactsModel.Venue.Name;
            var result =venuesContactApi.Find(x => x.Contact.FirstName == firstName &&  x.Venue.Name == venueName);
            
            Assert.Greater(result.Count, 0);

        }
        
        
         
        [Test]
        public void Test3_1Update()
        {

            var venuesContactApi = new VenuesContactApi(_unityOfWork);
            _venuesToContactsModel =venuesContactApi.Find(X => X.Venue.Name == _venuesToContactsModel.Venue.Name).FirstOrDefault();
            _venuesToContactsModel.Venue.MaxCapacity = 8900;
            
            venuesContactApi.Update(_venuesToContactsModel);

            var result =venuesContactApi.Find(X => X.Venue.Name == _venuesToContactsModel.Venue.Name).FirstOrDefault();
            
            Assert.AreEqual(result.Venue.MaxCapacity, _venuesToContactsModel.Venue.MaxCapacity);
        }

    }
}