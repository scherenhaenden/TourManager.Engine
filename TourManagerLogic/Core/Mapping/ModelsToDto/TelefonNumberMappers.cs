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
            return (from m in dtos 
                join r in entities on m.Id equals r.Id 
                select new { m, r }).ToList().Select(x=>x.m.ToEntity(x.r));
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