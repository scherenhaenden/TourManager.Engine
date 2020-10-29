using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;
using NUnit.Framework;
using TourManager.Data.Core.Configuration;
using TourManager.Data.Persistence;
using TourManagerLogic.Core.Api;
using TourManagerLogic.Core.Models;

namespace TourManagerEngineTests.Core.Api
{
    public class CustomerApiTest
    {

        private IUnityOfWork _unityOfWork;
        private ContactsModel contactsModel;
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
        public void Test1Add()
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
            contactsModel = new ContactsModel();
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
        public void Test2SelectById()
        {

            var customersApi = new CustomersApi(_unityOfWork);
            var result =customersApi.GetAllPagination()[0];
            var id = result.Id;
            var selectedOne = customersApi.SelectBy(result.Id);
            Assert.AreEqual(id, selectedOne.Id);
        }
        
        
        [Test]
        public void Test3Find()
        {
            var customersApi = new CustomersApi(_unityOfWork);
            var result =customersApi.Find(x => x.FirstName == contactsModel.FirstName && x.LastName == contactsModel.LastName);
            Assert.Greater(result.Count, 0);
        }
        
        [Test]
        public void Test4Delete()
        {
            var customersApi = new CustomersApi(_unityOfWork);
            var result =customersApi.Find(x => x.FirstName == contactsModel.FirstName && x.LastName == contactsModel.LastName);

            foreach (var VARIABLE in result)
            {
                customersApi.Delete(VARIABLE.Id);
            }
            
            result =customersApi.Find(x => x.FirstName == contactsModel.FirstName && x.LastName == contactsModel.LastName);
           
            Assert.AreEqual(result.Count, 0);
        }
    }
}