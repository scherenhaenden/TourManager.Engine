using System.Collections.Generic;
using System.Linq;
using TourManager.Data.Core.Domain;
using TourManagerLogic.Core.Models;

namespace TourManagerLogic.Core.Mapping.ModelsToDto
{
    public static class TourMapper
    {
         public static Tour ToEntity(this TourModel dto, Tour entity)
        {
            if (dto != null)
            {
                entity.NameOfTour =  dto.NameOfTour;
                entity.TouringDates =  dto.TouringDates.ToEntity(entity.TouringDates).ToList();
                return entity;
            }
            return null;
        }
        public static Tour ToEntity(this TourModel dto)
        {
            if (dto != null)
            {
                var entity = new Tour
                {
                    Id = dto.Id,
                    NameOfTour = dto.NameOfTour,
                    TouringDates = dto.TouringDates.ToEntity().ToList()
                };

                return entity;
            }

            return null;
        }
        
        public static TourModel ToDto(this Tour entity)
        {
            if (entity != null)
            {
                return new TourModel
                {
                    Id = entity.Id,
                    NameOfTour = entity.NameOfTour,
                    TouringDates = entity.TouringDates.ToDto().ToList(),
                };
            }

            return null;
        }
        
        public static IEnumerable<Tour> ToEntity(this IEnumerable<TourModel> dtos, IEnumerable<Tour> entities)
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

        public static IEnumerable<Tour> ToEntity(this IEnumerable<TourModel> dto)
        {
            return dto.Select(x => x.ToEntity());
        }
        
        public static IEnumerable<TourModel> ToDto(this IEnumerable<Tour> entity)
        {
            return entity.Select(x => x.ToDto());
        }
    }
}