using TourManager.Data.Persistence;
using TourManagerLogic.Core.Mapping.ModelsToDto;
using TourManagerLogic.Core.Models;

namespace TourManagerEngineTests.Core.Api
{
    public class TelefonNumberApi
    {
        private readonly IUnityOfWork _unityOfWork;
        public TelefonNumberApi(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        
        public void Add(TelefonNumberModel values)
        {
            var result = values.ToEntity();
            _unityOfWork.TelefonNumbers.Add(result);
            _unityOfWork.Complete();
        }
        
        public void Update(TelefonNumberModel values)
        {
            var entity =_unityOfWork.TelefonNumbers.GetById(values.Id);
            entity = values.ToEntity(entity);
            _unityOfWork.TelefonNumbers.Update(entity);
            _unityOfWork.Complete();
        }
        
        public TelefonNumberModel GetById(int id)
        {
            var entity = _unityOfWork.TelefonNumbers.SingleOrDefault(x => x.Id == id);
            return entity.ToDto();

        }
        
        public void Delete(int id)
        {
            var entity = _unityOfWork.TelefonNumbers.SingleOrDefault(x => x.Id == id);
            _unityOfWork.TelefonNumbers.Remove(entity);
            _unityOfWork.Complete();
        }
    }
}