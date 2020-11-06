using System.Collections.Generic;
using System.Linq;
using TourManager.Data.Core.Domain;
using TourManagerLogic.Core.Models;

namespace TourManagerLogic.Core.Mapping.ModelsToDto
{
    public static class BandMapper
    {
        public static Band ToEntity(this BandModel dto, Band entity)
        {
            if (dto != null)
            {
                entity.Name =  dto.Name;
                entity.Manager =  dto.Manager.ToEntity(entity.Manager);
                entity.Style =  dto.Style;
                entity.Members =  dto.Members.ToEntity(entity.Members).ToList();
                entity.Address =  dto.Address.ToEntity(entity.Address);
                entity.Emails =  dto.Emails.ToEntity(entity.Emails ).ToList();
                return entity;
            }
            return null;
        }
        public static Band ToEntity(this BandModel dto)
        {
            if (dto != null)
            {
                return new Band
                {
                    Name =  dto.Name,
                    Manager =  dto.Manager.ToEntity(),
                    Style =  dto.Style,
                    Members =  dto.Members.ToEntity().ToList(),
                    Address =  dto.Address.ToEntity(),
                    Emails =  dto.Emails.ToEntity().ToList(),
                };
            }

            return null;
        }
        
        public static BandModel ToDto(this Band entity)
        {
            if (entity != null)
            {
                return new BandModel
                {
                    Id = entity.Id,
                    Name =  entity.Name,
                    Manager =  entity.Manager.ToDto(),
                    Style =  entity.Style,
                    Members =  entity.Members.ToDto().ToList(),
                    Address =  entity.Address.ToDto(),
                    Emails =  entity.Emails.ToDto().ToList(),
                };
            }

            return null;
        }
        
        public static IEnumerable<Band> ToEntity(this IEnumerable<BandModel> dtos, IEnumerable<Band> entities)
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

        public static IEnumerable<Band> ToEntity(this IEnumerable<BandModel> dto)
        {
            return dto.Select(x => x.ToEntity());
        }
        
        public static IEnumerable<BandModel> ToDto(this IEnumerable<Band> entity)
        {
            return entity.Select(x => x.ToDto());
        }
    }
}