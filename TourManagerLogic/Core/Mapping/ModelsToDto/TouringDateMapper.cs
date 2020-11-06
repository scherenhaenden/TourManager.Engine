using System.Collections.Generic;
using System.Linq;
using TourManager.Data.Core.Domain;
using TourManagerLogic.Core.Models;

namespace TourManagerLogic.Core.Mapping.ModelsToDto
{
    public static class TouringDateMapper
    {
        public static TouringDate ToEntity(this TouringDatesModel dto, TouringDate entity)
        {
            if (dto != null)
            {
                entity.DateOfTour =  dto.DateOfTour;
                entity.Venue =  dto.Venue.ToEntity(entity.Venue);
                entity.Band =  dto.Band.ToEntity(entity.Band);
                return entity;
            }
            return null;
        }
        public static TouringDate ToEntity(this TouringDatesModel dto)
        {
            if (dto != null)
            {
                return new TouringDate
                {
                    DateOfTour =  dto.DateOfTour,
                    Venue =  dto.Venue.ToEntity(),
                    Band =  dto.Band.ToEntity(),
                };
            }

            return null;
        }
        
        public static TouringDatesModel ToDto(this TouringDate entity)
        {
            if (entity != null)
            {
                return new TouringDatesModel
                {
                    Id =  entity.Id,
                    DateOfTour =  entity.DateOfTour,
                    Venue =  entity.Venue.ToDto(),
                    Band =  entity.Band.ToDto(),
                };
            }

            return null;
        }
        
        public static IEnumerable<TouringDate> ToEntity(this IEnumerable<TouringDatesModel> dtos, IEnumerable<TouringDate> entities)
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

        public static IEnumerable<TouringDate> ToEntity(this IEnumerable<TouringDatesModel> dto)
        {
            return dto.Select(x => x.ToEntity());
        }
        
        public static IEnumerable<TouringDatesModel> ToDto(this IEnumerable<TouringDate> entity)
        {
            return entity.Select(x => x.ToDto());
        }
    }
}