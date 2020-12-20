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
        public ContacsApi(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        public void Add(ContactModel values)
        {
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
            var entity =_unityOfWork.Contacts.GetById(values.Id);
            

            entity = values.ToEntity(entity);
            
            _unityOfWork.Contacts.Update(entity);
            _unityOfWork.Complete();
        }
        
        public void Delete(int id)
        {
            var entity = _unityOfWork.Contacts.SingleOrDefault(x => x.Id == id);

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
            
            _unityOfWork.Contacts.Remove(entity);
            _unityOfWork.Complete();
        }
        
        public void Remove(ContactModel dto)
        {
            var entity = _unityOfWork.Contacts.SingleOrDefault(x => x.Id == dto.Id);            
            _unityOfWork.Contacts.Remove(entity);
            _unityOfWork.Complete();
        }
        
        public void RemoveRange(List<ContactModel> models)
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
        
        
        public List<int> GetAllIds()
        {
            return _unityOfWork.Contacts.GetAll().Select(x => x.Id).ToList();
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