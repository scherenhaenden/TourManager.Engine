using System.Collections.Generic;
using System.Linq;
using TourManager.Data.Core.Domain;
using TourManagerLogic.Core.Models;

namespace TourManagerLogic.Core.Mapping.ModelsToDto
{
    public static class VenuesMapper
    {
        public static Venue ToEntity(this VenueModel dto, Venue entity)
        {
            if (entity != null)
            {
                entity.Name = dto.Name;
                entity.Addresses = dto.Addresses.ToEntity(entity.Addresses).ToList();
                entity.Emails = dto.Emails.ToEntity(entity.Emails).ToList();
                entity.TelefonNumbers = dto.TelefonNumbers.ToEntity(entity.TelefonNumbers).ToList();
                //entity.VenuesToContacts = dto.VenuesToContacts.ToEntity(entity.VenuesToContacts).ToList();
                entity.LoadIn = dto.LoadIn;
                entity.CurfView = dto.CurfView;
                entity.MaxCapacity = dto.MaxCapacity;
                entity.Notes = dto.Notes;
                return entity;
            }

            return null;
        }
        
        
        public static Venue ToEntity(this VenueModel dto)
        {
            if (dto != null)
            {
                return new Venue
                {
                    Id =  dto.Id,
                    Name = dto.Name,
                    Addresses = dto.Addresses.ToEntity().ToList(),
                    Emails = dto.Emails.ToEntity().ToList(),
                    TelefonNumbers = dto.TelefonNumbers.ToEntity().ToList(),
                    //VenuesToContacts = dto.VenuesToContacts.ToEntity().ToList(),
                    LoadIn = dto.LoadIn,
                    CurfView = dto.CurfView,
                    MaxCapacity = dto.MaxCapacity,
                    Notes = dto.Notes,
                };
            }

            return null;
        }
        
        public static VenueModel ToDto(this Venue entity)
        {
            if (entity != null)
            {
                return new VenueModel
                {
                    Id =  entity.Id,
                    Name = entity.Name,
                    Addresses = entity.Addresses.ToDto().ToList(),
                    Emails = entity.Emails.ToDto().ToList(),
                    TelefonNumbers = entity.TelefonNumbers.ToDto().ToList(),
                    //VenuesToContacts = entity.VenuesToContacts.ToDto().ToList(),
                    LoadIn = entity.LoadIn,
                    CurfView = entity.CurfView,
                    MaxCapacity = entity.MaxCapacity,
                    Notes = entity.Notes,
                };
            }

            return null;
        }

        public static IEnumerable<Venue> ToEntity(this IEnumerable<VenueModel> emailModel)
        {
            return emailModel.Select(x => x.ToEntity());
        }

        public static IEnumerable<Venue> ToEntity(this IEnumerable<VenueModel> dtos, IEnumerable<Venue> entities)
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

        public static IEnumerable<VenueModel> ToDto(this IEnumerable<Venue> emailEntity)
        {
            return emailEntity.Select(x => x.ToDto());
        }
    }
}