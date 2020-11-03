using System.Collections.Generic;
using System.Linq;
using TourManager.Data.Core.Domain;
using TourManagerLogic.Core.Models;

namespace TourManagerLogic.Core.Mapping.ModelsToDto
{
    public static class TelefonNumberMappers
    {
         public static TelefonNumber ToEntity(this TelefonNumberModel dto, TelefonNumber entity)
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
        public static TelefonNumber ToEntity(this TelefonNumberModel dto)
        {
            if (dto != null)
            {
                return new TelefonNumber
                {
                    Id =  dto.Id,
                    Number =  dto.Number,
                    ContactId =  dto.ContactId,
                    VenueId =  dto.VenueId,
                };
            }

            return null;
        }
        
        public static TelefonNumberModel ToDto(this TelefonNumber entity)
        {
            if (entity != null)
            {
                return new TelefonNumberModel
                {
                    Id =  entity.Id,
                    Number =  entity.Number,
                    ContactId =  entity.ContactId,
                    VenueId =  entity.VenueId,
                };
            }

            return null;
        }
        
        public static IEnumerable<TelefonNumber> ToEntity(this IEnumerable<TelefonNumberModel> dtos, IEnumerable<TelefonNumber> entities)
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

        public static IEnumerable<TelefonNumber> ToEntity(this IEnumerable<TelefonNumberModel> dto)
        {
            return dto.Select(x => x.ToEntity());
        }
        
        public static IEnumerable<TelefonNumber> ToEntity(this List<TelefonNumberModel> dto)
        {
            return dto.Select(x => x.ToEntity());
        }
        
        public static IEnumerable<TelefonNumberModel> ToDto(this IEnumerable<TelefonNumber> entity)
        {
            return entity.Select(x => x.ToDto());
        }
    }
}