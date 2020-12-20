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
    public class VenuesApi
    {
        private readonly IUnityOfWork _unityOfWork;

        public VenuesApi(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        
        public List<int> GetAllIds()
        {
            return _unityOfWork.Venues.GetAll().Select(x => x.Id).ToList();
        }

        
        public void Add(VenueModel values)
        {
            var result =values.ToEntity();
            _unityOfWork.Venues.Add(result);
            _unityOfWork.Complete();
        }
        
        public void Update(VenueModel values)
        {
            var entity =_unityOfWork.Venues.GetById(values.Id);
            entity = values.ToEntity(entity);
            _unityOfWork.Venues.Update(entity);
            _unityOfWork.Complete();
        }
        
        public void Delete(int id)
        {
            var entity = _unityOfWork.Venues.SingleOrDefault(x => x.Id == id);

            var addressesIds=entity.Addresses.Select(x => x.Id).ToList();
            var emailsIds=entity.Emails.Select(x => x.Id).ToList();
            var telefonumbersIds=entity.TelefonNumbers.Select(x => x.Id).ToList();
            var venuesToContacsIds =entity.VenuesToContacts.Select(x => x.Id).ToList();
            
            foreach (var idsd in addressesIds)
            {
                try
                {
                    new AddressApi(_unityOfWork).Delete(idsd);
                }
                catch (Exception)
                {
                }
            }

            foreach (var idsd in emailsIds)
            {
                try
                {
                    new EmailApi(_unityOfWork).Delete(idsd);
                }
                catch (Exception)
                {
                }
            }

            foreach (var idsds in telefonumbersIds)
            {
                try
                {
                    new TelefonNumberApi(_unityOfWork).Delete(idsds);
                }
                catch (Exception)
                {
                }
                
            }

            foreach (var idsd in venuesToContacsIds)
            {
                try
                {
                    new VenuesContactApi(_unityOfWork).Delete(idsd);
                }
                catch (Exception)
                {
                }
                
            }

            _unityOfWork.Venues.Remove(entity);
            _unityOfWork.Complete();
        }
        
        public VenueModel SelectBy(int id)
        {
            var venue = (Venue)_unityOfWork.Venues.GetById(id);
            if (venue == null)
            {
                return null;
            }

            return venue.ToDto();
        }
        
        public List<VenueModel> Find(Expression<Func<Venue, bool>> predicate)
        {
            var venues = _unityOfWork.Venues.Find(predicate);
            if (venues == null)
            {
                return null;
            }
            return venues.ToDto().ToList();
        }
        
        public List<VenueModel> GetAllPagination()
        {
            var result =_unityOfWork.Venues.GetAll();
            return result.ToDto().ToList();
        }

    }
}