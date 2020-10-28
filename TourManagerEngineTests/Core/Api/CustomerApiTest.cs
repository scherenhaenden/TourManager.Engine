using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;
using NUnit.Framework;
using TourManager.Data.Core.Configuration;
using TourManagerLogic.ApiModels;
using TourManagerLogic.Core.Api;

namespace TourManagerEngineTests.Core.Api
{
    public class CustomerApiTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            
            
            
            DbContextOptionsBuilder<TourManagerContext> options = new DbContextOptionsBuilder<TourManagerContext>();
            options.UseLazyLoadingProxies();
            
            DbContextOptions options2 = new DbContextOptions<TourManagerContext>();
            options.UseSqlite($"Data Source=./TourManager.db");
            TourManagerContext tourManagerContext = new TourManagerContext(options.Options);
            CustomersApi customersApi = new CustomersApi(tourManagerContext); 
            
            ContactsModel contactsModel = new ContactsModel();

            contactsModel.FirstName = "Eddie";
            contactsModel.LastName = "FrankenStein";
            contactsModel.TelefonNumber = "+555 3343";
            contactsModel.Email = "amazing@gmail.com";
            contactsModel.Address = "SomeWhereBetweenNowhereAndFantasia";
            
            customersApi.Add(contactsModel);
            
            
            
            
            
            
            
                
            
            
            Assert.Pass();
        }
    }
}