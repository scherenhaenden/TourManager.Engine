using System.Linq;
using AutoMapper;
using TourManager.Data.Core.Configuration;
using TourManager.Data.Core.Domain;
using TourManagerLogic.ApiModels;

namespace TourManagerLogic.Core.Api
{
    public class CustomersApi
    {
        private readonly TourManagerContext _tourManagerContext;
        private readonly MapperConfiguration _contaqtToDto;
        private readonly MapperConfiguration _DTOToContact;
        
        private readonly IMapper _DTOMToContactMapper;
        private readonly IMapper _ContactToDTOMapper;

        public CustomersApi(TourManagerContext tourManagerContext)
        {
            _tourManagerContext = tourManagerContext;
            _contaqtToDto = new MapperConfiguration(cfg => cfg.CreateMap<Contact, ContactsModel>().IgnoreAllPropertiesWithAnInaccessibleSetter());
            _DTOToContact = new MapperConfiguration(cfg => cfg.CreateMap<ContactsModel, Contact>().IgnoreAllPropertiesWithAnInaccessibleSetter());
            _DTOMToContactMapper = _DTOToContact.CreateMapper();
            _ContactToDTOMapper = _contaqtToDto.CreateMapper();
        }
        public void Add(ContactsModel values)
        {
            var contacts =_DTOMToContactMapper.Map<Contact>(values);
            
            _tourManagerContext.Contacts.Add(contacts);
            _tourManagerContext.SaveChanges();
        }
        
        public void Update(ContactsModel values)
        {
            var contacts =_DTOMToContactMapper.Map<Contact>(values);
            _tourManagerContext.Contacts.Update(contacts);
            _tourManagerContext.SaveChanges();
        }
        
        public void Delete(int id)
        {
            var entity = _tourManagerContext.Contacts.SingleOrDefault(x => x.Id == id);
            _tourManagerContext.Contacts.Remove(entity);
            _tourManagerContext.SaveChanges();
        }
        
        public ContactsModel SelectBy(int id)
        {
            var contact = _tourManagerContext.Contacts.SingleOrDefault(x => x.Id == id);
            if (contact == null)
            {
                return null;
            }
            return _DTOMToContactMapper.Map<ContactsModel>(contact);
        }
    }
}