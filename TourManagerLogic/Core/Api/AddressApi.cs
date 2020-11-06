
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TourManager.Data.Core.Domain;
using TourManager.Data.Persistence;
using TourManagerLogic.Core.Mapping.ModelsToDto;
using TourManagerLogic.Core.Models;

namespace TourManagerLogic.Core.Api
{
    public class AddressApi
    {
        private readonly IUnityOfWork _unityOfWork;
        public AddressApi(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        
        public List<int> GetAllIds()
        {
            return _unityOfWork.Bands.GetAll().Select(x => x.Id).ToList();
        }
        
        public void Add(AddressModel values)
        {
            var result = values.ToEntity();
            _unityOfWork.Address.Add(result);
            _unityOfWork.Complete();
        }
        
        public List<AddressModel> Find(Expression<Func<Address, bool>> predicate)
        {
            var contacts = _unityOfWork.Address.Find(predicate);
            if (contacts == null)
            {
                return null;
            }
            return contacts.ToDto().ToList();
        }
        
        public void Update(AddressModel values)
        {
            var entity =_unityOfWork.Address.GetById(values.Id);
            entity = values.ToEntity(entity);
            _unityOfWork.Address.Update(entity);
            _unityOfWork.Complete();
        }
        
        public AddressModel GetById(int id)
        {
            var entity = _unityOfWork.Address.SingleOrDefault(x => x.Id == id);
            return entity.ToDto();

        }
        
        public void Delete(int id)
        {
            var entity = _unityOfWork.Address.SingleOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return;
            }

            _unityOfWork.Address.Remove(entity);
            _unityOfWork.Complete();
        }
    }
}