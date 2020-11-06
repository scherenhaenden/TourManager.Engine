using TourManager.Data.Persistence;
using TourManagerLogic.Core.Mapping.ModelsToDto;
using TourManagerLogic.Core.Models;

namespace TourManagerEngineTests.Core.Api
{
    public class TouringDateApi
    {
        private readonly IUnityOfWork _unityOfWork;
        public TouringDateApi(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        
        public void Add(TouringDatesModel values)
        {
            var result = values.ToEntity();
            _unityOfWork.TouringDates.Add(result);
            _unityOfWork.Complete();
        }
        
        public void Update(TouringDatesModel values)
        {
            var entity =_unityOfWork.TouringDates.GetById(values.Id);
            entity = values.ToEntity(entity);
            _unityOfWork.TouringDates.Update(entity);
            _unityOfWork.Complete();
        }
        
        public TouringDatesModel GetById(int id)
        {
            var entity = _unityOfWork.TouringDates.SingleOrDefault(x => x.Id == id);
            return entity.ToDto();

        }
        
        public void Delete(int id)
        {
            var entity = _unityOfWork.TouringDates.SingleOrDefault(x => x.Id == id);
            _unityOfWork.TouringDates.Remove(entity);
            _unityOfWork.Complete();
        }
    }
}