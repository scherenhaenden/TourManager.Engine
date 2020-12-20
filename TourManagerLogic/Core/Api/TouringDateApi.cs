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
    public class TouringDateApi
    {
        private readonly IUnityOfWork _unityOfWork;
        public TouringDateApi(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        
        
        public List<int> GetAllIds()
        {
            return _unityOfWork.TouringDates.GetAll().Select(x => x.Id).ToList();
        }
        
        public void Add(TouringDatesModel values)
        {
            var result = values.ToEntity();
            _unityOfWork.TouringDates.Add(result);
            _unityOfWork.Complete();
        }
        
        public List<TouringDatesModel> GetAllPagination()
        {
            return _unityOfWork.TouringDates.GetAll().ToDto().ToList();
        }
        
        public void Update(TouringDatesModel values)
        {
            var entity =_unityOfWork.TouringDates.GetById(values.Id);
            entity = values.ToEntity(entity);
            _unityOfWork.TouringDates.Update(entity);
            _unityOfWork.Complete();
        }
        
        public void Delete(int id)
        {
            var entity = _unityOfWork.TouringDates.SingleOrDefault(x => x.Id == id);
            _unityOfWork.TouringDates.Remove(entity);
            _unityOfWork.Complete();
        }
        
        
        public List<TouringDatesModel> Find(Expression<Func<TouringDate, bool>> predicate)
        {
            var contacts = _unityOfWork.TouringDates.Find(predicate);
            if (contacts == null)
            {
                return null;
            }
            return contacts.ToDto().ToList();
        }
    }
}