using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using TourManager.Data.Core.Domain;
using TourManager.Data.Persistence;
using TourManagerLogic.ApiModels;

namespace TourManagerLogic.Core.Api
{
    public class CustomersApi
    {
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _DTOMToContactMapper;
        private readonly IMapper _ContactToDTOMapper;

        public CustomersApi(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
            var configDtoToModel = new MapperConfiguration(cfg => {
                cfg.CreateMap<ContactsModel, Contact>();
                cfg.CreateMap<AddressModel, Address>();
                cfg.CreateMap<EmailModel, Emails>();
                cfg.CreateMap<TelefonNumberModel, TelefonNumbers>();
            });
            
            var configModelToDto = new MapperConfiguration(cfg => {
                cfg.CreateMap<Contact, ContactsModel>();
                cfg.CreateMap<Address, AddressModel >();
                cfg.CreateMap<Emails, EmailModel>();
                cfg.CreateMap<TelefonNumbers, TelefonNumberModel >();
            });
            _DTOMToContactMapper = configDtoToModel.CreateMapper();
            _ContactToDTOMapper = configModelToDto.CreateMapper();
          
        }
        public void Add(ContactsModel values)
        {   
            var contacts =_DTOMToContactMapper.Map<Contact>(values);
            _unityOfWork.Contacts.Add(contacts);
            _unityOfWork.Complete();
        }
        
        // FIXME: Technical deb 
        public List<ContactsModel> GetAllPagination()
        {
            var result =_unityOfWork.Contacts.GetAll();
            return _ContactToDTOMapper.Map<List<ContactsModel>>(result);
            
            
        }
        
        public void Update(ContactsModel values)
        {
            var contacts =_DTOMToContactMapper.Map<Contact>(values);
            _unityOfWork.Contacts.Update(contacts);
            _unityOfWork.Complete();
        }
        
        public void Delete(int id)
        {
            var entity = _unityOfWork.Contacts.SingleOrDefault(x => x.Id == id);
            _unityOfWork.Contacts.Remove(entity);
            _unityOfWork.Complete();
        }
        
        public ContactsModel SelectBy(int id)
        {
            var contact = (Contact)_unityOfWork.Contacts.GetById(id);
            if (contact == null)
            {
                return null;
            }
            return _ContactToDTOMapper.Map<ContactsModel>(contact);
        }
        
        public List<ContactsModel> Find(Expression<Func<Contact, bool>> predicate)
        {
            var contacts = _unityOfWork.Contacts.Find(predicate);
            if (contacts == null)
            {
                return null;
            }
            var contactss =_ContactToDTOMapper.Map<List<ContactsModel>>(contacts);
            return contactss;
        }
    }
}