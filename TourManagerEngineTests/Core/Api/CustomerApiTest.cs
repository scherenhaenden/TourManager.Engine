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
    public class CustomerApiTest
    {

        private IUnityOfWork _unityOfWork;
        private ContactModel _contactModel;        

        [SetUp]
        public void Setup()
        {   
            DbContextOptionsBuilder<TourManagerContext> options = new DbContextOptionsBuilder<TourManagerContext>();
            options.UseLazyLoadingProxies();
            //options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            
            DbContextOptions options2 = new DbContextOptions<TourManagerContext>();
            options.UseSqlite($"Data Source=./TourManager.db");
            TourManagerContext tourManagerContext = new TourManagerContext(options.Options);
            _unityOfWork = new UnityOfWork(tourManagerContext);
            //_contacsApi = new ContacsApi(_unityOfWork);            
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
            var customersApi = new ContacsApi(_unityOfWork);

            _contactModel = new ContactModel();
            _contactModel.FirstName = "Eddie test";
            _contactModel.LastName = "FrankenStein";
            _contactModel.TelefonNumbers.Add(new TelefonNumberModel() {Number = "+555 Contact" });
            _contactModel.Emails.Add(new EmailModel() {EmailAddress = "contacttest@gmail.com"});
            _contactModel.Addresses.Add(address);
            customersApi.Add(_contactModel);
            var result =customersApi.Find(x => x.FirstName == _contactModel.FirstName && x.LastName == _contactModel.LastName);
            Assert.NotNull(result);
        }
        
        [Test]
        public void Test2SelectById()
        {
            var customersApi = new ContacsApi(_unityOfWork);

            var result = customersApi.Find(x => x.FirstName == "Eddie test").FirstOrDefault();
            var id = result.Id;
            var selectedOne = customersApi.SelectBy(result.Id);
            Assert.AreEqual(id, selectedOne.Id);
        }
        
        [Test]
        public void Test2_1SelectByIdLoadEmails()
        {
            var customersApi =new ContacsApi(_unityOfWork);

            var result = customersApi.Find(x => x.FirstName == "Eddie test").FirstOrDefault();
            var id = result.Id;
            var selectedOne = customersApi.SelectByLoadEmails(result.Id);
            Assert.AreEqual(_contactModel.Emails.ToList()[0].EmailAddress, selectedOne.Emails.ToList()[0].EmailAddress);
        }
        
        [Test]
        public void Test2_2SelectByIdLoadTelefonNumbers()
        {
            var customersApi =new ContacsApi(_unityOfWork);

            var result = customersApi.Find(x => x.FirstName == "Eddie test").FirstOrDefault();
            var id = result.Id;
            var selectedOne = customersApi.SelectByLoadTelefonNumbers(result.Id);
            Assert.AreEqual(_contactModel.TelefonNumbers.ToList()[0].Number, selectedOne.TelefonNumbers.ToList()[0].Number);
        }
        
        [Test]
        public void Test2_3SelectByIdLoadAddresses()
        {
            var customersApi =new ContacsApi(_unityOfWork);

            var result = customersApi.Find(x => x.FirstName == "Eddie test").FirstOrDefault();
            var id = result.Id;
            var selectedOne = customersApi.SelectByLoadAddresses(result.Id);
            Assert.AreEqual(_contactModel.Addresses.ToList()[0].City, selectedOne.Addresses.ToList()[0].City);
        }
        
        
        [Test]
        public void Test3Find()
        {

            var customersApi =new ContacsApi(_unityOfWork);

            var result =customersApi.Find(x => x.FirstName == _contactModel.FirstName && x.LastName == _contactModel.LastName);
            Assert.Greater(result.Count, 0);
        }

        [Test]
        public void Test3_1FindWithDependenvies()
        {

            var customersApi =new ContacsApi(_unityOfWork);
            var result =customersApi.Find(x => x.FirstName == _contactModel.FirstName && x.LastName == _contactModel.LastName);
            Assert.Greater(result.Count, 0);
        }

        [Test]
        public void Test4_1Update()
        {
            var customersApi =new ContacsApi(_unityOfWork);
            var result =customersApi.Find(x => x.FirstName == _contactModel.FirstName && x.LastName == _contactModel.LastName)[0];

            if (result != null)
            {
                _contactModel = result;
                _contactModel.FirstName = "Eddie Gerald";
            }
            
            var address = new AddressModel
            {
                City = "Frankfurt",
                Country = "Germany",
                Street = "somestrees",
                ExtranInfo = "behind a bar",
                PostalZip = "1231312",
                HouseNameOrNumber = "199A"
            };

            var email = new EmailModel() {EmailAddress = "contact-secondmail@gmail.com"};
            var telefon = new TelefonNumberModel() {Number = "+555 Contact + 2"};
            
            _contactModel.Emails.Add(email);
            _contactModel.TelefonNumbers.Add(telefon);
            _contactModel.Addresses.Add(address);
            customersApi.Update(_contactModel);
            
            var updatedResult =customersApi.SelectBy(_contactModel.Id);
            Assert.AreEqual(updatedResult.FirstName,  _contactModel.FirstName);


            var resultEmail =updatedResult.Emails.FirstOrDefault(x => x.EmailAddress == email.EmailAddress);
            var resultTelefon =updatedResult.TelefonNumbers.FirstOrDefault(x => x.Number == telefon.Number);
            var resultAddress =updatedResult.Addresses.FirstOrDefault(x => x.City == address.City);

            Assert.NotNull(resultEmail);
            Assert.NotNull(resultTelefon);
            Assert.NotNull(resultAddress);
        }
        
        [Test]
        public void Test5Delete()
        {
            var customersApi =new ContacsApi(_unityOfWork);

            var result =customersApi.Find(x => x.FirstName == _contactModel.FirstName && x.LastName == _contactModel.LastName);

            foreach (var VARIABLE in result)
            {
                customersApi.Delete(VARIABLE.Id);
            }
            
            result =customersApi.Find(x => x.FirstName == _contactModel.FirstName && x.LastName == _contactModel.LastName);
           
            Assert.AreEqual(result.Count, 0);
        }
        
        
        [Test]
        public void Test5DeleteAll()
        {
            var customersApi =new ContacsApi(_unityOfWork);

            var result = customersApi.GetAllPagination();
            
          
            customersApi.DeleteRange(result);
            
            result = customersApi.GetAllPagination();
           
            
            
            Assert.AreEqual(result.Count, 0);
        }
    }
}