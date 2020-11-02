using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using TourManager.Data.Core.Domain;
using TourManager.Data.Persistence;
using TourManagerLogic.Core.Models;

namespace TourManagerLogic.Core.Api
{
    public class ContacsApi
    {
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _dtomToContactMapper;
        private readonly IMapper _contactToDtoMapper;

        public ContacsApi(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
            var configDtoToModel = new MapperConfiguration(cfg => {
                cfg.CreateMap<ContactModel, Contact>();
                cfg.CreateMap<AddressModel, Address>();
                cfg.CreateMap<EmailModel, Email>();
                cfg.CreateMap<TelefonNumberModel, TelefonNumber>();
            });
            
            var configModelToDto = new MapperConfiguration(cfg => {
                cfg.CreateMap<Contact, ContactModel>();
                cfg.CreateMap<Address, AddressModel >();
                cfg.CreateMap<Email, EmailModel>();
                cfg.CreateMap<TelefonNumber, TelefonNumberModel >();
            });
            _dtomToContactMapper = configDtoToModel.CreateMapper();
            _contactToDtoMapper = configModelToDto.CreateMapper();
          
        }
        public void Add(ContactModel values)
        {   
            var contacts =_dtomToContactMapper.Map<Contact>(values);
            _unityOfWork.Contacts.Add(contacts);
            _unityOfWork.Complete();
        }
        
        // FIXME: Technical deb 
        public List<ContactModel> GetAllPagination()
        {
            var result =_unityOfWork.Contacts.GetAll();
            return _contactToDtoMapper.Map<List<ContactModel>>(result);
        }
        
        public void Update(ContactModel values)
        {
            var entity =_unityOfWork.Contacts.GetById(values.Id);
            entity= _dtomToContactMapper.Map<ContactModel, Contact>(values, entity);
            _unityOfWork.Contacts.Update(entity);
            _unityOfWork.Complete();
        }
        
        public void Delete(int id)
        {
            var entity = _unityOfWork.Contacts.SingleOrDefault(x => x.Id == id);
            _unityOfWork.Contacts.Remove(entity);
            _unityOfWork.Complete();
        }
        
        public ContactModel SelectBy(int id)
        {
            var contact = (Contact)_unityOfWork.Contacts.GetById(id);
            if (contact == null)
            {
                return null;
            }
            return _contactToDtoMapper.Map<ContactModel>(contact);
        }
        
        public List<ContactModel> Find(Expression<Func<Contact, bool>> predicate)
        {
            var contacts = _unityOfWork.Contacts.Find(predicate);
            if (contacts == null)
            {
                return null;
            }
            var contactss =_contactToDtoMapper.Map<List<ContactModel>>(contacts);
            return contactss;
        }
    }
}