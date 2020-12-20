using TourManager.Data.Persistence;
using TourManagerLogic.Core.Mapping.ModelsToDto;
using TourManagerLogic.Core.Models;

namespace TourManagerLogic.Core.Api
{
    public class TourApi
    {
        private readonly IUnityOfWork _unityOfWork;
        public TourApi(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        
        public void Add(TourModel values)
        {
            var result = values.ToEntity();
            _unityOfWork.Tours.Add(result);
            _unityOfWork.Complete();
        }
        
        public void Update(TourModel values)
        {
            var entity =_unityOfWork.Tours.GetById(values.Id);
            entity = values.ToEntity(entity);
            _unityOfWork.Tours.Update(entity);
            _unityOfWork.Complete();
        }
        
        public TourModel GetById(int id)
        {
            var entity = _unityOfWork.Tours.SingleOrDefault(x => x.Id == id);
            return entity.ToDto();

        }
        
        public void Delete(int id)
        {
            var entity = _unityOfWork.Tours.SingleOrDefault(x => x.Id == id);
            _unityOfWork.Tours.Remove(entity);
            _unityOfWork.Complete();
        }
    }
}