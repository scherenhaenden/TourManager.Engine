using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;
using NUnit.Framework;
using TourManager.Data.Core.Configuration;
using TourManager.Data.Persistence;
using TourManagerLogic.ApiModels;
using TourManagerLogic.Core.Api;

namespace TourManagerEngineTests.Core.Api
{
    public class CustomerApiTest
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
            var customersApi = new CustomersApi(_unityOfWork);
            var contactsModel = new ContactsModel();
            contactsModel.FirstName = "Eddie";
            contactsModel.LastName = "FrankenStein";
            contactsModel.TelefonNumbers.Add(new TelefonNumberModel() {Number = "+555 3343" });
            contactsModel.Emails.Add(new EmailModel() {EmailAddress = "amazing@gmail.com"});
            contactsModel.Addresses.Add(address);
            customersApi.Add(contactsModel);
            var result =customersApi.Find(x => x.FirstName == contactsModel.FirstName && x.LastName == contactsModel.LastName);
            Assert.NotNull(result);
        }
        
        [Test]
        public void TestSelectById()
        {

            var customersApi = new CustomersApi(_unityOfWork);
            var result =customersApi.GetAllPagination()[0];
            var id = result.Id;
            var selectedOne = customersApi.SelectBy(result.Id);
            Assert.AreEqual(id, selectedOne.Id);
        }
    }
}