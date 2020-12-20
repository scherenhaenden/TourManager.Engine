using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using TourManager.Data.Core.Domain;
using TourManager.Data.Persistence;
using TourManagerLogic.Core.Mapping.ModelsToDto;
using TourManagerLogic.Core.Models;

namespace TourManagerLogic.Core.Api
{
    public class BandsApi
    {
        private readonly IUnityOfWork _unityOfWork;
        public BandsApi(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        
        
        public void Add(BandModel values)
        {
            var result = values.ToEntity();
            _unityOfWork.Bands.Add(result);
            _unityOfWork.Complete();
        }
        
        public List<BandModel> GetAllPagination()
        {
            return _unityOfWork.Bands.GetAll().ToDto().ToList();
        }
        
        public void Update(BandModel values)
        {
            var entity =_unityOfWork.Bands.GetById(values.Id);
            entity = values.ToEntity(entity);
            _unityOfWork.Bands.Update(entity);
            _unityOfWork.Complete();
        }
        
        public List<int> GetAllIds()
        {
            return _unityOfWork.Bands.GetAll().Select(x => x.Id).ToList();
        }

        public void Delete(int id)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();
            
            
            var entity = _unityOfWork.Bands.SingleOrDefault(x => x.Id == id);
            new EmailApi(_unityOfWork).Remove(entity.Emails.ToDto());
            var contacsApi = new ContacsApi(_unityOfWork);
            contacsApi.RemoveRange(entity.Members.ToDto().ToList());
            
            contacsApi.Remove(entity.Manager.ToDto());

            _unityOfWork.Bands.Remove(entity);
            _unityOfWork.Complete();
            
            sw.Stop();

            var time = sw.ElapsedMilliseconds;

        }
        
        
        public List<BandModel> Find(Expression<Func<Band, bool>> predicate)
        {
            var contacts = _unityOfWork.Bands.Find(predicate);
            if (contacts == null)
            {
                return null;
            }
            return contacts.ToDto().ToList();
        }
    }
}