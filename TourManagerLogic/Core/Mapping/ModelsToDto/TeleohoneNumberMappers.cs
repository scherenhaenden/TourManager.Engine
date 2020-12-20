using System.Collections.Generic;
using System.Linq;
using TourManager.Data.Core.Domain;
using TourManagerLogic.Core.Models;

namespace TourManagerLogic.Core.Mapping.ModelsToDto
{
    public static class TeleohoneNumberMappers
    {
         public static TelephoneNumber ToEntity(this TelephoneNumberModel dto, TelephoneNumber entity)
        {
            if (dto != null)
            {
                entity.Number =  dto.Number;
                entity.ContactId =  dto.ContactId;
                entity.VenueId =  dto.VenueId;
                return entity;

            }

            return null;
        }
        public static TelephoneNumber ToEntity(this TelephoneNumberModel dto)
        {
            if (dto != null)
            {
                return new TelephoneNumber
                {
                    Id =  dto.Id,
                    Number =  dto.Number,
                    ContactId =  dto.ContactId,
                    VenueId =  dto.VenueId,
                };
            }

            return null;
        }
        
        public static TelephoneNumberModel ToDto(this TelephoneNumber entity)
        {
            if (entity != null)
            {
                return new TelephoneNumberModel
                {
                    Id =  entity.Id,
                    Number =  entity.Number,
                    ContactId =  entity.ContactId,
                    VenueId =  entity.VenueId,
                };
            }

            return null;
        }
        
        public static IEnumerable<TelephoneNumber> ToEntity(this IEnumerable<TelephoneNumberModel> dtos, IEnumerable<TelephoneNumber> entities)
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

        public static IEnumerable<TelephoneNumber> ToEntity(this IEnumerable<TelephoneNumberModel> dto)
        {
            return dto.Select(x => x.ToEntity());
        }
        
        public static IEnumerable<TelephoneNumber> ToEntity(this List<TelephoneNumberModel> dto)
        {
            return dto.Select(x => x.ToEntity());
        }
        
        public static IEnumerable<TelephoneNumberModel> ToDto(this IEnumerable<TelephoneNumber> entity)
        {
            return entity.Select(x => x.ToDto());
        }
    }
}