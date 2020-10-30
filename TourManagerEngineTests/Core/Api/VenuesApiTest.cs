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
        public void TestAdd()
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
            contactsModel.TelefonNumbers.Add(new TelefonNumberModel() {Number = "+555 3343" });
            contactsModel.Emails.Add(new EmailModel() {EmailAddress = "amazing@gmail.com"});
            contactsModel.Addresses.Add(address);
            
            
            VenueModel venueModel = new VenueModel();

            venueModel.Name = "LaTaguarita";
            EmailModel emailModel = new EmailModel();
            emailModel.EmailAddress = "taguara@taguara.net";
            
            venueModel.Emails.Add(emailModel);
            venueModel.TelefonNumbers.Add(new TelefonNumberModel() {Number = "+225 334323" });
            venueModel.Contact.Add(contactsModel);

            venueModel.MaxCapacity = 1500;
            venueModel.Notes ="many notes";
            venuesApi.Add(venueModel);
                
                
            
            
            
            var result =venuesApi.Find(x => x.Name == venueModel.Name);
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

    }
}