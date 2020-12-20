using System;
using NUnit.Framework;
using TourManager.Data.Persistence;
using TourManagerLogic.Core.Api;
using TourManagerLogic.Core.Models;

namespace TourManagerEngineTests.Core.Api
{
    public class TouringDateApiTest
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
            var addressApi = new TouringDateApi(_unityOfWork);

            var idsTobeDeleted = addressApi.GetAllIds();

            foreach (var id in idsTobeDeleted)
            {
                addressApi.Delete(id);
            }
        }

        [Test]
        public void Test1_1Add()
        {
            
            var _bandModel = new BandModel();
            _bandModel.Name = "Korn";
            
            
            var address4 = new AddressModel
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
            _contactModel.Addresses.Add(address4);


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
            
            
            VenueModel venueModel = new VenueModel();
            
            venueModel.Addresses.Add(addressw);

            venueModel.Name = "LaTaguarita";
            EmailModel emailModel = new EmailModel();
            emailModel.EmailAddress = "venuestest@taguara.net";
            
            venueModel.Emails.Add(emailModel);
            venueModel.TelefonNumbers.Add(new TelefonNumberModel() {Number = "+225 Venue" });
           

            venueModel.MaxCapacity = 1500;
            venueModel.Notes ="many notes";
            
            
            TouringDatesModel touringDatesModel = new TouringDatesModel();

            touringDatesModel.Band = _bandModel;
            touringDatesModel.Venue = venueModel;
            
            touringDatesModel.DateOfTour = DateTime.Today;

            var touringDateApi = new TouringDateApi(_unityOfWork);
            
            touringDateApi.Add(touringDatesModel);

            var result =touringDateApi.Find(x => x.Band.Name == _bandModel.Name);
            
            Assert.Greater(result.Count, 0);


        }



        [Test]
        public void Test4_1Delete()
        {
            Test0_0DeleteEverything();
        }
    }
}