using System;
using System.Collections.Generic;
using System.Linq;
using TourManager.Data.Core.Domain;
using TourManagerLogic.Core.Models;

namespace TourManagerLogic.Core.Mapping.ModelsToDto
{
    public static class VenuesToContactsMapper
    {
        public static VenuesToContacts ToEntity(this VenuesToContactsModel dto, VenuesToContacts entity)
        {
            if (dto != null)
            {
                entity.VenueId =  dto.VenueId;
                entity.ContactId =  dto.ContactId;
                entity.Venue =  dto.Venue.ToEntity(entity.Venue);
                entity.Contact =  dto.Contact.ToEntity(entity.Contact );
                return entity;
            }

            return null;
        }
        
        public static VenuesToContacts ToEntity(this VenuesToContactsModel dto)
        {
            if (dto != null)
            {
                return new VenuesToContacts
                {
                    Id = dto.Id,
                    VenueId =  dto.VenueId,
                    ContactId =  dto.ContactId,
                    Venue =  dto.Venue.ToEntity(),
                    Contact =  dto.Contact.ToEntity(),
                   
                };
            }

            return null;
        }
        
        public static VenuesToContactsModel ToDto(this VenuesToContacts entity)
        {
            if (entity != null)
            {
                return new VenuesToContactsModel
                {
                    Id = entity.Id,
                    VenueId =  entity.VenueId,
                    ContactId =  entity.ContactId,
                    Venue =  entity.Venue.ToDto(),
                    Contact =  entity.Contact.ToDto(),
                };
            }

            return null;
        }
        
        public static IEnumerable<VenuesToContacts> ToEntity(this IEnumerable<VenuesToContactsModel> dtos, IEnumerable<VenuesToContacts> entities)
        {
            if (dtos == null) throw new ArgumentNullException(nameof(dtos));
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

        public static IEnumerable<VenuesToContacts> ToEntity(this IEnumerable<VenuesToContactsModel> dto)
        {
            return dto.Select(x => x.ToEntity());
        }
        
        public static IEnumerable<VenuesToContactsModel> ToDto(this IEnumerable<VenuesToContacts> entity)
        {
            return entity.Select(x => x.ToDto());
        }
    }
}