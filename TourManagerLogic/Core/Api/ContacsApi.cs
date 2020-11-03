using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
using TourManager.Data.Core.Domain;
using TourManager.Data.Persistence;
using TourManagerLogic.Core.Mapping.ModelsToDto;
using TourManagerLogic.Core.Models;

namespace TourManagerLogic.Core.Api
{
    public class ContacsApi
    {
        private readonly IUnityOfWork _unityOfWork;
       // private readonly IMapper _dtomToContactMapper;
        //private readonly IMapper _contactToDtoMapper;

        public ContacsApi(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
          /*  var configDtoToModel = new MapperConfiguration(cfg => {
                cfg.AddCollectionMappers();
                cfg.CreateMap<ContactModel, Contact>()
                 /*   .ForMember(dest => dest.Addresses, opt => opt.UseDestinationValue())
                    .ForMember(dest => dest.Emails, opt => opt.UseDestinationValue())
                    .ForMember(dest => dest.TelefonNumbers, opt => opt.UseDestinationValue())* /
                    
                    ;
                cfg.CreateMap<AddressModel, Address>();
                cfg.CreateMap<EmailModel, Email>();
                cfg.CreateMap<TelefonNumberModel, TelefonNumber>();
                
            });
            
            var configModelToDto = new MapperConfiguration(cfg => {
                cfg.AddCollectionMappers();
                cfg.CreateMap<Contact, ContactModel>()
                   /* .ForMember(dest => dest.Addresses, opt => opt.UseDestinationValue())
                    .ForMember(dest => dest.Emails, opt => opt.UseDestinationValue())
                    .ForMember(dest => dest.TelefonNumbers, opt => opt.UseDestinationValue())* /
                    ;
                cfg.CreateMap<Address, AddressModel>();
                cfg.CreateMap< Email, EmailModel>();
                cfg.CreateMap< TelefonNumber,TelefonNumberModel>();
            });
            _dtomToContactMapper = configDtoToModel.CreateMapper();
            _contactToDtoMapper = configModelToDto.CreateMapper();*/
          
        }
        public void Add(ContactModel values)
        {   
            //var contacts =_dtomToContactMapper.Map<Contact>(values);

            var result = values.ToEntity();
            _unityOfWork.Contacts.Add(result);
            _unityOfWork.Complete();
        }
        
        // FIXME: Technical deb 
        public List<ContactModel> GetAllPagination()
        {
            var result =_unityOfWork.Contacts.GetAll();
            return result.ToDto().ToList();
        }
        
        public void Update(ContactModel values)
        {
            
            
            /*var configDtoToModel = new MapperConfiguration(cfg => {
                cfg.AddCollectionMappers();
                
                cfg.CreateMap<ContactModel, Contact>()
                    .ForMember(dest => dest.Addresses, opt => opt.UseDestinationValue())
                    .ForMember(dest => dest.Emails, opt => opt.UseDestinationValue())
                    .ForMember(dest => dest.TelefonNumbers, opt => opt.UseDestinationValue())
                    
                    ;
                cfg.CreateMap<ICollection<AddressModel>, ICollection<Address>>();
                cfg.CreateMap<ICollection<EmailModel>, ICollection<Email>>();
                cfg.CreateMap<ICollection<TelefonNumberModel>, ICollection<TelefonNumber>>();
                
            });*/
            
            
            
            
            var entity =_unityOfWork.Contacts.GetById(values.Id);
            //entity= configDtoToModel.CreateMapper().Map<ContactModel, Contact>(values, entity);

            entity = values.ToEntity(entity);
            
            _unityOfWork.Contacts.Update(entity);
            _unityOfWork.Complete();
        }
        
        public void Delete(int id)
        {
            var entity = _unityOfWork.Contacts.SingleOrDefault(x => x.Id == id);
            _unityOfWork.Contacts.Remove(entity);
            _unityOfWork.Complete();
        }
        
        public void DeleteRange(List<ContactModel> models)
        {
            //DO not use "models.any" otherwise Find will try to translate the DTOS but those cannot be translated inside of the unity
            var listOfIds= models.Select(x => x.Id);
            var entities = _unityOfWork.Contacts.Find(x => listOfIds.Any(l => l == x.Id)).ToList();


            entities = models.ToEntity(entities).ToList();
            
            _unityOfWork.Contacts.RemoveRange(entities);
            _unityOfWork.Complete();
        }
        
        public ContactModel SelectBy(int id)
        {
            var contact = (Contact)_unityOfWork.Contacts.GetById(id);
            if (contact == null)
            {
                return null;
            }
            return contact.ToDto();
        }
        
        public ContactModel SelectByLoadEmails(int id)
        {
            var contact = (Contact)_unityOfWork.Contacts.GetById(id);
            if (contact == null)
            {
                return null;
            }
            
            var result =  _unityOfWork.Emails.GetAll()?.Where(x => x.ContactId == contact.Id);

            contact.Emails = result.Where(x => x.ContactId == contact.Id).ToList();
            return contact.ToDto();
        }
        
        public ContactModel SelectByLoadTelefonNumbers(int id)
        {
            var contact = (Contact)_unityOfWork.Contacts.GetById(id);
            if (contact == null)
            {
                return null;
            }
            
            var result =  _unityOfWork.TelefonNumbers.GetAll()?.Where(x => x.ContactId == contact.Id);

            contact.TelefonNumbers = result.Where(x => x.ContactId == contact.Id).ToList();
            return contact.ToDto();
        }
        
        public ContactModel SelectByLoadAddresses(int id)
        {
            var contact = (Contact)_unityOfWork.Contacts.GetById(id);
            if (contact == null)
            {
                return null;
            }
            
            var result =  _unityOfWork.Address.GetAll()?.Where(x => x.ContactId == contact.Id);

            contact.Addresses = result.Where(x => x.ContactId == contact.Id).ToList();
            return contact.ToDto();
        }
        
        
        
        
        public List<ContactModel> Find(Expression<Func<Contact, bool>> predicate)
        {
            var contacts = _unityOfWork.Contacts.Find(predicate);
            if (contacts == null)
            {
                return null;
            }
            return contacts.ToDto().ToList();
        }
    }
}