using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using TourManager.Data.Core.Configuration;
using TourManager.Data.Persistence;
using TourManagerLogic.Core.Api;
using TourManagerLogic.Core.Models;

namespace TourManagerEngineTests.Core.Api
{
    public class EmailsApiTest
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
        public void Test1_Add()
        {
            var emailApi = new EmailApi(_unityOfWork);
            EmailModel emailModel = new EmailModel();
            emailModel.EmailAddress = "emailtest@taguara.net";
            emailApi.Add(emailModel);

            var result =emailApi.Find(x => x.EmailAddress == emailModel.EmailAddress);
            Assert.NotNull(result);
        }
        
        [Test]
        public void Test2_1SelectById()
        {
            var emailApi = new EmailApi(_unityOfWork);
            EmailModel emailModel = new EmailModel();
            emailModel.EmailAddress = "emailtest@taguara.net";
            var result = emailApi.Find(x => x.EmailAddress == emailModel.EmailAddress)[0];
            Assert.NotNull(result);
        }

        [Test]
        public void Test2_2SelectById()
        {
            var emailApi = new EmailApi(_unityOfWork);
            EmailModel emailModel = new EmailModel();
            emailModel.EmailAddress = "emailtest@taguara.net";
            var result = emailApi.Find(x => x.EmailAddress == emailModel.EmailAddress)[0];
            var result1 = emailApi.SelectBy(result.Id);
            Assert.AreEqual(result.Id, result1.Id);
        }
        
        [Test]
        public void Test3_1Update()
        {
            var emailApi = new EmailApi(_unityOfWork);
            EmailModel emailModel = new EmailModel();
            emailModel.EmailAddress = "emailtest@taguara.net";
            var result = emailApi.Find(x => x.EmailAddress == emailModel.EmailAddress)[0];
            var result1 = emailApi.SelectBy(result.Id);
            result1.EmailAddress = "emailtest-testupdated@taguara.net";
            emailApi.Update(result1);
            Assert.AreEqual(result.Id, result1.Id);
        }
        
        [Test]
        public void Test4_1Delete()
        {
            var emailApi = new EmailApi(_unityOfWork);
            EmailModel emailModel = new EmailModel();
            emailModel.EmailAddress = "emailtest-testupdated@taguara.net";
            var result = emailApi.Find(x => x.EmailAddress == emailModel.EmailAddress)[0];
            var result1 = emailApi.SelectBy(result.Id);
            
            emailApi.Remove(result1);
            
            var result2 = emailApi.SelectBy(result.Id);
            
            Assert.IsNull(result2);
        }
    }
}