using TourManager.Data.Persistence;
using TourManagerLogic.Core.Mapping.ModelsToDto;
using TourManagerLogic.Core.Models;

namespace TourManagerLogic.Core.Api
{
    public class TelephoneNumberApi
    {
        private readonly IUnityOfWork _unityOfWork;
        public TelephoneNumberApi(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        
        public void Add(TelephoneNumberModel values)
        {
            var result = values.ToEntity();
            _unityOfWork.TelephoneNumbers.Add(result);
            _unityOfWork.Complete();
        }
        
        public void Update(TelephoneNumberModel values)
        {
            var entity =_unityOfWork.TelephoneNumbers.GetById(values.Id);
            entity = values.ToEntity(entity);
            _unityOfWork.TelephoneNumbers.Update(entity);
            _unityOfWork.Complete();
        }
        
        public TelephoneNumberModel GetById(int id)
        {
            var entity = _unityOfWork.TelephoneNumbers.SingleOrDefault(x => x.Id == id);
            return entity.ToDto();

        }
        
        public void Delete(int id)
        {
            var entity = _unityOfWork.TelephoneNumbers.SingleOrDefault(x => x.Id == id);
            _unityOfWork.TelephoneNumbers.Remove(entity);
            _unityOfWork.Complete();
        }
    }
}