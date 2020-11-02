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
        private ContacsApi _contacsApi;
        [SetUp]
        public void Setup()
        {   
            
            var servCollection = new ServiceCollection();
            
            servCollection.AddDbContext<TourManagerContext>
            (
                x =>
                {
                    x.UseSqlite($"Data Source=./TourManager.db");
                    x.UseLazyLoadingProxies();

                });
            servCollection.AddScoped<IUnityOfWork, UnityOfWork>();
            
            servCollection.AddAutoMapper(( cfg) =>
            {
                cfg.AddCollectionMappers();
                cfg.UseEntityFrameworkCoreModel<TourManagerContext>(servCollection);
            });
            
           
               
            var iMapperConfiguration = new MapperConfiguration(cfg => {
                cfg.AddCollectionMappers();
                cfg.AddCollectionMappers();
                cfg.UseEntityFrameworkCoreModel<TourManagerContext>(servCollection);
                //cfg.UseEntityFrameworkCoreModel<GenerateEntityFrameworkCorePrimaryKeyPropertyMaps<TourManagerContext>>(null);
            });
            
         
            
            DbContextOptionsBuilder<TourManagerContext> options = new DbContextOptionsBuilder<TourManagerContext>();
            options.UseLazyLoadingProxies();
            //options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            
            DbContextOptions options2 = new DbContextOptions<TourManagerContext>();
            options.UseSqlite($"Data Source=./TourManager.db");
            TourManagerContext tourManagerContext = new TourManagerContext(options.Options);
            _unityOfWork = new UnityOfWork(tourManagerContext);

            _contacsApi = new ContacsApi(_unityOfWork, iMapperConfiguration);
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
            var customersApi = _contacsApi;//new ContacsApi(_unityOfWork);
            _contactModel = new ContactModel();
            _contactModel.FirstName = "Eddie";
            _contactModel.LastName = "FrankenStein";
            _contactModel.TelefonNumbers.Add(new TelefonNumberModel() {Number = "+555 3343" });
            _contactModel.Emails.Add(new EmailModel() {EmailAddress = "amazing@gmail.com"});
            _contactModel.Addresses.Add(address);
            customersApi.Add(_contactModel);
            var result =customersApi.Find(x => x.FirstName == _contactModel.FirstName && x.LastName == _contactModel.LastName);
            Assert.NotNull(result);
        }
        
        [Test]
        public void Test2SelectById()
        {

            var customersApi = _contacsApi;//new ContacsApi(_unityOfWork);
            var result =customersApi.GetAllPagination()[0];
            var id = result.Id;
            var selectedOne = customersApi.SelectBy(result.Id);
            Assert.AreEqual(id, selectedOne.Id);
        }
        
        
        [Test]
        public void Test3Find()
        {
            var customersApi = _contacsApi;//new ContacsApi(_unityOfWork);
            var result =customersApi.Find(x => x.FirstName == _contactModel.FirstName && x.LastName == _contactModel.LastName);
            Assert.Greater(result.Count, 0);
        }
        
        [Test]
        public void Test3_1FindWithDependenvies()
        {
            var customersApi = _contacsApi;//new ContacsApi(_unityOfWork);
            var result =customersApi.Find(x => x.FirstName == _contactModel.FirstName && x.LastName == _contactModel.LastName);
            Assert.Greater(result.Count, 0);
        }
        
        
        
         
        [Test]
        public void Test4_1Update()
        {
            var customersApi = _contacsApi;//new ContacsApi(_unityOfWork);
            var result =customersApi.Find(x => x.FirstName == _contactModel.FirstName && x.LastName == _contactModel.LastName)[0];

            if (result != null)
            {
                _contactModel = result;
                _contactModel.FirstName = "Eddie Gerald";
            }
            
            customersApi.Update(_contactModel);
            
            var updatedResult =customersApi.SelectBy(_contactModel.Id);
            
            






                Assert.AreEqual(updatedResult.FirstName,  _contactModel.FirstName);
        }
        
        [Test]
        public void Test5Delete()
        {
            var customersApi = _contacsApi;//new ContacsApi(_unityOfWork);
            var result =customersApi.Find(x => x.FirstName == _contactModel.FirstName && x.LastName == _contactModel.LastName);

            foreach (var VARIABLE in result)
            {
                customersApi.Delete(VARIABLE.Id);
            }
            
            result =customersApi.Find(x => x.FirstName == _contactModel.FirstName && x.LastName == _contactModel.LastName);
           
            Assert.AreEqual(result.Count, 0);
        }
    }
}