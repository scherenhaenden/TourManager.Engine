using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.EntityFrameworkCore;
using AutoMapper.EquivalencyExpression;
using TourManager.Data.Core.Configuration;
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

        public ContacsApi(IUnityOfWork unityOfWork, MapperConfiguration MapperConfiguration)
        {
            _unityOfWork = unityOfWork;
            _dtomToContactMapper = MapperConfiguration.CreateMapper();
            _contactToDtoMapper = MapperConfiguration.CreateMapper();
        }

        public ContacsApi(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
            var configDtoToModel = new MapperConfiguration(cfg => {
                cfg.AddCollectionMappers();
                cfg.CreateMap<ContactModel, Contact>()
                    .ForMember(dest => dest.Addresses, opt => opt.UseDestinationValue())
                    .ForMember(dest => dest.Emails, opt => opt.UseDestinationValue())
                    .ForMember(dest => dest.TelefonNumbers, opt => opt.UseDestinationValue());
                cfg.CreateMap<AddressModel, Address>();
                cfg.CreateMap<EmailModel, Email>();
                cfg.CreateMap<TelefonNumberModel, TelefonNumber>();
                //cfg.UseEntityFrameworkCoreModel<GenerateEntityFrameworkCorePrimaryKeyPropertyMaps<TourManagerContext>>(null);
            });
            
            var configModelToDto = new MapperConfiguration(cfg => {
                cfg.AddCollectionMappers();
                cfg.CreateMap<Contact, ContactModel>()
                    .ForMember(dest => dest.Addresses, opt => opt.UseDestinationValue())
                    .ForMember(dest => dest.Emails, opt => opt.UseDestinationValue())
                    .ForMember(dest => dest.TelefonNumbers, opt => opt.UseDestinationValue());
                cfg.CreateMap<Address, AddressModel >();
                cfg.CreateMap<Email, EmailModel>();
                cfg.CreateMap<TelefonNumber, TelefonNumberModel >();
                //cfg.UseEntityFrameworkCoreModel<GenerateEntityFrameworkCorePrimaryKeyPropertyMaps<TourManagerContext>>(null);
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
            
            
            var contact =_dtomToContactMapper.Map<Contact>(values);
            _unityOfWork.Contacts.Update(contact);
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