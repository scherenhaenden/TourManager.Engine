using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TourManager.Data.Core.Domain;
using TourManager.Data.Persistence;
using TourManager.Data.Persistence.Repositories;
using TourManagerLogic.Core.Mapping.ModelsToDto;
using TourManagerLogic.Core.Models;

namespace TourManagerLogic.Core.Api
{
    public class VenuesContactApi
    {
        private readonly IUnityOfWork _unityOfWork;

        public VenuesContactApi(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        
        
        
        public void Add(VenuesToContactsModel values)
        {
            var result =values.ToEntity();
            _unityOfWork.VenuesToContacts.Add(result);
            _unityOfWork.Complete();
        }
        
        
        public List<VenuesToContactsModel> Find(Expression<Func<VenuesToContacts, bool>> predicate)
        {
            var contacts = _unityOfWork.VenuesToContacts.Find(predicate);
            return contacts.ToDto().ToList();
        }
        
        public void Delete(int id)
        {
            var entity = _unityOfWork.VenuesToContacts.SingleOrDefault(x => x.Id == id);
            _unityOfWork.VenuesToContacts.Remove(entity);
            _unityOfWork.Complete();
        }
        
        
       /* public List<VenuesToContactsModel> Find(Func<VenuesToContacts, bool> predicate)
        {


            var result = _unityOfWork.VenuesToContacts.IncludeMmeL(
                c => c.Contact,
                l => l.Venue
            ).ToList().Where(predicate);


            //var contacts = _unityOfWork.VenuesToContacts.Find(predicate);
            return result.ToDto().ToList();
        }*/
    }
}