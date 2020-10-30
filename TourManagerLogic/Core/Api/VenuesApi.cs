using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using TourManager.Data.Core.Domain;
using TourManager.Data.Persistence;
using TourManagerLogic.Core.Models;

namespace TourManagerLogic.Core.Api
{
    public class VenuesApi
    {
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _dtomToContactMapper;
        private readonly IMapper _contactToDtoMapper;

        public VenuesApi(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
            var configDtoToModel = new MapperConfiguration(cfg => {
                cfg.CreateMap<VenueModel, Venue>();
                cfg.CreateMap<AddressModel, Address>();
                cfg.CreateMap<EmailModel, Email>();
                cfg.CreateMap<TelefonNumberModel, TelefonNumber>();
                cfg.CreateMap<ContactModel, Contact>();
            });
            
            var configModelToDto = new MapperConfiguration(cfg => {
                cfg.CreateMap<Venue, VenueModel>();
                cfg.CreateMap<Address, AddressModel >();
                cfg.CreateMap<Email, EmailModel>();
                cfg.CreateMap<TelefonNumber, TelefonNumberModel >();
                cfg.CreateMap<Contact, ContactModel>();
            });
            _dtomToContactMapper = configDtoToModel.CreateMapper();
            _contactToDtoMapper = configModelToDto.CreateMapper();
          
        }
        
        public void Add(VenueModel values)
        {   
            var contacts =_dtomToContactMapper.Map<Venue>(values);
            _unityOfWork.Venues.Add(contacts);
            _unityOfWork.Complete();
        }
        
        public void Update(VenueModel values)
        {
            var contacts =_dtomToContactMapper.Map<Venue>(values);
            _unityOfWork.Venues.Update(contacts);
            _unityOfWork.Complete();
        }
        
        public void Delete(int id)
        {
            var entity = _unityOfWork.Venues.SingleOrDefault(x => x.Id == id);
            _unityOfWork.Venues.Remove(entity);
            _unityOfWork.Complete();
        }
        
        public VenueModel SelectBy(int id)
        {
            var contact = (Venue)_unityOfWork.Venues.GetById(id);
            if (contact == null)
            {
                return null;
            }
            return _contactToDtoMapper.Map<VenueModel>(contact);
        }
        
        public List<VenueModel> Find(Expression<Func<Venue, bool>> predicate)
        {
            var contacts = _unityOfWork.Venues.Find(predicate);
            if (contacts == null)
            {
                return null;
            }
            var contactss =_contactToDtoMapper.Map<List<VenueModel>>(contacts);
            return contactss;
        }
        
        public List<VenueModel> GetAllPagination()
        {
            var result =_unityOfWork.Venues.GetAll();
            return _contactToDtoMapper.Map<List<VenueModel>>(result);
        }

    }
}