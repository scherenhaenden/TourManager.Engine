using System.Collections.Generic;
using System.Linq;
using TourManager.Data.Core.Domain;
using TourManagerLogic.Core.Models;

namespace TourManagerLogic.Core.Mapping.ModelsToDto
{
    public static class ContactsMapper
    {
        public static Contact ToEntity(this ContactModel dto, Contact entity)
        {
            if (dto != null)
            {
                entity.FirstName =  dto.FirstName;
                entity.LastName =  dto.LastName;
                entity.TelephoneNumbers =  dto.TelephoneNumbers.ToEntity(entity.TelephoneNumbers).ToList();
                entity.Emails =  dto.Emails.ToEntity(entity.Emails ).ToList();
                entity.Addresses =  dto.Addresses.ToEntity(entity.Addresses).ToList();
                entity.VenueId =  dto.VenueId;

                return entity;

            }

            return null;
        }
        public static Contact ToEntity(this ContactModel dto)
        {
            if (dto != null)
            {
                return new Contact
                {
                    FirstName =  dto.FirstName,
                    LastName =  dto.LastName,
                    TelephoneNumbers =  dto.TelephoneNumbers.ToEntity().ToList(),
                    Emails =  dto.Emails.ToEntity().ToList(),
                    Addresses =  dto.Addresses.ToEntity().ToList(),
                    VenueId =  dto.VenueId,
                };
            }

            return null;
        }
        
        public static ContactModel ToDto(this Contact entity)
        {
            if (entity != null)
            {
                return new ContactModel
                {
                    Id = entity.Id,
                    FirstName =  entity.FirstName,
                    LastName =  entity.LastName,
                    TelephoneNumbers =  entity.TelephoneNumbers.ToDto().ToList(),
                    Emails =  entity.Emails.ToDto().ToList(),
                    Addresses =  entity.Addresses.ToDto().ToList(),
                    VenueId =  entity.VenueId,
                };
            }

            return null;
        }
        
        public static IEnumerable<Contact> ToEntity(this IEnumerable<ContactModel> dtos, IEnumerable<Contact> entities)
        {
            var joinedLists= (from m in dtos 
                join r in entities on m.Id equals r.Id into merged
                from r in merged.DefaultIfEmpty()
                select new { m , r });
            
            var update = joinedLists.Where(x => x.r != null).Select(x => x.m.ToEntity(x.r));
            var add = joinedLists.Where(x => x.r == null).Select(x => x.m.ToEntity());
            var rEmails= update.ToList();
            rEmails.AddRange(add);
            return rEmails;
        }

        public static IEnumerable<Contact> ToEntity(this IEnumerable<ContactModel> dto)
        {
            return dto.Select(x => x.ToEntity());
        }
        
        public static IEnumerable<ContactModel> ToDto(this IEnumerable<Contact> entity)
        {
            return entity.Select(x => x.ToDto());
        }
    }
}